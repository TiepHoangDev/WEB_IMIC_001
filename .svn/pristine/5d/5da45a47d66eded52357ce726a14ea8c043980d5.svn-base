using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class TechAdminController : BaseController
    {
        // GET: AdminCP/TechAdmin

        public ActionResult Index()
        {
            if (((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]) == null)
                return RedirectToAction("Index", "TechPage", new { area = "" });
            return View();
        }
        #region CATEGORY
        public ActionResult ManageCategory()
        {
            if (((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]) == null)
                return RedirectToAction("Index", "TechPage", new { area = "" });
            return View(new TechCategoryBcl().getElements());
        }
        [HttpGet]
        public ActionResult Category_Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Category_Insert(TechCategoryObject model)
        {
            HttpPostedFileBase file = Request.Files[0];

            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Categories"), fileName);
                file.SaveAs(path);
                model.CategoryAvatar = fileName;
            }
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            model.ModifiedTime = DateTime.Now;
            model.TechCategoryId = Guid.NewGuid();
            new TechCategoryBcl().addElement(model);
            return RedirectToAction("ManageCategory", "TechAdmin");
        }
        [HttpGet]
        public ActionResult Category_Edit(Guid? id)
        {
            Guid x;
            if (id != null && Guid.TryParse(id + "", out x))
            {
                TechCategoryObject model = new TechCategoryBcl().getElementById(id.Value);
                return View(model);
            }
            return RedirectToAction("ManageCategory", "TechAdmin");
        }
        [HttpPost]
        public ActionResult Category_Edit(TechCategoryObject model)
        {
            HttpPostedFileBase file = Request.Files[0];

            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Categories"), fileName);
                file.SaveAs(path);
                model.CategoryAvatar = fileName;
            }
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            model.ModifiedTime = DateTime.Now;
            new TechCategoryBcl().updateElement(model);

            return RedirectToAction("ManageCategory", "TechAdmin");
        }
        public JsonResult Category_Delete(Guid id)
        {
            try
            {
                AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
                if (objUser != null)
                {
                    new TechCategoryBcl().deleteElement(id);
                }
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "Lỗi xảy ra trong quá trình truyền dữ liệu" });
            }
            return Json(new { result = true });
        }

        #endregion

        #region ARTICLE
        [HttpGet]
        public ActionResult Article_Insert()
        {
            ViewBag.TechCategoryList = new TechCategoryBcl().getElements();
            AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objAccount.RoleId == CommonConstants.ROLE_ADMIN || objAccount.RoleId == CommonConstants.ROLE_SYSADMIN)
                ViewBag.EditorList = new TechArticleBcl().getEditorAccount();
            ViewBag.TagList = new ArticleTagBcl().getElements();
            return View(new TechArticleObject());
        }
        [HttpPost]
        public ActionResult Article_Insert(TechArticleObject model, string[] tagbox, string[] newtaglist)
        {
            InitializeData(model);
            model.TechArticleId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files[0];

            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                String[] arrFilename = Path.GetFileName(file.FileName).Split('.');
                var extension = "." + arrFilename[arrFilename.Length - 1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Articles"), fileName);
                file.SaveAs(path);
                model.ArticleImageLink = fileName;
            }
            AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objAccount.RoleId == CommonConstants.ROLE_ADMIN || objAccount.RoleId == CommonConstants.ROLE_SYSADMIN)
                new TechArticleBcl().addElements(model, true);
            else
            {
                model.CreatedBy = objAccount.AccountId;
                new TechArticleBcl().addElements(model, false);
            }
            ArticleTagBcl tagBcl = new ArticleTagBcl();
            ArticleTagDetailBcl detailBcl = new ArticleTagDetailBcl();
            List<String> lstTag = tagbox.ToList();
            List<String> lstNewTagC = new List<string>();
            if (newtaglist != null)
                lstNewTagC = newtaglist.ToList();
            foreach (var item in lstNewTagC)
            {
                ArticleTagObject objTag = new ArticleTagObject();
                objTag.ArticleTagId = Guid.NewGuid();
                objTag.TagName = item;
                objTag.isDeleted = false;
                objTag.TotalOfArticle = 0;
                tagBcl.addElement(objTag);
                lstTag.Add(objTag.ArticleTagId + "");
            }
            foreach (var item in lstTag)
            {
                Guid tagid = Guid.Parse(item);
                detailBcl.addElement(new ArticleTagDetailObject()
                {
                    TagDetailId = Guid.NewGuid(),
                    ArticleId = model.TechArticleId,
                    isDeleted = false,
                    ArticleTagId = tagid
                });
            }

            return RedirectToAction("ManageArticle", "TechAdmin");
        }
        [HttpGet]
        public ActionResult Article_Edit(Guid id)
        {
            TechArticleObject objTech = new TechArticleBcl().getElementByID(id);
            ViewBag.TechCategoryList = new TechCategoryBcl().getElements();
            ViewBag.TagDetailList = new ArticleTagDetailBcl().getByArticle(id);
            ViewBag.TagList = new ArticleTagBcl().getElements();
            return View(objTech);
        }
        [HttpPost]
        public ActionResult Article_Edit(TechArticleObject model, string[] tagbox, string[] newtaglist)
        {

            HttpPostedFileBase file = Request.Files["Avatar"];
            //var fileName = Path.GetFileName(file.FileName);

            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                String[] arrFilename = Path.GetFileName(file.FileName).Split('.');
                var extension = "." + arrFilename[arrFilename.Length - 1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Articles"), fileName);
                file.SaveAs(path);
                model.ArticleImageLink = fileName;
            }
            ArticleTagBcl tagBcl = new ArticleTagBcl();
            ArticleTagDetailBcl detailBcl = new ArticleTagDetailBcl();
            List<String> lstTag = tagbox.ToList();

            //Xoa het tag bi bo tick
            List<ArticleTagDetailObject> lstOldTagC = detailBcl.getByArticle(model.TechArticleId);
            foreach (var item in lstOldTagC)
            {
                int pos = lstTag.FindIndex(x => Guid.Parse(x) == item.ArticleTagId);
                if (pos == -1)
                    detailBcl.deleteElement(item.TagDetailId);
                else lstTag.RemoveAt(pos);
            }

            //Them cac tag vua duoc tick
            foreach(var item in lstTag)
            {
                detailBcl.addElement(new ArticleTagDetailObject()
                {
                    ArticleId = model.TechArticleId,
                    TagDetailId = Guid.NewGuid(),
                    ArticleTagId = Guid.Parse(item),
                    isDeleted = false
                });
            }
            //Them cac tag moi
            List<String> lstNewTag = new List<string>();
            if (newtaglist != null)
                lstNewTag = newtaglist.ToList();
            foreach (var item in lstNewTag)
            {
                ArticleTagObject objTag = new ArticleTagObject();
                objTag.ArticleTagId = Guid.NewGuid();
                objTag.TagName = item;
                objTag.isDeleted = false;
                objTag.TotalOfArticle = 0;
                tagBcl.addElement(objTag);
                detailBcl.addElement(new ArticleTagDetailObject()
                   {
                       ArticleId = model.TechArticleId,
                       TagDetailId = Guid.NewGuid(),
                       ArticleTagId = objTag.ArticleTagId,
                       isDeleted = false
                   });

            }
            


            AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            model.ModifiedBy = objAccount.AccountId;
            model.ModifiedTime = DateTime.Now;
            new TechArticleBcl().updateElements(model);

            return RedirectToAction("ManageArticle", "TechAdmin");
        }
        public JsonResult Article_Delete(Guid id)
        {
            try
            {
                AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
                if (objUser != null)
                {
                    new TechArticleBcl().deleteElement(id);
                }
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "Lỗi xảy ra trong quá trình truyền dữ liệu" });
            }
            return Json(new { result = true });
        }
        public void InitializeData(TechArticleObject model)
        {

            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            model.isApproved = true;
            model.isActive = true;
            model.LastRepliedTime = DateTime.Now;
            model.LastReplier = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            model.TotalOfUsers = 0;
            model.CreatedTime = DateTime.Now;
            if (model.CreatedBy == null)
                model.CreatedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            model.ApprovedBy = null;
            model.ModifiedTime = DateTime.Now;
        }
        public ActionResult Article_Unapproved()
        {
            return View("Article_Unapproved", new TechArticleBcl().getUnapprovedArticle());
        }
        //public ActionResult ApproveArticle(String articlelist)
        //{
        //    List<Guid> lstArticle = articlelist.Split(',').Select(x => Guid.Parse(x)).ToList();
        //    foreach (var item in lstArticle)
        //    {
        //        new TechArticleBcl().approveArticle(item);
        //    }
        //    return null;
        //}
        public ActionResult ManageArticle()
        {
            if (((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]) == null)
                return RedirectToAction("Index", "TechPage", new { area = "" });
            return View(new TechArticleBcl().getElements());
        }
        #endregion

        //TAG
        #region TAG
        public ActionResult ManageTag()
        {
            return View(new ArticleTagBcl().getElements());
        }
        public ActionResult Tag_Insert()
        {
            return View(new ArticleTagObject());
        }
        [HttpPost]
        public ActionResult Tag_Insert(ArticleTagObject objTag)
        {
            ArticleTagBcl tagBcl = new ArticleTagBcl();
            if (!tagBcl.isNameExisted(objTag.TagName))
            {
                objTag.isDeleted = false;
                objTag.ArticleTagId = Guid.NewGuid();
                new ArticleTagBcl().addElement(objTag);
                return RedirectToAction("ManageTag", "TechAdmin");
            }
            ModelState.AddModelError("", "Tên của Tag bị trùng, xin mời nhập tên khác");
            return View(new ArticleTagObject());

        }
        public JsonResult CheckTag(string q)
        {
            if (new ArticleTagBcl().isNameExisted(q.TrimEnd()))
                return Json(new { rs = "fail" });
            return Json(new { rs = Guid.NewGuid() });
        }
        public ActionResult Tag_Update(Guid tagid)
        {
            return View(new ArticleTagBcl().getByID(tagid));
        }
        [HttpPost]
        public ActionResult Tag_Update(ArticleTagObject objTag)
        {
            ArticleTagBcl tagBcl = new ArticleTagBcl();
            if (!tagBcl.isNameExisted(objTag.TagName))
            {
                new ArticleTagBcl().updateElement(objTag);
                return RedirectToAction("ManageTag", "TechAdmin");
            }
            ModelState.AddModelError("", "Tên của Tag bị trùng, xin mời nhập tên khác");
            return View(objTag);

        }
        #endregion

