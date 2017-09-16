using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;

namespace WEB.IMIC.Controllers
{
    public class RecruitmentPageController : Controller
    {
        // GET: RecruitmentPage
        public ActionResult Index()
        {
            ViewBag.selectNganhNghe = new SelectList(new RecCareerBbl().GetAll(), "RecCareerId", "RecCareerName");
            ViewBag.selectKinhNghiem = new SelectList(new RecExperienceBbl().GetAll(), "RecExperienceId", "RecExperienceName");
            ViewBag.selectTrinhDo = new SelectList(new RecDipBbl().GetAll(), "RecDipId", "RecDip");
            ViewBag.selectDiaDiem = new SelectList(new RecruitmentLocationBbl().GetAll(), "RecLocationId", "RecLocationName");
            return View(new RecruitmentNewsletterBCL().getForPaging(1, "", 0, 10));
        }
    }
}