using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.BusinessControlLayer.Bcls;

namespace WCF.Web.Controllers
{
    public class MarketingController : Controller
    {
        /*
         * XỬ lý ảnh quảng cáo, khung facebook,...
         * NgocNB - 05102016
         */

        /*
         * Ảnh quảng cáo
         * NgocNB - 05102016
         */
        public ActionResult ImageAds()
        {
            return View();
        }

        /*
         * Khung Facebook like
         * NgocNB - 05102016
         */
        public ActionResult FacebookLikeBox()
        {
            var lstFb = new OthersBcl().GetAllFacebookUserLiked();
            return View(lstFb);
        }
    }
}