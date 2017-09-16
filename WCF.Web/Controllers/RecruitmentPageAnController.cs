﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;

namespace WCF.Web.Controllers
{
    public class RecruitmentPageAnController : Controller
    {
        //
        // GET: /RecruitmentAn/
       

        public ActionResult Banner()
        {
            var lstBanner = new RecruitmentBannerBcl().GetAll();
            return PartialView(lstBanner);
        }

        public ActionResult Job()
        {
            var lstJob = new JobBcl().GetAll();
            return PartialView(lstJob);
        }
        public ActionResult Gallery()
        {
            var lstGallery = new RecruitmentGalleryImageBcl().GetAll();
            return PartialView(lstGallery);
        }

        public ActionResult Company()
        {
            var lstConpany= new RecruitmentCompanyBCL().Get();
            return PartialView(lstConpany);
        }
	}
}