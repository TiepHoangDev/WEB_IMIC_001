using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class UserAdminController : Controller
    {
        // GET: AdminCP/UserAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}