using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;

namespace WEB.IMIC.Controllers
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
            var Slide = new IntroduceBcl().ExecOfGetIntroduceBanner();
            return View(Slide);
        }

        public ActionResult Index_EduProgram() 
        {           
            return View(new IntroduceBcl().ExecOfGetIntroduceEduProgram());
        }

        public ActionResult Index_Experiencers()
        {
            return View(new IntroduceBcl().ExecOfGetAllExperiencer());
        }

        public ActionResult Index_Missions()
        {
            return View(new IntroduceBcl().ExecOfGetIntroduceMission());
        }
    }
}