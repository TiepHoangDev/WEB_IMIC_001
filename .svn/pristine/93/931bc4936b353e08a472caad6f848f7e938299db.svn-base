using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.Web.Core;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class AccountAdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var session = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (session != null)
            {
                //if (session.RoleId != 0 && session.RoleId != 1 )
                //{
                //    if (!filterContext.ActionDescriptor.ActionName.Equals("Login"))
                //        filterContext.Result = new RedirectToRouteResult(new
                //            RouteValueDictionary(new { controller = "IntroducePage", action = "Index", Area = "" }));
                //}
                if (session.RoleId == 3)
                {
                    if (!filterContext.ActionDescriptor.ActionName.Equals("Login"))
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "HomeAdmin", action = "Index", Area = "AdminCP" }));
                }
                else if (session.RoleId != CommonConstants.ROLE_ADMIN && session.RoleId != CommonConstants.ROLE_SYSADMIN)
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "AccountAdmin", action = "Login", Area = "AdminCP" }));
            }


            base.OnActionExecuting(filterContext);
        }
        /*
         * Xử lý nghiệp vụ tài khoản admin
         * NgocNB- 28092016
         */

        /*
         * Trang chủ quản lý tài khoản
         * NgocNB - 17102016
         */
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginObject objLogin)
        {
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

                    return RedirectToAction("Index","HomeAdmin");
                }
                else if (rs == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");

                }
                else if (rs == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                    //return Json(new { rs = -2 });
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                    //return Json(new { rs = -3 });
                }
            }

            return View(objLogin);
            //return Redirect(Request.UrlReferrer + "");
        }


        public ActionResult ManageUser()
        {
            AccountObject objAcc = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];

            if (objAcc == null)
            {
                return RedirectToAction("Login");
            }
            else if (objAcc.RoleId == 0)
            {
                return View(new AccountBcl().getElement());
            }
            var lisAccount = new AccountBcl().getElement().Where(x => x.RoleId != 0 & x.RoleId != 1 || x.AccountId == objAcc.AccountId);
            return View(lisAccount);
            //List<RoleObject> lstRole = new RoleBcl().getElement();
            //ViewBag.ListRole = lstRole;
            //return View(new AccountBcl().getElement());
            //ViewBag.id = id;
            //if (id == -1)
            //{
            //    return View(new AccountBcl().getElement());
            //}
            //else
            //{
            //    return View(new AccountBcl().getByRoleID(id));
            //}

        }
        [HttpGet]
        public ActionResult UserInsert()
        {
            List<RoleObject> lstRole = new RoleBcl().getElement();
            RoleObject objRole = lstRole.Single(x => x.RoleId.Equals(0));
            lstRole.Remove(objRole);
            ViewBag.ListRole = lstRole;
            return View();
        }
        [HttpPost]
        public ActionResult UserInsert(AccountObject model)
        {
            model.AccountId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/images/avatar"), fileName);
                file.SaveAs(path);
                model.ImageAvatar = fileName;
            }
            model.Password = new EncodeMD5().EncodingMD5(model.Password);
            model.LastLoginTime = DateTime.Now.ToString();
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            model.ModifiedTime = DateTime.Now.ToString();
            model.IsDeleted = false;
            model.IsActived = true;
            new AccountBcl().addElements(model);
            return RedirectToAction("ManageUser", "AccountAdmin");
        }
        [HttpGet]
        public ActionResult UserEdit(Guid AccountId)
        {
            AccountObject objAccount = new AccountBcl().getElementById(AccountId);
            List<RoleObject> lstRole = new RoleBcl().getElement();
            RoleObject objRole = lstRole.Single(x => x.RoleId.Equals(0));
            lstRole.Remove(objRole);
            ViewBag.ListRole = lstRole;
            return View(objAccount);
        }
        [HttpPost]
        public ActionResult UserEdit(AccountObject model)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/images/avatar"), fileName);
                file.SaveAs(path);
                model.ImageAvatar = fileName;
            }
            if (!string.IsNullOrEmpty(model.newPassword))
            {
                model.Password = new EncodeMD5().EncodingMD5(model.newPassword);
            }

            model.LastLoginTime = DateTime.Now.ToString();
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            model.ModifiedTime = DateTime.Now.ToString();
            model.IsDeleted = false;
            model.IsActived = true;
            new AccountBcl().updateElements(model);
            return RedirectToAction("ManageUser", "AccountAdmin");
        }

        public JsonResult DeleteUser(Guid id)
        {
            new AccountBcl().deleteElement(id);
            return Json(new { rs = "ok" });
        }
    }



    //    public ActionResult ListUser()
    //    {
    //        return System.Web.UI.WebControls.View(new AccountBcl().getAll());               
    //    }

    //    // Add User
    //    public ActionResult Insert_User()
    //    {
    //        AccountObject objUser = new AccountObject();
    //                objUser.AccountId = Guid.NewGuid();

    //                return View(objUser);

    //    }

    //    [HttpPost]
    //    public ActionResult Insert_User(AccountObject objUser)
    //    {

    //        objUser.IsDeleted = false;
    //        HttpPostedFileBase file = Request.Files["Avatar"];
    //        if (file != null && file.ContentType.Contains("image"))
    //        {
    //            MemoryStream target = new MemoryStream();
    //            file.InputStream.CopyTo(target);
    //            byte[] data = target.ToArray();
    //            objUser.ImageAvatar = data;

    //        }
    //        else objUser.ImageAvatar = null;
    //        if (!new AccountBcl().checkUserName(objUser.UserName))
    //        {
    //            new AccountBcl().CreateAccount(objUser);
    //            return RedirectToAction("ListUser", "User");
    //        }
    //        ModelState.AddModelError("", "This Account already exists, please change username.");
    //        return View();
    //    }

    //    //Update User
    //    public ActionResult Update_User(Guid UserId)
    //    {
    //        AccountObject objUser = new AccountBcl().getById(UserId);

    //        return System.Web.UI.WebControls.View(objUser);

    //    }

    //    [HttpPost]
    //    public ActionResult Update_User(AccountObject objUser)
    //    {

    //        objUser.IsDeleted = false;

    //        HttpPostedFileBase file = Request.Files["Avatar"];
    //        if (file != null && file.ContentType.Contains("image"))
    //        {
    //            MemoryStream target = new MemoryStream();
    //            file.InputStream.CopyTo(target);
    //            byte[] data = target.ToArray();
    //            objUser.UAvatar = data;

    //        }
    //        new AccountBcl().updateUser(objUser);
    //        return RedirectToAction("Index", "User");
    //    }

    //    [HttpPost]
    //    public JsonResult Delete_User(Guid UserId)
    //    {
    //        try
    //        {
    //            new UserBcl().deleteUser(UserId);
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine("Message: " + e.Message);
    //            Console.WriteLine("Inner Exception: " + e.InnerException);
    //            Console.WriteLine("Time Stamp: " + DateTime.Now);
    //            return Json(new { result = false, Message = "An error has occured during data transfer" });
    //        }
    //        return Json(new { result = true });
    //    }

}
