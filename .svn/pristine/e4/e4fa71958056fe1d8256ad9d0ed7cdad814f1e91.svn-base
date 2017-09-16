using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WCF.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "lesson",
              url: "kien-thuc",
              defaults: new { controller = "LessonPage", action = "Index_new" }
          );

            routes.MapRoute(
             name: "lesson-detail",
             url: "kien-thuc/{code}/{name}.html",
             defaults: new { controller = "LessonPage", action = "Lesson_Detail", code = UrlParameter.Optional, name = UrlParameter.Optional }
         );
            routes.MapRoute(
          name: "lesson-search",
          url: "tim-kiem-kien-thuc",
          defaults: new { controller = "LessonPage", action = "Search",query=UrlParameter.Optional,tag=UrlParameter.Optional}
      );

          //  routes.MapRoute(
          //    name: "lessondetail",
          //    url: "kien-thuc/{code}/{name}.html",
          //    defaults: new { controller = "LessonPage", action = "Detail", code = UrlParameter.Optional, name = UrlParameter.Optional }
          //);
            routes.MapRoute(
            name: "recruitindex",
            url: "tuyen-dung.html",
            defaults: new { controller = "RecruitPage", action = "Index" }
        );
            routes.MapRoute(
              name: "recruit",
              url: "tuyen-dung/{code}/{name}.html",
              defaults: new { controller = "RecruitPage", action = "Detail", code = UrlParameter.Optional, name = UrlParameter.Optional }
          );

            //routes.MapRoute(
            //    name: "tech-category",
            //    url: "danh-muc-cong-nghe/{catid}/{catname}.html",
            //    defaults: new
            //    {
            //        controller = "TechPage",
            //        action = "Index",
            //        catid = UrlParameter.Optional,
            //        catname = UrlParameter.Optional
            //    }
            //);
            routes.MapRoute(
                name: "tech-index",
                url: "cong-nghe.html",
                defaults: new
                {
                    controller = "TechPage",
                    action = "Index"
                }
            );
            routes.MapRoute(
                name: "tech-detail",
                url: "cong-nghe/{codeNumber}/{PostName}.html",
                defaults: new
                {
                    controller = "TechPage",
                    action = "TechDetail",
                    codeNumber = UrlParameter.Optional,
                    PostName = UrlParameter.Optional
                }
            );

            routes.MapRoute(
             name: "NewsDetail",
             url: "tin-tuc-cong-nghe/{newsCodeNumber}/{postName}.html",
             defaults: new
             {
                 controller = "NewsPage",
                 action = "NewsDetail",
                 newsCodeNumber = UrlParameter.Optional,
                 postName = UrlParameter.Optional
             }
            );

            routes.MapRoute(
                name: "News",
                url: "tin-tuc-cong-nghe/{newsCategoryId}",
                defaults: new
                {
                    controller = "NewsPage",
                    action = "Index",
                    newsCategoryId = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Education",
                url: "lap-trinh-do-hoa/{categoryId}",
                defaults: new
                {
                    controller = "TrainingPage",
                    action = "Index",
                    categoryId = UrlParameter.Optional
                }
            );
            routes.MapRoute(
             name: "EduDetail",
             url: "lap-trinh-do-hoa/{courseCodeNumber}/{postName}.html",
             defaults: new
             {
                 controller = "TrainingPage",
                 action = "DetailCourse",
                 courseCodeNumber = UrlParameter.Optional,
                 postName = UrlParameter.Optional
             }
            );
            routes.MapRoute(
                name: "class",
                url: "khai-giang-khoa-hoc",
                defaults: new
                {
                    controller = "ClassPage",
                    action = "Index",

                }
            );
            routes.MapRoute(
                name: "classCourse",
                url: "khai-giang-khoa-hoc/{courseId}",
                defaults: new
                {
                    controller = "TrainingPage",
                    action = "DetailCourseByCourseId",
                    courseId = UrlParameter.Optional

                }
            );
            routes.MapRoute(
                name: "Introduce",
                url: "gioi-thieu-imic",
                defaults: new
                {
                    controller = "IntroducePage",
                    action = "Index"
                }
            );
            //Video Page
            routes.MapRoute(
                name: "video-category",
                url: "danh-muc-video/{vcCodeNumber}/{catname}",
                defaults: new
                {
                    controller = "VideoPage",
                    action = "Index",
                    vcCodeNumber = UrlParameter.Optional,
                    catname = UrlParameter.Optional
                }
            );

            //Video Detail
            routes.MapRoute(
                name: "video-detail",
                url: "chi-tiet-video/{videoCodeNumber}/{videoname}",
                defaults: new
                {
                    controller = "VideoPage",
                    action = "VideoDetail",
                    videoCodeNumber = UrlParameter.Optional,
                    videoname = UrlParameter.Optional
                }
            );

            //Liên hệ
            routes.MapRoute(
                name: "contact",
                url: "lien-he.html",
                defaults: new
                {
                    controller = "ContactPage",
                    action = "Index",
                }
            );

            //Gallery
            routes.MapRoute(
                name: "StudentGalleryPage",
                url: "hoc-vien-imic",
                defaults: new
                {
                    controller = "StudentGalery",
                    action = "Index"

                }
            );

            //User Profile
            routes.MapRoute(
                name: "user-profile",
                url: "trang-ca-nhan/{username}",
                defaults: new
                {
                    controller = "Account",
                    action = "UserProfile",
                    username = UrlParameter.Optional,
                }
            );

            routes.MapRoute(
                name: "user-settings",
                url: "cai-dat-thong-tin/{username}",
                defaults: new
                {
                    controller = "Account",
                    action = "UserProfile_Settings",
                    username = UrlParameter.Optional,
                }
            );

            routes.MapRoute(
                name: "user-create-video",
                url: "dang-video-moi/{username}",
                defaults: new
                {
                    controller = "Account",
                    action = "UserProfile_CreateVideo",
                    username = UrlParameter.Optional,
                }
            );

            routes.MapRoute(
                name: "user-create-playlist",
                url: "tao-playlist-moi/{username}",
                defaults: new
                {
                    controller = "Account",
                    action = "UserProfile_CreateVideoSubCategory",
                    username = UrlParameter.Optional,
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
              name: "video",
              url: "imic-academy.html",
              defaults: new
              {
                  controller = "VideoPage",
                  action = "Index_new"
                  
              }
          );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "Maintenance",
            //        id = UrlParameter.Optional
            //    }
            //);

        }
    }
}
