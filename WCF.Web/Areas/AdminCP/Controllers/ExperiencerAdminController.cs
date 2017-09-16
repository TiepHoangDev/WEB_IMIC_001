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
    public class ExperiencerAdminController : Controller
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
        // GET: AdminCP/Experiencer
        public ActionResult Index()
        {
            return View(new IntroduceBcl().ExecOfGetAllExperiencer().OrderBy(x => x.RankToShowIntroduce));
        }

        // Ngocnb 02112016 - Them chuyen gia
        public ActionResult ExperiencerInsert()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ExperiencerInsert(ExperiencerObject objEx, HttpPostedFileBase fileAvatar)
        {
            if (fileAvatar != null)
            {
                // Lưu avatar vào host
                string fileName = Path.GetFileName(fileAvatar.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Galleries/Introduce/Experiencer/"),
                    fileName);
                fileAvatar.SaveAs(path);
                
                objEx.ExperiencerImage = "Introduce/Experiencer/" + fileName;
            }

            new ExperiencerBcl().ExperiencerInsert(objEx);


            return RedirectToAction("Index");
        }

    }
}