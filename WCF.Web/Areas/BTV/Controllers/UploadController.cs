using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessObjectsLayer.EntityObjects;
using System.IO;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;

namespace WCF.Web.Areas.BTV.Controllers
{
    public class UploadController : BaseController
    {
        // GET: Upload
        public ActionResult Index(int? status)
        {
            AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_USER];
            if(status == null)
            {
                ViewBag.Color = "grey";
                ViewBag.Header = "Bài viết của bạn";
            }
            else if(status.Value == StatusObject.LEVEL_0.StatusID)
            {
                ViewBag.Color = "yellow-gold";
                ViewBag.Header = "Bài viết mới";
            }
            else if (status.Value == StatusObject.LEVEL_1.StatusID)
            {
                ViewBag.Color = "green-jungle";
                ViewBag.Header = "Bài viết đã duyệt";
            }
            else if (status.Value == StatusObject.LEVEL_2.StatusID)
            {
                ViewBag.Color = "red-intense";
                ViewBag.Header = "Bài viết bị đánh trượt";
            }
            else if (status.Value == StatusObject.LEVEL_3.StatusID)
            {
                ViewBag.Color = "blue-madison";
                ViewBag.Header = "Bài viết vừa sửa";
            }
            return View(new TechArticleBcl().getByUser(objAccount.AccountId, status));
        }
        public ActionResult Article_Insert()
        {
            ViewBag.TechCategoryList = new TechCategoryBcl().getElements();
            return View(new TechArticleObject());
        }
        [HttpPost]
        public ActionResult Article_Insert(TechArticleObject model)
        {
            var isAdmin = false;
            AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_USER];
            if (objAccount.RoleId == 1 || objAccount.RoleId == 0)
            {
                isAdmin = true;
            }
            InitializeData(model);
            model.TechArticleId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files[0];

            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Articles"), fileName);
                file.SaveAs(path);
                model.ArticleImageLink = fileName;
            }

            new TechArticleBcl().addElements(model,isAdmin);
            return RedirectToAction("Index", "Upload");
        }
        [HttpGet]
        public ActionResult Article_Edit(int code)
        {
            TechArticleObject objTech = new TechArticleBcl().getByCodeNumerBTV(code);

            ViewBag.TechCategoryList = new TechCategoryBcl().getElements();
            return View(objTech);
        }
        [HttpPost]
        public ActionResult Article_Edit(TechArticleObject model)
        {

            HttpPostedFileBase file = Request.Files["Avatar"];
            //var fileName = Path.GetFileName(file.FileName);

            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Tech/Articles"), fileName);
                file.SaveAs(path);
                model.ArticleImageLink = fileName;
            }
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_USER]).AccountId;
            model.ModifiedTime = DateTime.Now;
            new TechArticleBcl().updateElements(model);
            new TechArticleBcl().updateStatus(model.TechArticleId, StatusObject.LEVEL_3.StatusID);
            return RedirectToAction("Index", "Upload");
        }
        public void InitializeData(TechArticleObject model)
        {
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_USER]).AccountId;
            model.isApproved = false;
            model.isActive = true;
            model.LastRepliedTime = DateTime.Now;
            model.LastReplier = ((AccountObject)Session[CommonConstants.SESSION_USER]).AccountId;
        
            model.CreatedTime = DateTime.Now;
            model.CreatedBy = ((AccountObject)Session[CommonConstants.SESSION_USER]).AccountId;
            model.ApprovedBy = null;
            model.ModifiedTime = DateTime.Now;
        }
        [HttpPost]
        public JsonResult Article_GetFailReason(Guid articleid)
        {
            TechStatusObject objStatus = new TechArticleBcl().getApprovalInfo(articleid);
            if (objStatus != null)
                return Json(new { name = objStatus.objCheckBy.FullName, time = objStatus.CheckedTime.ToString("dd/MM/yyyy hh:mm"), mess = objStatus.Message });
            return null;
        }
        public ActionResult Preview(int code)
        {
            TechArticleObject objArt = new TechArticleBcl().getByCodeNumerBTV(code);
            return View(objArt);
        }
     
        [ValidateInput(false)]
        public ActionResult DirectPreview(String title,String content,String category)
        {
            TechArticleObject objArt = new TechArticleObject();
            objArt.ArticleTitle = title;
            objArt.objTechCategory = new TechCategoryObject()
            {
                CategoryName = category
            };
            objArt.ContentArticle = content;
            objArt.CreatedTime = DateTime.Now;
            return View("~/Areas/BTV/Views/Upload/Preview_Modal.cshtml", objArt);
            
        }

        [HttpPost]
        public JsonResult CheckTitle(string title)
        {
            var lst = new TechArticleBcl().getByTitle(title);
            if (lst!=null)
            { 
                return Json(false);
            }
            else
            {
                return Json(true);
            }

        }
    }
}