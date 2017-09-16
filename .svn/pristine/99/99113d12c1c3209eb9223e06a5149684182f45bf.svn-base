using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using System.IO;
using System.Web.Routing;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class RecruitmentAdminController : BaseController
    {
        
        // GET: AdminCP/RecruitmentAdmin
        public ActionResult Index()
        {
            return View();
        }
        #region TAG
        public ActionResult ManageTag()
        {
            return View(new NewsletterTagBCL().getElements());
        }
        public ActionResult Tag_Insert()
        {
            return View(new NewsletterTagObject());
        }
        [HttpPost]
        public ActionResult Tag_Insert(NewsletterTagObject objTag)
        {
            NewsletterTagBCL tagBcl = new NewsletterTagBCL();
            if (tagBcl.CheckNameExisted(objTag.NewsletterTagName))
            {
                ModelState.AddModelError("", "Tên tag đã bị trùng");
                return View(objTag);
            }

            objTag.NewsletterTagId = Guid.NewGuid();
            tagBcl.addElement(objTag);
            return RedirectToAction("ManageTag", "RecruitmentAdmin");
        }
        public ActionResult Tag_Update(Guid id)
        {
            return View(new NewsletterTagBCL().getElementByID(id));
        }
        [HttpPost]
        public ActionResult Tag_Update(NewsletterTagObject objTag)
        {
            NewsletterTagBCL tagBcl = new NewsletterTagBCL();
            if (tagBcl.CheckNameExisted(objTag.NewsletterTagName))
            {
                ModelState.AddModelError("", "Tên tag đã bị trùng");
                return View(objTag);
            }
            tagBcl.updateElement(objTag);
            return RedirectToAction("ManageTag", "RecruitmentAdmin");
        }

        public JsonResult Tag_Delete(Guid id)
        {
            // new NewsTagBCL().deleteElement(id);
            return Json(new { rs = "ok" });
        }
        public JsonResult CheckTag(string q)
        {
            if (new NewsletterTagBCL().CheckNameExisted(q.TrimEnd()))
                return Json(new { rs = "fail" });
            return Json(new { rs = Guid.NewGuid() });
        }
        #endregion

        #region COMPANY
        public ActionResult ManageCompany()
        {
            return View(new RecruitmentCompanyBCL().Get());
        }
        public ActionResult Company_Insert()
        {
            return View(new RecruitmentCompanyObject());
        }
        [HttpPost]
        public ActionResult Company_Insert(RecruitmentCompanyObject model)
        {

            model.CompanyId = Guid.NewGuid();
            model.IsApproved = true;
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Recruit"), fileName);
                file.SaveAs(path);
                model.CompanyLogo = fileName;
            }
            new RecruitmentCompanyBCL().addElement(model);
            return RedirectToAction("ManageCompany", "RecruitmentAdmin");
        }
        public ActionResult Company_Update(Guid id)
        {
            RecruitmentCompanyObject objCom = new RecruitmentCompanyBCL().getElementByID(id);
            return View(objCom);
        }
        [HttpPost]
        public ActionResult Company_Update(RecruitmentCompanyObject model)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Recruit"), fileName);
                file.SaveAs(path);
                model.CompanyLogo = fileName;
            }
            new RecruitmentCompanyBCL().updateElement(model);
            return RedirectToAction("ManageCompany", "RecruitmentAdmin");
        }
        [HttpPost]
        public JsonResult CompanyDelete(Guid id)
        {
            new RecruitmentCompanyBCL().deleteElement(id);
            return Json(new {rs = "ok"});
        }
        #endregion

        #region NEWSLETTER
        public ActionResult ManageNews()
        {
            return View(new RecruitmentNewsletterBCL().getElements().Where(x=>x.isApproved==true));
        }

        public ActionResult ManageNewsUnApproved()
        {
            return View(new RecruitmentNewsletterBCL().getElements().Where(x => x.isApproved == false));
        }
        public ActionResult News_Insert()
        {
            ViewBag.CompanyList = new RecruitmentCompanyBCL().Get();
            ViewBag.TagList = new NewsletterTagBCL().getElements();
            return View(new RecruitmentNewsletterObject());
        }
        [HttpPost]
        public ActionResult News_Insert(RecruitmentNewsletterObject model, string[] tag, string[] newtag)
        {
            var objAcc = ((AccountObject) Session[CommonConstants.SESSION_ACCOUNT]);
            model.NewsletterId = Guid.NewGuid();
            model.ApprovedBy = objAcc.AccountId;
            if (objAcc.RoleId == 1 || objAcc.RoleId == 0)
            {
                model.isApproved = true;
            }
            else
            {
                model.isApproved = false;
            }
            model.ModifiedTime = DateTime.Now;
            model.ModifiedBy = objAcc.AccountId;
            model.ImageServerFlag = false;
            if (Request.Form["localfile"] != null)
            {
                model.ImageServerFlag = true;
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/Recruit"), fileName);
                    file.SaveAs(path);
                    model.ImageLink = fileName;
                }
            }
            new RecruitmentNewsletterBCL().addElement(model);
            InsertTag(model, tag, newtag);

            if (model.isApproved == true)
            {
                return RedirectToAction("ManageNews", "RecruitmentAdmin");
            }
            else
            {
                return RedirectToAction("ManageNewsUnApproved", "RecruitmentAdmin");
            }
        }

        public ActionResult Recruit_Detail(long code)
        {
            RecruitmentNewsletterObject objNews = new RecruitmentNewsletterBCL().getByCode(code);
            List<NewsletterTagDetailObject> lstTag = new NewsletterTagDetailBCL().getByNew(objNews.NewsletterId);
            ViewBag.TagList = lstTag;

           
            ViewBag.Title = objNews.Title;
            return View(objNews);
        }
        public ActionResult News_Update(Guid id)
        {
            ViewBag.CompanyList = new RecruitmentCompanyBCL().Get();
            ViewBag.TagList = new NewsletterTagBCL().getElements();
            ViewBag.DetailList = new NewsletterTagDetailBCL().getByNew(id);
            RecruitmentNewsletterObject objCom = new RecruitmentNewsletterBCL().getByID(id);
            return View(objCom);
        }
        [HttpPost] 
        public ActionResult News_Update(RecruitmentNewsletterObject model, string[] tag, string[] newtag)
        {
            var objAcc = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]);
            model.ModifiedTime = DateTime.Now;
            model.ModifiedBy = objAcc.AccountId;
            model.ImageServerFlag = false;
            model.isDeleted = false;
            if (objAcc.RoleId == 3)
            {
                model.isApproved = false;
            }
            if (Request.Form["localfile"] != null)
            {
                model.ImageServerFlag = true;
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/Recruit"), fileName);
                    file.SaveAs(path);
                    model.ImageLink = fileName;
                }
            }
            else
            {
                var imagelink = Request.Form["ImageLink"];
                model.ImageLink = imagelink;
            }

            new RecruitmentNewsletterBCL().updateElement(model);
            InsertTag(model, tag, newtag);
            if (model.isApproved == true)
            {
                return RedirectToAction("ManageNews", "RecruitmentAdmin");
            }
            else
            {
                return RedirectToAction("ManageNewsUnApproved", "RecruitmentAdmin");
            }
            
        }
        public void InsertTag(RecruitmentNewsletterObject model, string[] tag, string[] newtag)
        {
            NewsletterTagBCL tagBCL = new NewsletterTagBCL();
            NewsletterTagDetailBCL detailBCL = new NewsletterTagDetailBCL();
            detailBCL.deleteAll(model.NewsletterId);
            if (tag != null)
            {
                foreach (var item in tag)
                {
                    detailBCL.addElement(new NewsletterTagDetailObject()
                    {
                        NewsletterId = model.NewsletterId,
                        NewsletterTagDetailId = Guid.NewGuid(),
                        NewsletterTagId = Guid.Parse(item)
                    });
                }
            }
            if (newtag != null)
            {
                foreach (var item in newtag)
                {
                    if (item.Length > 0)
                    {
                        NewsletterTagObject objTag = new NewsletterTagObject();
                        objTag.NewsletterTagId = Guid.NewGuid();
                        objTag.NewsletterTagName = item;
                        objTag.TotalOfNewsletter = 0;
                        tagBCL.addElement(objTag);
                        detailBCL.addElement(new NewsletterTagDetailObject()
                        {
                            NewsletterId = model.NewsletterId,
                            NewsletterTagDetailId = Guid.NewGuid(),
                            NewsletterTagId = objTag.NewsletterTagId
                        });
                    }
                }
            }
        }

        public JsonResult ApproveNewsLetter(Guid id)
        {
            new RecruitmentNewsletterBCL().ApproveNewsLetter(id);
            return Json(new {rs = true});
        }
        public JsonResult News_Delete(Guid nid)
        {
            new RecruitmentNewsletterBCL().deleteElement(nid);
            return Json(new { rs = "ok" });
        }
        public ActionResult ContentTemplate()
        {
            return View();
        }
        public ActionResult ContactInfoTemplate()
        {
            return View();
        }
        public ActionResult EmployerInfoTemplate()
        {
            return View();
        }
        #endregion
    }
}