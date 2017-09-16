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
    public class IntroduceAdminController : Controller
    {
        /*
         * Trang admin giới thiệu
         * Ngocnb - 31102016
         */
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
        public ActionResult Index()
        {
            return View();
        }

        #region Banner
        /*
         * Slider banner trang giới thiệu
         * Ngocnb - 31102016
         */
        public ActionResult BannerList()
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceBanner());
        }

        /*
         * THêm 1 banner mới
         * Ngocnb - 31102016
         */
        public ActionResult BannerInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BannerInsert(IntroduceBannerObject obj, HttpPostedFileBase fileAvatar)
        {
            // Lưu avatar vào host
            string fileName = Path.GetFileName(fileAvatar.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/Galleries/Introduce/Banners/"), fileName);
            fileAvatar.SaveAs(path);

            // Đóng gói đối tượng objBaner
            obj.Bannerlmage = fileName;

            // Gọi Bcl insert
            new IntroduceBcl().BannerInsert(obj);

            return RedirectToAction("BannerList");
        }

        /*
         * Sửa banner
         * Ngocnb - 31102016
         */
        public ActionResult BannerEdit(Guid bannerId)
        {
            var listBanner = new IntroduceBcl().ExecOfGetIntroduceBanner();
            var banner = (from q in listBanner where q.IntroduceBanerld.Equals(bannerId) select q).FirstOrDefault();

            return View(banner);
        }

        [HttpPost]
        public ActionResult BannerEdit(IntroduceBannerObject obj, HttpPostedFileBase fileAvatar)
        {
            // Lưu avatar vào host
            if (fileAvatar != null)
            {
                string fileName = Path.GetFileName(fileAvatar.FileName);
                if (!obj.Bannerlmage.Equals(fileName))
                {
                    // nếu avatar mới khác avatar cũ thì lưu vào
                    string path = Path.Combine(Server.MapPath("~/Content/Galleries/Introduce/Banners/"), fileName);
                    fileAvatar.SaveAs(path);
                }

                // Đóng gói đối tượng objBaner
                obj.Bannerlmage = fileName;
            }
            
            // Gọi Bcl insert
            new IntroduceBcl().BannerUpdate(obj);

            return RedirectToAction("BannerList");
        }

        [HttpPost]
        public ActionResult Delete(Guid bannerId)
        {
            try
            {
                new IntroduceBcl().BannerDelete(bannerId);
                return Json(new { Success = true, Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = false, Message = "Xóa dữ liệu thất bại" });
            }
        }

        [HttpPost]
        public ActionResult DeleteCheckAll(string[] idArr)
        {
            try
            {
                foreach (string id in idArr)
                {
                    new IntroduceBcl().BannerDelete(Guid.Parse(id));
                }

                return Json(new { Success = true, Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = false, Message = "Xóa dữ liệu thất bại" });
            }
        }
        #endregion Banner

        #region 3 Missions

        public ActionResult MissionList()
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceMission());
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult MissionEdit(List<IntroduceMissionObject> listMission )
        {
            foreach (var objM in listMission)
            {
                new IntroduceBcl().MissionEdit(objM);
            }
            return RedirectToAction("MissionList");
        }

        #endregion
        #region 6 Services
        public ActionResult ServiceList()
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceService());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ServiceEdit(List<IntroduceServiceObject> listService, List<HttpPostedFileBase> fileAvatars )
        {
            for(int i=0; i<listService.Count();i++) 
            {
                if (fileAvatars[i] != null)
                {
                    string fileName = Path.GetFileName(fileAvatars[i].FileName);
                    if (!listService[i].ServiceImage.Equals(fileName))
                    {
                        // nếu avatar mới khác avatar cũ thì lưu vào
                        string path = Path.Combine(Server.MapPath("~/Content/Galleries/Introduce/Services/"), fileName);
                        fileAvatars[i].SaveAs(path);
                    }

                    // Đóng gói đối tượng objBaner
                    listService[i].ServiceImage = fileName;
                }
                new IntroduceBcl().ServiceUpdate(listService[i]);
            }
            return RedirectToAction("ServiceList");
        }
        #endregion
        #region PageInformation
        public ActionResult PageInfo()
        {
            return View(new IntroduceBcl().ExecOfGetIntroducePage().FirstOrDefault());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PageInfoUpdate(IntroducePageObject objP)
        {

            new IntroduceBcl().PageUpdate(objP);
            
            return RedirectToAction("PageInfo");
        }
        #endregion

    }
}