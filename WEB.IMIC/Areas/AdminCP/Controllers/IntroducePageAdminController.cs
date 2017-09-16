﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.BusinessControlLayer.Bcls;
using System.IO;
using System.Web.Routing;
using WCF.BusinessObjectsLayer.Commons;

namespace WEB.IMIC.Areas.AdminCP.Controllers
{
    public class IntroducePageAdminController : Controller
    {
        // GET: AdminCP/IntroducePageAdmin
        public ActionResult Index()
        {
            return View();
        }

        #region IntroduceBannerAdmin
        public ActionResult Manage_IntroduceBanner()
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceBanner());
        }

        public ActionResult IntroduceBanner_Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IntroduceBanner_Insert(IntroduceBannerObject objIntroduceBanner)
        {
            objIntroduceBanner.IntroduceBanerld = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images/gioi-thieu"), fileName);
                file.SaveAs(path);
                objIntroduceBanner.Bannerlmage = fileName;
            }
            objIntroduceBanner.ModifiedBy = Guid.Parse("5065268f-f180-4061-976e-bb74bab0dc2e");
            //objIntroduceBanner.ModifiedBy = ((UserObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objIntroduceBanner.ModifiedTime = DateTime.Now;
            objIntroduceBanner.IsDeleted = false;
            new IntroduceBcl().BannerInsert(objIntroduceBanner);
            return RedirectToAction("Manage_IntroduceBanner", "IntroducePageAdmin");
        }

        public ActionResult IntroduceBanner_Update(Guid IntroduceBannerId)
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceBannerById(IntroduceBannerId));
        }

       [HttpPost]
        public ActionResult IntroduceBanner_Update(IntroduceBannerObject objIntroduceBanner)
        {
           HttpPostedFileBase file = Request.Files[0];
           if (file.ContentLength > 0 && file.ContentType.Contains("image"))
           {
               var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
               var path = Path.Combine(Server.MapPath("~/Content/images/gioi-thieu"), fileName);
               file.SaveAs(path);
               objIntroduceBanner.Bannerlmage = fileName;
            }
           new IntroduceBcl().BannerUpdate(objIntroduceBanner);
           return RedirectToAction("Manage_IntroduceBanner", "IntroducePageAdmin");
        }

       [HttpPost]
       public JsonResult IntroduceBanner_Delete(Guid IntroduceBanerId)
       {
           try
           {
               new IntroduceBcl().BannerDelete(IntroduceBanerId);
           }
           catch (Exception e)
           {
               return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
           }
           return Json(new { result = true, message = "Xóa danh mục thành công!" });
       }

        #endregion

    }
}