#region Banner
        public ActionResult ManageBanner()
        {
            var lstbanner = new TechBannerBcl().BannerGetAll();
            return View(lstbanner);
        }

        public ActionResult BannerInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BannerInsert(TechBannerObject model)
        {
            model.TechBannerId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Banners"), fileName);
                file.SaveAs(path);
                model.ImageLink = fileName;
            }
            new TechBannerBcl().BannerInsert(model);
            return RedirectToAction("ManageBanner", "TechAdmin");
        }

        public ActionResult BannerUpdate(Guid id)
        {
            var obj = new TechBannerBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult BannerUpdate(TechBannerObject model)
        {
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Banners"), fileName);
                file.SaveAs(path);
                model.ImageLink = fileName;
            }
            new TechBannerBcl().BannerUpdate(model);
            return RedirectToAction("ManageBanner", "TechAdmin");
        }

        [HttpPost]
        public JsonResult BannerDelete(Guid id)
        {
            new TechBannerBcl().BannerDelete(id);
            return Json(new { rs = "ok" });
        }
#endregion

    #region TechLogo

        public ActionResult ManageLogo()
        {
            var lstLogo = new TechLogoBcl().GetAll();
            return View(lstLogo);
        }

        public ActionResult LogoInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogoInsert(TechLogoObject model)
        {
            model.TehLogoId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Logo"), fileName);
                file.SaveAs(path);
                model.TechLogoImage = fileName;
            }
            new TechLogoBcl().Insert(model);
            return RedirectToAction("ManageLogo");
        }

        public ActionResult LogoUpdate(Guid id)
        {
            var obj = new TechLogoBcl().GetById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult LogoUpdate(TechLogoObject model )
        {
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Logo"), fileName);
                file.SaveAs(path);
                model.TechLogoImage = fileName;
            }
            new TechLogoBcl().Update(model);
            return RedirectToAction("ManageLogo");

        }

        [HttpPost]
        public JsonResult LogoDelete(Guid id)
        {
            new TechLogoBcl().Delete(id);
            return Json(new {rs = "ok"});
        }
    #endregion

    #region TechLink

        public ActionResult ManageTechLink()
        {
            var lstLink = new TechLinkBcl().GetAll();
            return View(lstLink);
        }

        public ActionResult TechLinkInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TechLinkInsert(TechLinkObject model)
        {
            model.TechLinkId = Guid.NewGuid();

            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/TechLink"), fileName);
                file.SaveAs(path);
                model.TechLinkImage = fileName;
            }
            new TechLinkBcl().Insert(model);
            return RedirectToAction("ManageTechLink");
        }

        public ActionResult TechLinkUpdate(Guid id)
        {
            var obj = new TechLinkBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult TechLinkUpdate(TechLinkObject model)
        {
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/TechLink"), fileName);
                file.SaveAs(path);
                model.TechLinkImage = fileName;
            }
            new TechLinkBcl().Update(model);
            return RedirectToAction("ManageTechLink");
        }

        [HttpPost]
        public JsonResult TechLinkDelete(Guid id)
        {
            new TechLinkBcl().Delete(id);
            return Json(new {rs = "ok"});
        }
    #endregion

#region TechRight

        public ActionResult ManageTechRight()
        {
            var lstTechRight = new TechRightBcl().GetAll();
            return View(lstTechRight);
        }

        public ActionResult TechRightInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TechRightInsert(TechRightObject model)
        {
            model.TechRightId = Guid.NewGuid();
            model.IsShowed = false;
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/TechRight"), fileName);
                file.SaveAs(path);
                model.TechRightImage = fileName;
            }
            new TechRightBcl().Insert(model);
            return RedirectToAction("ManageTechRight");
        }

        public ActionResult TechRightUpdate(Guid id)
        {
            var obj = new TechRightBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult TechRightUpdate(TechRightObject model)
        {
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/TechRight"), fileName);
                file.SaveAs(path);
                model.TechRightImage = fileName;
            }
            new TechRightBcl().Update(model);
            return RedirectToAction("ManageTechRight");
        }

        [HttpPost]
        public JsonResult TechRightDelete(Guid id)
        {
            new TechRightBcl().Delete(id);
            return Json(new {rs = "ok"});
        }
#endregion
    }
}