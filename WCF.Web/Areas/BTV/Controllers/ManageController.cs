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
    public class ManageController : BaseController
    {
        // GET: Manage
        public ActionResult Index(Guid? userid , DateTime? begin ,DateTime? end )
        {
            ViewBag.uploader = new AccountBcl().getByRoleID(4);
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
            if (objUser.RoleId == CommonConstants.ADMIN || objUser.RoleId == CommonConstants.SUPER_ADMIN)
            {
                if (userid == null & begin == null & end == null)
                {
                    return View(new TechArticleBcl().getElements());
                }
                else if (begin == null || end == null)
                {
                    return View(new TechArticleBcl().getElements().Where(x => x.CreatedBy == userid));
                }
                else  if (userid == null )
               {
                   return View(new TechArticleBcl().getElements().Where(x=>x.CreatedTime>=begin && x.CreatedTime<=end));
               }
               
              
                return View(new TechArticleBcl().getElements().Where(x=>x.CreatedBy == userid && (x.CreatedTime>=begin && x.CreatedTime<=end)));
            }
            return RedirectToAction("Warning", "BTVAccount");
        }
        public ActionResult Unapproved()
        {
            ViewBag.uploader = new AccountBcl().getByRoleID(4);
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
            if (objUser.RoleId == CommonConstants.ADMIN || objUser.RoleId == CommonConstants.SUPER_ADMIN)
            {
                return View(new TechArticleBcl().getUnapprovedArticle().Where(x=>x.objTS.StatusID == 0||x.objTS.StatusID == 3));
            }
            return RedirectToAction("Warning", "BTVAccount");
        }
        public ActionResult approvedFail()
        {
            ViewBag.uploader = new AccountBcl().getByRoleID(4);
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
            if (objUser.RoleId == CommonConstants.ADMIN || objUser.RoleId == CommonConstants.SUPER_ADMIN)
            {
                return View(new TechArticleBcl().getUnapprovedArticle().Where(x=>x.objTS.StatusID==2));
            }
            return RedirectToAction("Warning", "BTVAccount");
        }
        public JsonResult Article_Delete(Guid id)
        {
            try
            {
                AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
                if (objUser != null && (objUser.RoleId == CommonConstants.ADMIN || objUser.RoleId == CommonConstants.SUPER_ADMIN))
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
        [HttpGet]
        public ActionResult Article_Edit(int code)
        {
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
            if (objUser.RoleId == CommonConstants.ADMIN || objUser.RoleId == CommonConstants.SUPER_ADMIN)
            {
                TechArticleObject objTech = new TechArticleBcl().getByCodeNumerBTV(code);

                ViewBag.TechCategoryList = new TechCategoryBcl().getElements();
                return View(objTech);
            }
            return RedirectToAction("Warning", "BTVAccount");
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
            model.isApproved = true;
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_USER]).AccountId;
            model.ModifiedTime = DateTime.Now;
            new TechArticleBcl().updateElements(model);
            return RedirectToAction("Index", "Manage");
        }
        public JsonResult Article_ApproveGroup(String articlelist)
        {
            try
            {
                AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
                if (objUser != null && (objUser.RoleId == CommonConstants.ADMIN || objUser.RoleId == CommonConstants.SUPER_ADMIN))
                {
                    new TechArticleBcl().approveGroup(articlelist, objUser.AccountId, DateTime.Now);
                }
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "Lỗi xảy ra trong quá trình truyền dữ liệu" });
            }
            return Json(new { result = true });

        }
        public JsonResult Article_Approve(Guid id)
        {
            try
            {
                AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
                if (objUser != null && (objUser.RoleId == CommonConstants.ADMIN || objUser.RoleId == CommonConstants.SUPER_ADMIN))
                {
                    new TechArticleBcl().approveArticle(id, objUser.AccountId, DateTime.Now);
                }
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "Lỗi xảy ra trong quá trình truyền dữ liệu" });
            }
            return Json(new { result = true });
        }
        [HttpPost]
        public ActionResult Article_Redo()
        {
            Guid id = Guid.Parse(Request.Form["articleid"] + "");
            String message = Request.Form["message"];
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
            if (objUser != null && (objUser.RoleId == CommonConstants.ADMIN || objUser.RoleId == CommonConstants.SUPER_ADMIN))
            {
                new TechArticleBcl().unapproveArticle(id, objUser.AccountId, DateTime.Now, message);
            }
            return RedirectToAction("Unapproved", "Manage");
        }

        public ActionResult RuleWriter()
        {
            return View(new RuleWritingBcl().GetAll());

        }

        public ActionResult RuleUpdate()
        {
            return View(new RuleWritingBcl().GetAll());
        }

        [HttpPost]
        public ActionResult RuleUpdate(RuleWritingObject obj)
        {
            new RuleWritingBcl().RuleUpdate(obj);
            return View(obj);
        }


#region  Source

        public ActionResult SourceUpdate()
        {
            return View(new SourcePageBcl().GetAll());
        }

        [HttpPost]
        public ActionResult SourceUpdate(SourcePageObject obj)
        {
            new SourcePageBcl().SourcePageUpdate(obj);
            return View(obj);
        }

        public ActionResult SourcePage()
        {
            return View(new SourcePageBcl().GetAll());
        }
#endregion 
    }
}