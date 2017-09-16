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
    public class TrainingPageController : Controller
    {
        /*
         * Trang đào tạo
         * NgocNB - 05102016
         */

        /*
         * Trang chủ đào tạo
         * NgocNB - 05102016
         */
        
        public ActionResult Index(Guid? categoryId)
        {
            ViewBag.Banner = new TrainingBcl().GetBannersToShow().FirstOrDefault();
            ViewBag.categoryId = categoryId;
            return View(new TrainingBcl().GetTrainingPage());
        }
        public ActionResult Index_test()
        {
            return View();
        }
        /*
         * Slide banner
         * NgocNB - 05102016
         */
        public ActionResult Index_Banner()
        {
            return PartialView(new TrainingBcl().GetBannersToShow());
        }

        /*
         * Các chuyên mục
         * NgocNB - 05102016
         */
        public ActionResult Index_Category()
        {
            return View(new TrainingBcl().GetCategoriesAll().OrderBy(n=>n.TCCodeNumber));
        }

        /*
         * Danh sách khoá học
         * NgocNB - 05102016
         */
        //public ActionResult ListCourse()
        //{
        //    return View(new TrainingBcl().ExecOfGetAllCourse());
        //}

        /*
         * Chi tiết khoá học
         * NgocNB - 06102016
         */
        public ActionResult ListCourse(Guid? categoryId, int pageSize = 9, int pageIndex = 0)
        {

            if (categoryId == null || categoryId.Equals(Guid.Parse("68dc1bcd-9a5e-433c-8f79-e44ed5ff28fc")))
            {
                var lisTemp =
                    new TrainingBcl().ExecOfGetAllCourse()
                        .OrderBy(n=>n.RankVip)
                        .ThenByDescending(n => n.ModifiedTime)
                        .Skip(pageSize*pageIndex)
                        .Take(pageSize);
                return View(lisTemp);
            }

            else
            {
                var lisTemp =
                    new TrainingBcl().ExecOfGetAllCourseByTrainingCategoryId((Guid)categoryId)
                        .OrderBy(n => n.RankVip)
                        .ThenByDescending(n => n.ModifiedTime)
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize);
                return View(lisTemp);
                
            }
            
        }
        public ActionResult DetailCourse(int courseCodeNumber)
        {
            CourseObject objCourse = new CourseObject();
            objCourse = new TrainingBcl().ExecOfGetCourseObjectByCodeNumber(courseCodeNumber).FirstOrDefault();
            List<TagObject> lstTag = new TagBcl().getTagByPostId(objCourse.CourseId);
            ViewBag.ListTag = lstTag;
            //return View(TrainingBcl.ExecOfGetCourseObjectByCourseId(courseId));
            return View(objCourse);
        }
        public ActionResult DetailCourseByCourseId(Guid courseId)
        {
            CourseObject objCourse = new CourseObject();
            objCourse = new TrainingBcl().ExecOfGetCourseObjectByCourseId(courseId).FirstOrDefault();

            //return View(TrainingBcl.ExecOfGetCourseObjectByCourseId(courseId));
            return View("DetailCourse", objCourse);
        }

        /*
            Thông tin của box bên dưới từng khóa học
            MinhHA - 11/10/2016
         */
        public ActionResult DetailCourse_BoxBelow(Guid courseId)
        {
            return View(new TrainingBcl().ExecOfGetAllBoxBelowByCourseId(courseId));
        }
        /*
            Thông tin của các công nghệ của từng khóa học
            MinhHA - 11/10/2016
         */
        public ActionResult DetailCourse_Technology(Guid courseId)
        {
            return View(new TrainingBcl().ExecOfGetAllTechnologyByCourseId(courseId));
        }
        /*
            Lấy các dự án mẫu của từng khóa học
            MinhHA - 11/10/2016
         */
        public ActionResult DetailCourse_DemoProject(Guid courseId)
        {
            var data =
                new TrainingBcl().ExecOfGetAllDemoProjectByCourseId(courseId)
                    .Where(n => n.DemoType == true && n.TabType == false);
            return View(data);
        }
        /*
            Lấy video hướng dẫn trong từng khóa học
            MinhHA - 11/10/2016
         */
        public ActionResult DetailCourse_LearnByVideo(Guid courseId)
        {
            var data =
                new TrainingBcl().ExecOfGetAllDemoProjectByCourseId(courseId)
                    .Where(n => n.DemoType == false && n.TabType == false);
            return View(data);
        }
        /*
            Lấy các khóa học liên quan đến  khóa học hiện tại
            MinhHA - 11/10/2016
         */
        public ActionResult DetailCourse_IntroduceVideo(Guid courseId)
        {
             var data =
                new TrainingBcl().ExecOfGetAllDemoProjectByCourseId(courseId)
                    .Where(n => n.DemoType == false && n.TabType == true)
                    .FirstOrDefault();
            return View(data);
        }
        public ActionResult DetailCourse_RelatedCourse(Guid trainingCatId, Guid courseId)
        {
            List<CourseObject> lisTemp =
                new TrainingBcl().ExecOfGetAllCourseByTrainingCategoryId(trainingCatId)
                    .OrderBy(n => n.RankVip)
                    .ThenByDescending(n => n.ModifiedTime)
                    .ToList();
            List<CourseObject> lisCourse = new List<CourseObject>();
            {
                foreach (CourseObject item in lisTemp)
                {
                    if (item.CourseId != courseId)
                    {
                        lisCourse.Add(item);
                    }
                }
            }
            return View(lisCourse);
        }


        public ActionResult ListCourse_Teacher(Guid courseId)
        {
            return View(new TrainingBcl().ExecOfGetExperiencerByCourseId(courseId));
        }

        // Ngocnb - 04122016 - Đăng ký khoá học
        public ActionResult DetailCourse_RegisterCourse()
        {
            ViewBag.ListJob = new OpenClassBcl().GetJobsAll();
            return View();
        }

        [HttpPost]
        public ActionResult DetailCourse_RegisterCourse(RegisterDetailObject objReg, Guid jobType)
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