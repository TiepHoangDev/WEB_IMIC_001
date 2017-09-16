using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class OthersCategoryController : Controller
    {
        // GET: AdminCP/OthersCategory
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
        public ActionResult ListFaceBookUserLiked()
        {
            return View(new OthersBcl().GetAllFacebookUserLiked().OrderBy(x => x.RankVip));
        }
        public ActionResult FacebookUserLikeInsert()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FacebookUserLikeInsert(FacebookUserLikedObject obj, HttpPostedFileBase fileAvatar)
        {
            string fileName = Path.GetFileName(fileAvatar.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/Galleries/OtherCategory/FacebookUserLiked/"), fileName);
            fileAvatar.SaveAs(path);
            obj.FacebookAvatar = fileName;
            if (obj.RankVip == null)
            {
                obj.RankVip = 1000;
            }
            new OthersBcl().InsertFacebookUserLiked(obj);
            return RedirectToAction("ListFaceBookUserLiked");
        }
        public ActionResult FacebookUserLikeUpdate(Guid facebookUserLikedId)
        {
            return View(new OthersBcl().GetFacebookUserLikedById(facebookUserLikedId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FacebookUserLikeUpdate(FacebookUserLikedObject obj, HttpPostedFileBase fileAvatar)
        {
            if (fileAvatar != null)
            {
                string fileName = Path.GetFileName(fileAvatar.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Galleries/OtherCategory/FacebookUserLiked/"), fileName);
                fileAvatar.SaveAs(path);
                obj.FacebookAvatar = fileName;
            }
            
            
            if (obj.RankVip == null)
            {
                obj.RankVip = 1000;
            }
            new OthersBcl().UpdateFacebookUserLiked(obj);
            return RedirectToAction("ListFaceBookUserLiked");
        }

        [HttpPost]
        public ActionResult FacebookUserLikeDelete(Guid flId)
        {
            try
            {
                new OthersBcl().DeleteFacebookUserLiked(flId);
                return Json(new { Success = "True", Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }
            
        }
        [HttpPost]
        public ActionResult FacebookDeleteCheckAll(string[] idArr)
        {
            try
            {
                foreach (string id in idArr)
                {
                    
                    new OthersBcl().DeleteFacebookUserLiked(Guid.Parse(id));
                }
                
                return Json(new { Success = "True", Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }

        }
    }
}