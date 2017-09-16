using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Controllers
{
    public class StudentGaleryController : Controller
    {
        // GET: StudentGalery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index_ListStudent(int pageIndex = 0, int pageSize = 10)
        {
            var lisData
            = new StudentGaleryBcl().getElements()
            .Skip(pageSize * pageIndex)
            .Take(pageSize);
             return View(lisData);
        }
    }
}