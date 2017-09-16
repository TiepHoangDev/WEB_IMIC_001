using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;

namespace WEB.IMIC.Controllers
{
    public class OpenClassPageController : Controller
    {
        // GET: OpenClassPage
        public ActionResult Index()
        {
            ViewBag.Index_OpenClass = new OpenClassBcl().execOfGetAllElements();
            return View(new OpenClassPageBbl().GetAll());
        }
    }
}