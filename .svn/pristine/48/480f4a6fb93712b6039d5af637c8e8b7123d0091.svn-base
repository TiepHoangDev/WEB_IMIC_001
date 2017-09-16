using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.Web.Core;

namespace WCF.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WelcomePageObject objWC = WelcomePageBcl.ExecOfGetElements().FirstOrDefault();
            return View(objWC);
        }

        public ActionResult Maintenance()
        {
            
            return View();
        }
        public ActionResult Index_Menu(Guid WPId)
        {

            return View(WelcomePageBcl.ExecOfGetMenuCategoryByWelcomeId(WPId));
        }
        public ActionResult Warning(String message)
        {
            return View(message);
        }
    }
}