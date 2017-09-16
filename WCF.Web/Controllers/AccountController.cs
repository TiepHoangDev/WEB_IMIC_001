using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using Facebook;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;
using Google.Apis.Services;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.Web.Core;
using System.IO;
using WCF.BusinessObjectsLayer;

namespace WCF.Web.Controllers
{
    public class AccountController : Controller
    {
        /*
         * Control xử lý đăng nhập, đăng ký bao gồm tk thường, fb, gg.
         * NgocNB - 16082016
         */

        /*
         * Trang đăng nhập
         * NgocNB - 16082016
         */
        public ActionResult Index()
        {
            // Chưa đăng nhập
            return View();
        }

        /*
         * Xử lý đăng nhập từ client tk thường
         * NgocNB - 16082016
         */
        [HttpPost]
        //[ValidateAntiForgeryToken] //So khớp token giữa Server vs Client để đảm bảo đồng bộ Request & Response
        public JsonResult Login(LoginObject objLogin)
        {
            // kiểm tra xử lý đăng nhập
            if (ModelState.IsValid)
            {
                var rs = AccountBcl.Login(objLogin, true);
                if (rs == 1)
                {
                    // kiem tra quyen
                    // coding
                    //AccountObject objAccount = new AccountObject()
                    //{
                    //    Username = objLogin.Username
                    //}; // code them lay tk tu db
                    AccountObject objAccount = new AccountBcl().getLoginAccount(objLogin.Username, objLogin.Password);
                    // session
                    Session.Add(CommonConstants.SESSION_ACCOUNT, objAccount);

                    // cookie
                    FormsAuthentication.SetAuthCookie(objLogin.Username, objLogin.RememberMe);

                    return Json(new { rs = 1 });
                }
                else if (rs == 0)
                {
                    //ModelState.AddModelError("", "Tài khoản không tồn tại");
                    return Json(new { rs = 0 });
                }
                else if (rs == -2)
                {
                    //ModelState.AddModelError("", "Mật khẩu không đúng");
                    return Json(new { rs = -2 });
                }
                else
                {
                    //ModelState.AddModelError("", "Đăng nhập thất bại");
                    //return Json(new { rs = -3 });
                }
            }

            return Json(new { rs = -3 });
            //return Redirect(Request.UrlReferrer + "");
        }

        /*
         * Xử lý đăng xuất
         * NgocNB - 18092016
         */
        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Remove(CommonConstants.SESSION_ACCOUNT);
            FormsAuthentication.SignOut();
            return Redirect(Request.UrlReferrer + "");
        }

        /*
         * Xử lý login facebook
         * NgocNB - 18102016
         */
        #region Login with Facebook
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        // Từ view gọi vào hàm này để xử lý login fb
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FacebookAppId"],
                //client_secret = ConfigurationManager.AppSettings["FacebookAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "public_profile,email,user_birthday",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FacebookAppId"],
                client_secret = ConfigurationManager.AppSettings["FacebookAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=id,name,gender,picture,email,birthday,locale");

