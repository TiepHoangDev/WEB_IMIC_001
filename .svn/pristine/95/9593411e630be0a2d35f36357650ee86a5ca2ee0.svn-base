using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;

namespace WCF.Web.Controllers
{
    public class IntroducePageController : Controller
    {
        // GET: IntroducePage
        public ActionResult Index()
        {
            return View(new IntroduceBcl().ExecOfGetIntroducePage().FirstOrDefault());
        }

        public ActionResult Index_Slide()
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceBanner());
        }

        public ActionResult Index_Services()
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceService());
        }
        public ActionResult Index_Missions()
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceMission());
        }
        public ActionResult Index_Experiencers()
        {
            return View(new IntroduceBcl().ExecOfGetAllExperiencer());
        }
        public ActionResult Index_Partners()
        {
            return View(new IntroduceBcl().ExecOfGetIntroducePartner());
        }
    }
}