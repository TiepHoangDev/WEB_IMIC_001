using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class RecruitmentAnController : BaseController
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
                else if (session.RoleId != CommonConstants.ROLE_ADMIN && session.RoleId != CommonConstants.ROLE_SYSADMIN )
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "AccountAdmin", action = "Login", Area = "AdminCP" }));
            }


            base.OnActionExecuting(filterContext);
        }
        //
        // GET: /AdminCP/RecruitmentAn/
#region Banner

        public ActionResult ManageBanner()
        {
            var lstbanner = new RecruitmentBannerBcl().GetAll();
            return View(lstbanner);
        }

        public ActionResult BannerInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BannerInsert(RecruitmentBannerObject model)
        {
            model.HomeBannerId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Banner"), fileName);
                file.SaveAs(path);
                model.ImageLink = fileName;
            }
            new RecruitmentBannerBcl().BannerInsert(model);
            return RedirectToAction("ManageBanner", "RecruitmentAn");
        }

        public ActionResult BannerUpdate(Guid id)
        {
            var obj = new RecruitmentBannerBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult BannerUpdate(RecruitmentBannerObject model)
        {
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Banner"), fileName);
                file.SaveAs(path);
                model.ImageLink = fileName;
            }
            new RecruitmentBannerBcl().BannerUpdate(model);
            return RedirectToAction("ManageBanner", "RecruitmentAn");
        }

        [HttpPost]
        public JsonResult BannerDelete(Guid id)
        {
            new RecruitmentBannerBcl().BannerDelete(id);
            return Json(new {rs = "ok"});
        }
#endregion

#region Galleries

        public ActionResult ManageGallery()
        {
            var lstGallery = new RecruitmentGalleryImageBcl().GetAll();
            return View(lstGallery);
        }

        public ActionResult GalleryInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GalleryInsert(RecruitmentGalleryImageObject model)
        {
            model.GalleryImageId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {

                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Gallery"), fileName);
                file.SaveAs(path);
                model.Image_Link = fileName;
            }
            new RecruitmentGalleryImageBcl().GalleryInsert(model);

            return RedirectToAction("ManageGallery", "RecruitmentAn");
        }

        public ActionResult GalleryUpdate(Guid id)
        {
            var obj = new RecruitmentGalleryImageBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult GalleryUpdate(RecruitmentGalleryImageObject model)
        {
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {

                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Gallery"), fileName);
                file.SaveAs(path);
                model.Image_Link = fileName;
            }
            new RecruitmentGalleryImageBcl().GalleryUpdate(model);

            return RedirectToAction("ManageGallery", "RecruitmentAn");
        }

        public JsonResult GalleryDelete(Guid id)
        {
            new RecruitmentGalleryImageBcl().GalleryDelete(id);
            return Json(new {rs = "ok"});
        }

#endregion

#region Job

        public ActionResult ManageJob()
        {
            var lstJob = new JobBcl().GetAll();
            return View(lstJob);
        }

        public ActionResult JobInsert()
        {
           
            List<NewsletterTagObject> lstTag = new NewsletterTagBCL().getElements();
            ViewBag.Tag = lstTag;
            return View();
        }

        [HttpPost]
        public ActionResult JobInsert(ReJobObject model)
        {
            model.JobId = Guid.NewGuid();

            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Job"), fileName);
                file.SaveAs(path);
                model.JobImage_Link = fileName;
            }

            new JobBcl().JobInsert(model);
            return RedirectToAction("ManageJob");
        }

        public ActionResult JobUpdate(Guid id)
        {
            List<NewsletterTagObject> lstTag = new NewsletterTagBCL().getElements();
            ViewBag.Tag = lstTag;
            var obj = new JobBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult JobUpdate(ReJobObject model)
        {
            HttpPostedFileBase file = Request.Files["Avatar"];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Job"), fileName);
                file.SaveAs(path);
                model.JobImage_Link = fileName;
            }

            new JobBcl().JobUpdate(model);
            return RedirectToAction("ManageJob");
        }

        [HttpPost]
        public JsonResult JobDelete(Guid id)
        {
            new JobBcl().JobDelete(id);
            return Json(new {rs = "ok"});
        }
#endregion


#region Tittle

        public ActionResult SetupTitle()
        {
            var obj = new RecruitmentTitleBcl().GetAll();
            return View(obj);
        }

        [HttpPost]
        public ActionResult SetupTitle(RecruitmentTitleObject model)
        {
            new RecruitmentTitleBcl().RecruimentTitleUpdate(model);
            ModelState.AddModelError("","Chỉnh sửa thành công");
            return RedirectToAction("SetupTitle");
        }
#endregion

    }
}