                // Kiểm tra xem tk đã có trong csdl chưa qua facebook id
                AccountObject objAccountRsChecked = AccountBcl.CheckFacebookId(me.id);
                if (objAccountRsChecked != null)
                {
                    // Đã có trong csdl rồi
                    // Tạo session đăng nhập thành công
                    Session.Add(CommonConstants.SESSION_ACCOUNT, objAccountRsChecked);

                    // Tải lại trang
                    return RedirectToAction("Index", "IntroducePage");
                }
                else
                {
                    // Nếu chưa có tk, insert vào csdl đăng ký. Sau đó tạo session đăng nhập thành công
                    // Đóng gói đối tượng 
                    AccountObject objAccount = new AccountObject()
                    {
                        Birthday = me.birthday,
                        Email = me.email,
                        FullName = me.name,
                        FacebookId = me.id,
                        Gender = me.gender.Equals("male"),
                        ImageAvatar = me.picture.data.url
                    };

                    // Nếu ko lấy đc mail thì dãn đến trang cho phép nhập mail
                    if (objAccount.Email.IsEmpty())
                    {
                        ViewBag.ErrorEmail = false; // Tạm thời chưa có lỗi ở email
                        return View("ConfirmEmail", objAccount);
                    }
                    else
                    {
                        // Insert tk xuống csdl
                        objAccount.AccountId = Guid.NewGuid();
                        objAccount.RoleId = 3; // tk thường
                        objAccount.ModifiedTime = DateTime.Now + "";
                        AccountBcl.CreateAccount(objAccount);

                        // Tạo session
                        Session.Add(CommonConstants.SESSION_ACCOUNT, objAccount);

                        // Tải lại trang
                        return RedirectToAction("Index", "IntroducePage");
                    }
                }
            }
            return RedirectToAction("Index", "IntroducePage");
        }
        #endregion

        /*
         * Xử lý data google
         * NgocNB - 18092016
         */
        #region Login with Google
        public async Task<ActionResult> LoginGoogle(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken);

            if (result.Credential == null)
                return new RedirectResult(result.RedirectUri);

            var plusService = new PlusService(new BaseClientService.Initializer
            {
                HttpClientInitializer = result.Credential,
                ApplicationName = "MvcLogin App"
            });

            // Lấy thông tin cơ bản của user
            Person me = plusService.People.Get("me").Execute();

            if (me != null)
            {
                // Kiểm tra xem tk đã có trong csdl chưa qua google id
                AccountObject objAccountRsChecked = AccountBcl.CheckGoogleId(me.Id);
                if (objAccountRsChecked != null)
                {
                    // Đã có trong csdl rồi
                    // Tạo session đăng nhập thành công
                    Session.Add(CommonConstants.SESSION_ACCOUNT, objAccountRsChecked);

                    // Tải lại trang
                    return RedirectToAction("Index", "IntroducePage");
                }
                else
                {
                    // Nếu chưa có tk, insert vào csdl đăng ký. Sau đó tạo session đăng nhập thành công
                    // Đóng gói đối tượng 
                    AccountObject objAccount = new AccountObject()
                    {
                        Email = me.Emails.ElementAt(0).Value,
                        FullName = me.Name.GivenName + " " + me.Name.FamilyName,
                        GoogleId = me.Id,
                        ImageAvatar = me.Image.Url
                    };
                    //string DisplayName = me.DisplayName;
                    //string Provider = IdentityProvider.Google;

                    // Insert tk xuống csdl
                    objAccount.AccountId = Guid.NewGuid();
                    objAccount.RoleId = 3; // tk thường
                    objAccount.ModifiedTime = DateTime.Now + "";
                    AccountBcl.CreateAccount(objAccount);

                    // Tạo session
                    Session.Add(CommonConstants.SESSION_ACCOUNT, objAccount);

                    // Tải lại trang
                    return RedirectToAction("Index", "IntroducePage");
                }

            }
            return RedirectToAction("Index", "IntroducePage");
        }
        #endregion

        /*
         * Xác nhận lại email
         * NgocNB - 18092016
         */
        [HttpPost]
        public ActionResult ConfirmEmail(AccountObject objAccount)
        {
            objAccount.Gender = Request["Gender"].Equals("male"); // Lấy giới tính string => bool

            // Check email empty string + không trùng trong db
            if (string.IsNullOrEmpty(objAccount.Email) && AccountBcl.CheckEmail(objAccount.Email))
            {
                // Nếu email trống hoặc đã tồn tại, tải lại trang và yêu cầu kiểm tra lại
                ViewBag.ErrorEmail = true; // Mình thích thì mình báo lỗi thôi
                return View(objAccount);
            }

            // Email đã hợp lệ
            // Cho phép thêm tài khoản vào csdl
            objAccount.AccountId = Guid.NewGuid();
            objAccount.RoleId = 3; // tk thường
            objAccount.ModifiedTime = DateTime.Now + "";
            AccountBcl.CreateAccount(objAccount);

            // Tạo session
            Session.Add(CommonConstants.SESSION_ACCOUNT, objAccount);

            // Tải lại trang
            return RedirectToAction("Index", "IntroducePage");
        }

        /*
         * Đăng ký tài khoản
         * NgocNB - 05102016
         */
        public ActionResult Register()
        {
            return View();
        }

        // Ngocnb - 29112016
        [HttpPost]
        public JsonResult RegSession(string ping)
        {
            return Json(new {data = 1});
        }

        public ActionResult UserProfile(string Username)
        {
            AccountObject objAccount = new AccountBcl().getByUsername(Username);
            ViewBag.AccountID = objAccount.AccountId;
            return View(objAccount);
        }

        public ActionResult UserProfile_Overview(Guid AccountID)
        {
            ViewBag.AccountID = AccountID;
            return View();
        }

        public ActionResult UserProfile_Settings(string Username)
        {
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objUser != null && objUser.Username == Username)
            {
                AccountObject objAccount = new AccountBcl().getByUsername(Username);
                ViewBag.AccountID = objAccount.AccountId;
                return View(objAccount);
            }
            else
            {
                return RedirectToAction("UserProfile", "Account", new { Username = Username });
            }
        }

        [HttpPost]
        public JsonResult UserProfile_UpdateInformation(Guid AccountID, string FullName, string Email, string Phone, string Birthday, bool Gender)
        {
            try
            {
                new AccountBcl().Update_Information(AccountID, FullName, Email, Phone, DateTime.Parse(Birthday), Gender);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra" });
            }
            return Json(new { result = true, message = "Thay đổi thông tin cá nhân thành công" });
        }

        [HttpPost]
        public JsonResult UserProfile_ChangeAvatar()
        {
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images/avatar"), fileName);
                file.SaveAs(path);
                new AccountBcl().Change_Avatar(objUser.AccountId, fileName);
                return Json(new { result = true, message = "Thay đổi ảnh đại diện thành công" });
            }
            return Json(new { result = false, message = "Đã có lỗi xảy ra" });
        }

        [HttpPost]
        public JsonResult UserProfile_ChangePassword(string OldPassword, string NewPassword, string ReNewPassword)
        {
            try
            {
                AccountObject objAcc = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
                if (!new EncodeMD5().EncodingMD5(OldPassword).Equals(objAcc.Password))
                {
                    return Json(new { result = false, message = "Vui lòng kiểm tra lại mật khẩu hiện tại !" });
                }
                else
                {
                    if (NewPassword.Equals(ReNewPassword))
                    {
                        string NewPasswordMD5 = new EncodeMD5().EncodingMD5(NewPassword);
                        new AccountBcl().Change_Password(objAcc.AccountId, NewPasswordMD5);
                        return Json(new { result = true, message = "Thay đổi mật khẩu thành công !" });
                    }
                    else
                    {
                        return Json(new { result = false, message = "Vui lòng kiểm tra lại mật khẩu mới !" });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra" });
            }
        }

        public ActionResult UserProfile_ManageVideo(Guid AccountID)
        {
            ViewBag.AccountID = AccountID;
            AccountObject AccountNow = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]);
            if (AccountNow != null && AccountID == AccountNow.AccountId)
            {
                return View(new VideoPageBcl().GetByAccount(AccountID));
            }
            else
            {
                return View(new VideoPageBcl().GetForViewerByAccount(AccountID));
            }
        }
        public ActionResult UserProfile_ManageArticle(Guid AccountID)
        {
            ViewBag.AccountID = AccountID;
            AccountObject AccountNow = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]);
            if (AccountNow != null && AccountID == AccountNow.AccountId)
            {
                return View(new TechArticleBcl().getByAccount(AccountID));
            }
            else
            {
                return View(new TechArticleBcl().getForViewerByAccount(AccountID));
            }
        }

        public ActionResult UserProfile_ManagePlaylist(Guid AccountID)
        {
            ViewBag.AccountID = AccountID;
            AccountObject AccountNow = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]);
            return View(new VideoPageBcl().getSubCategoryByAccountID(AccountID));
        }

        #region CREATE SOMETHING
        //public ActionResult UserProfile_CreateVideo(string Username)
        //{
        //    ViewBag.Username = Username;
        //    AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
        //    if (objUser != null && objUser.Username == Username)
        //    {
        //        ViewBag.CategoryList = new VideoPageBcl().GetVideoCategoriesAll();
        //        ViewBag.Playlist = new VideoPageBcl().getSubCategoryByAccountID(objUser.AccountId);
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("UserProfile", "Account", new { Username = Username });
        //    }
        //}

        //[HttpPost]
        //public ActionResult UserProfile_CreateVideo(VideoObject objVideo)
        //{
        //    objVideo.VideoId = Guid.NewGuid();
        //    if (objVideo.VideoSubCategoryId == Guid.Empty)
        //    {
        //        objVideo.VideoSubCategoryId = null;
        //    }
        //    HttpPostedFileBase file = Request.Files[0];
        //    if (file.ContentLength > 0 && file.ContentType.Contains("image"))
        //    {
        //        String[] arrFilename = Path.GetFileName(file.FileName).Split('.');
        //        var extension = "." + arrFilename[arrFilename.Length - 1];
        //        var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
        //        var path = Path.Combine(Server.MapPath("~/Content/Galleries/Video/Thumbnails"), fileName);
        //        file.SaveAs(path);
        //        objVideo.VideoThumbnail = fileName;
        //    }
        //    objVideo.VideoCodeNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
        //    objVideo.TotalOfComments = 0;
        //    objVideo.TotalOfViews = 0;
        //    objVideo.TotalOfLikes = 0;
        //    objVideo.TotalOfDislikes = 0;
        //    objVideo.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
        //    objVideo.ModifiedTime = DateTime.Now;
        //    objVideo.IsApproved = false;
        //    objVideo.CreatedTime = DateTime.Now;
        //    objVideo.CreatedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
        //    objVideo.IsDeleted = false;
        //    new VideoPageBcl().InsertVideo(objVideo);
        //    string username = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).Username;
        //    return RedirectToAction("UserProfile", "Account", new { Username = username });
        //}

        //public ActionResult UserProfile_CreateTechArticle()
        //{
        //    ViewBag.TechCategoryList = new TechCategoryBcl().getElements();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult UserProfile_CreateTechArticle(TechArticleObject model)
        //{
        //    model.TechArticleId = Guid.NewGuid();
        //    HttpPostedFileBase file = Request.Files[0];

        //    if (file.ContentLength > 0 && file.ContentType.Contains("image"))
        //    {
        //        String[] arrFilename = Path.GetFileName(file.FileName).Split('.');
        //        var extension = "." + arrFilename[arrFilename.Length - 1];
        //        var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
        //        var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Articles"), fileName);
        //        file.SaveAs(path);
        //        model.ArticleImageLink = fileName;
        //    }
        //    model.TotalOfLikes = 0;
        //    model.TotalOfLinks = 0;
        //    model.TotalOfReplies = 0;
        //    model.TotalOfViews = 0;
        //    model.CreatedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
        //    model.LastRepliedTime = DateTime.Now;
        //    model.CreatedTime = DateTime.Now;
        //    model.ModifiedTime = DateTime.Now;
        //    model.isActive = false;
        //    model.isApproved = false;
        //    model.isDeleted = false;
        //    new TechArticleBcl().addElements(model, false);
        //    string username = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).Username;
        //    return RedirectToAction("UserProfile", "Account", new { Username = username });
        //}

        //public ActionResult UserProfile_CreateVideoSubCategory(string Username)
        //{
        //    ViewBag.Username = Username;
        //    AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
        //    if (objUser != null && objUser.Username == Username)
        //    {
        //        ViewBag.CategoryList = new VideoPageBcl().GetVideoCategoriesAll();
        //        ViewBag.Playlist = new VideoPageBcl().getSubCategoryByAccountID(objUser.AccountId);
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("UserProfile", "Account", new { Username = Username });
        //    }
        //}

        //[HttpPost]
        //public ActionResult UserProfile_CreateVideoSubCategory(VideoSubCategoryObject objSubCategory)
        //{
        //    objSubCategory.VideoSubCategoryID = Guid.NewGuid();
        //    objSubCategory.TotalVideo = 0;
        //    objSubCategory.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
        //    objSubCategory.ModifiedTime = DateTime.Now;
        //    objSubCategory.TotalVideo = 0;
        //    objSubCategory.IsDeleted = false;
        //    new VideoPageBcl().InsertVideoSubCategory(objSubCategory);
        //    string username = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).Username;
        //    return RedirectToAction("UserProfile", "Account", new { Username = username });
        //}
        #endregion
    }
}