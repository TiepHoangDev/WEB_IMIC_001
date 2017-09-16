using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.Class.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Class/Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (AccountObject)Session[CommonConstants.SESSION_USER];
            if (session == null || (session.RoleId != CommonConstants.ADMIN && session.RoleId != CommonConstants.SUPER_ADMIN
                && session.RoleId != CommonConstants.TEACHER || session.RoleId != CommonConstants.STUDENT))
            {
                // Chưa đăng nhập => trang chủ khách hàng
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Class" }));
            }

            base.OnActionExecuting(filterContext);
        }
	}
}