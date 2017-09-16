using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    //[Authorize]
    public class BaseController : Controller
    {
        /*
         * Kiểm tra session tk của các page thuộc admin
         * Nếu muốn check session chỉ cần kết thừa controller này
         * NgocNB - 15102016
         */
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (session == null)
            {
                // Chưa đăng nhập => trang chủ khách hàng
                filterContext.Result = new RedirectToRouteResult(new
                   RouteValueDictionary(new { controller = "AccountAdmin", action = "Login", Area = "AdminCP" }));
            }
            else
            {
                if (session.RoleId == CommonConstants.ROLE_ADMIN || session.RoleId == CommonConstants.ROLE_SYSADMIN || session.RoleId==3)
                {
                    // Là tk admin, sysadmin thì được truy cập vào AdminCP

                }
                else
                {
                    // Không có quyền => trang chủ khách hàng
                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "IntroducePage", action = "Index", Area = "" }));
                }
            }
            base.OnActionExecuting(filterContext);
        }

        public ActionResult LogOut()
        {
            Session.Remove(CommonConstants.SESSION_ACCOUNT);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "HomeAdmin");
        }
    }
}