using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class BannerAdminController : Controller
    {
        //
        // GET: /AdminCP/BannerAdmin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageBanner()
        {
            return View(new BannerBcl().GetAll());
        }

        public ActionResult BannerInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BannerInsert(BannerObject obj)
        {
            obj.BannerId = Guid.NewGuid();
            obj.FlagImage = false;
            if (Request.Form["localfile"] != null)
            {
                obj.FlagImage = true;
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/Banner/"), fileName);
                    file.SaveAs(path);
                    obj.ImageLink = fileName;
                }
            }
            new BannerBcl().Insert(obj);
            return RedirectToAction("ManageBanner");
        }

        public ActionResult BannerUpdate(Guid id)
        {
            return View(new BannerBcl().GetById(id));
        }
        [HttpPost]
        public ActionResult BannerUpdate(BannerObject obj)
        {
            obj.FlagImage = false;
            if (Request.Form["localfile"] != null)
            {
                obj.FlagImage = true;
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/Banner/"), fileName);
                    file.SaveAs(path);
                    obj.ImageLink = fileName;
                }
            }
            new BannerBcl().Update(obj);
            return RedirectToAction("ManageBanner");
        }

        [HttpPost]
        public JsonResult BannerDelete(Guid id)
        {
            new BannerBcl().Delete(id);
            return Json(new {rs = "ok"});
        }

	}
}