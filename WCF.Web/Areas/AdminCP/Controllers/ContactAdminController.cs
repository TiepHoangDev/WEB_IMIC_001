using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.AdminCP.Controllers
{

    public class ContactAdminController : Controller
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
        // GET: AdminCP/ContactAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage_UnseenContact()
        {
            return View(new ContactPageBcl().GetUnseenContact());
        }

        public ActionResult Detail_Contact()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDetail_Contact(Guid ContactId)
        {
            ContactObject objContact = new ContactPageBcl().GetById(ContactId);
            return Json(objContact.ContentContact);
        }

        [HttpPost]
        public JsonResult MarkAsRead(Guid ContactId)
        {
            try
            {
                new ContactPageBcl().MarkAsRead(ContactId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "An error has occured during data transfer" });
            }
            return Json(new { result = true });
        }

        public ActionResult Manage_AllContact()
        {
            return View(new ContactPageBcl().GetAll());
        }
    }
}