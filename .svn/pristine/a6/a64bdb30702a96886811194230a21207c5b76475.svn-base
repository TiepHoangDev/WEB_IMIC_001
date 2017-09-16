using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Controllers
{
    public class ClassPageController : Controller
    {
        // GET: ClassPage
        public ActionResult Index(int? tcCodeNumber)
        {
            ViewBag.tcCodeNumber = tcCodeNumber;
            return View();
        }
        public ActionResult Index_CategorySearch()
        {
            return View(new TrainingBcl().GetCategoriesAll().OrderBy(n =>n.TCCodeNumber));
        }
        //public ActionResult ListClass(int pageIndex = 0, int pageSize = 9)
        //{
        //    var lisData =
        //        new OpenClassBcl().execOfGetAllElements()
        //            .OrderByDescending(x => x.ModifiedTime)
        //            .Skip(pageSize*pageIndex)
        //            .Take(pageSize);
        //    return View(lisData);
        //}
        
        public ActionResult ListClass(int pageIndex = 0, int pageSize = 18, int tcCodeNumber = 0)
        {
            if (tcCodeNumber == 0)
            {
                var lisAll =
                new OpenClassBcl().execOfGetAllElements()
                    .OrderByDescending(x => x.ModifiedTime)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
                return View(lisAll);
            }
            var lisData =
                new OpenClassBcl().GetAllElementsByTCCodeNumber(tcCodeNumber)
                    .OrderByDescending(x => x.ModifiedTime)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize);
            return View(lisData);
            
        }
        public ActionResult ListClass_Teacher(Guid courseId)
        {
            return View(new TrainingBcl().ExecOfGetExperiencerByCourseId(courseId));
        }

        // Ngocnb - 07112016 - Form Đăng ký khoá học
        public ActionResult Index_RegisterClass()
        {
            ViewBag.ListJob = new OpenClassBcl().GetJobsAll();
            return View();
        }
        [HttpPost]
        public ActionResult Index_RegisterClass(RegisterDetailObject objReg, Guid jobType)
        {
            objReg.Status = 0;
            objReg.IsSeen = false;
            objReg.CreatedTime = DateTime.Now;
            objReg.RegisterPerson.JobObjectId = jobType;
            objReg.RegisterDetailId = Guid.NewGuid();
            objReg.RegisterPerson.RegisterPersonId = Guid.NewGuid();

            new OpenClassBcl().InsertRegister(objReg);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetClassById(Guid classId)
        {
            OpenClassObject objClass = new OpenClassBcl().execOfGetElementsById(classId).FirstOrDefault();
            return Json(objClass.ContentPopup);
        }
        //Hàm check Recaptcha
        [HttpPost]
        public JsonResult RecaptchaCheck(string recaptcha)
        {
            //var response = Request["g-recaptcha-response"];
            var response = recaptcha;
            string secretKey = ConfigurationManager.AppSettings["ReCaptchaGoogleAppSecret"];
            var client = new WebClient();
            var result =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey,
                        response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
            if (status)
            {

                return Json(new { code = 1, mess = "Google reCaptcha validation success" });
            }
            else
            {
                //var error = (string)obj.SelectToken("error-codes")[0];
                return Json(new { code = 0, mess = "Google reCaptcha validation failed" });
            }

        }
    }
}