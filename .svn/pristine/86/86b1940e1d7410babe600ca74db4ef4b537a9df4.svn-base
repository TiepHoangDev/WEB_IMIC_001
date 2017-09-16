using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class TrainingAdminController : Controller
    {
        public byte MenuId = 3;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var session = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (session != null)
            {
                //if (session.RoleId != 0 && session.RoleId != 1 )
                //{
                //    if (!filterContext.ActionDescriptor.ActionName.Equals("Login"))
                //        filterContext.Result = new RedirectToRouteResult(new
                //            RouteValueDictionary(new { controller = "IntroducePage", action = "Index", Area = "" }));
                //}
                if (session.RoleId == 3)
                {
                    if (!filterContext.ActionDescriptor.ActionName.Equals("Login"))
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "HomeAdmin", action = "Index", Area = "AdminCP" }));
                }
                else if (session.RoleId != CommonConstants.ROLE_ADMIN && session.RoleId != CommonConstants.ROLE_SYSADMIN)
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "AccountAdmin", action = "Login", Area = "AdminCP" }));
            }


            base.OnActionExecuting(filterContext);
        }
        /*
         * Xử lý nghiệp vụ về đào tạo: Trang hiển thị (text, banner); Chuyên mục khoá học; Các khoá học; Dự án mẫu;...
         * NgocNB- 03102016
         */

        /*
         * Trang index
         * NgocNB - 03102016
         */
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PageInfo()
        {
            return View(new TrainingBcl().GetTrainingPage());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PageInfoEdit(TrainingPageObject objTP)
        {

            new TrainingBcl().TrainingPageUpdate(objTP);

            return RedirectToAction("PageInfo");
        }
        /*
         * QL bannner
         * NgocNB - 03102016
         */
        public ActionResult Component_Banner()
        {

            ViewBag.Title = "Ảnh trình chiếu";
            return View();
        }

        /*
         * QL các chuyên mục khoá học
         * NgocNB - 03102016
         */
        public ActionResult Component_TrainingCategory()
        {
            ViewBag.Title = "Chuyên mục khoá học";
            return View();
        }

        /*
         * QL các dự án mẫu
         * NgocNB - 03102016
         */
        public ActionResult Component_DemoProject()
        {

            ViewBag.Title = "Dự án mẫu";
            return View();
        }

        /*
         * QL các công nghệ dùng trong khoá học
         * NgocNB - 03102016
         */
        public ActionResult Component_CourseTech()
        {

            ViewBag.Title = "Công nghệ trong khoá học";
            return View();
        }

        /*
         * QL các hộp thông tin thêm ở dưới mỗi khoá học
         * NgocNB - 03102016
         */
        public ActionResult Component_BoxBelow()
        {

            ViewBag.Title = "Hộp thông tin bổ sung";
            return View();
        }

        /*
         * Thêm thông tin cơ bản khoá học
         * NgocNB- 06102016
         */
        public ActionResult CourseInsert()
        {
            ViewBag.Title = "Đăng khoá học mới";
            ViewBag.ListCategory = from x in new TrainingBcl().GetCategoriesAll().OrderBy(x => x.TCCodeNumber)
                                   where x.TCCodeNumber != 0
                                   select x;
            ViewBag.ListBoxBellow = new TrainingBcl().GetBoxBellowAll();
//            ViewBag.ListDemoProject = new TrainingBcl().GetDemoProjectAll().OrderBy(n=>n.ProjectName);
            ViewBag.ListCourseTech = new TrainingBcl().GetTechnologyAll();
            ViewBag.ListExperiencer = new TrainingBcl().GetExperiencerAll();
            ViewBag.ListTag = new TagBcl().getElementByMenuId(MenuId);
            return View();
        }

        /*
         * Partial view hình ảnh/video dự án/video giới thiệu
         * NgocNB - 27112016
         */

        public ActionResult DemoProjectSelects(string[] lisDPId = null)
        {
            
            return View(new TrainingBcl().GetDemoProjectAll());
        }


        /*
         * Post thêm thông tin khoá học
         * NgocNB - 10102016
         */

        [HttpPost, ValidateInput(false)]
        public ActionResult CourseInsert(CourseObject objCourse, HttpPostedFileBase fileAvatar,
            string[] lisBoxBelowIdSelected, string[] lisDemoProjectIdSelected, string[] lisCourseTechnologyIdSelected, string[] lisExperiencerIdSelected, string[] oldtag, string[] newtaglist)
        {
            //HttpContext.Server.ScriptTimeout = 900000; // Timeout tải file quá lâu

            // Lưu file avatar vào host
            if (objCourse.RankVip == null)
            {
                objCourse.RankVip = 1000;
            }
            if (fileAvatar == null)
            {
                // Client không tải file avatar
                // coding
            }
            else
            {
                // Lưu avatar vào host
                string fileName = Path.GetFileName(fileAvatar.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Galleries/Training/CourseImage/"),
                    fileName);
                fileAvatar.SaveAs(path);

                // Đóng gói đối tượng objCourse
                
                objCourse.CourseImage = fileName;
                // 1. BoxBelow
                
                if (lisBoxBelowIdSelected != null)
                {
                    objCourse.ListBoxBelowDetail = new List<BoxBelowDetailObject>();
                    foreach (var sBoxBelowId in lisBoxBelowIdSelected)
                    {
                        objCourse.ListBoxBelowDetail.Add(new BoxBelowDetailObject()
                        {
                            BoxBelowId = Guid.Parse(sBoxBelowId)
                        });
                    }
                }
                
                // 2. DemoProject
                if (lisDemoProjectIdSelected != null)
                {
                    objCourse.ListCourseDemoProject = new List<DemoProjectDetailObject>();
                    foreach (var sDemoProject in lisDemoProjectIdSelected)
                    {
                        objCourse.ListCourseDemoProject.Add(new DemoProjectDetailObject()
                        {
                            DemoProjectId = Guid.Parse(sDemoProject)
                        });
                    }
                }
                
                // 3. Course technology
                if (lisCourseTechnologyIdSelected != null)
                {
                    objCourse.ListCourseTechnologyDetail = new List<CourseTechnologyDetailObject>();
                    foreach (var sTechnologyId in lisCourseTechnologyIdSelected)
                    {
                        objCourse.ListCourseTechnologyDetail.Add(new CourseTechnologyDetailObject()
                        {
                            CourseTechnologyId = Guid.Parse(sTechnologyId)
                        });
                    }
                }
                if (lisExperiencerIdSelected != null)
                {
                    objCourse.ListCourseTeacher = new List<CourseTeacherObject>();
                    foreach (var sExperiencer in lisExperiencerIdSelected)
                    {
                        objCourse.ListCourseTeacher.Add(new CourseTeacherObject()
                        {
                            ExperiencerId = Guid.Parse(sExperiencer)
                        });
                    }
                }
                // 4. Experiencer
                

                // Gọi BCL insert khoá học xuống database
                new TrainingBcl().InsertCourse(objCourse);
                InsertTag(objCourse.CourseId, oldtag, newtaglist);
            }

            return RedirectToAction("ListCourses");
        }
        public void InsertTag(Guid CourseId, string[] tag, string[] newtag)
        {
            TagBcl tagBCL = new TagBcl();
            TagDetailBcl detailBCL = new TagDetailBcl();
            detailBCL.deleteElementByPost(CourseId);
            if (tag != null)
            {
                foreach (var item in tag)
                {
                    detailBCL.addElement(new TagDetailObject()
                    {
                        PostId = CourseId,
                        TagDetailId = Guid.NewGuid(),
                        TagId = Guid.Parse(item)
                    });
                }
            }
            if (newtag != null)
            {
                foreach (var item in newtag)
                {
                    if (item.Length > 0)
                    {
                        TagObject objTag = new TagObject();
                        objTag.TagId = Guid.NewGuid();
                        objTag.TagName = item;
                        objTag.MenuId = MenuId;
                        tagBCL.addElement(objTag);
                        detailBCL.addElement(new TagDetailObject()
                        {
                            PostId = CourseId,
                            TagDetailId = Guid.NewGuid(),
                            TagId = objTag.TagId
                        });
                    }
                }
            }
        }
        public JsonResult Tag_CheckName(string TagName)
        {
            if (new TagBcl().CheckNameExisted(TagName,MenuId))
                return Json(new { rs = "fail" });
            return Json(new { rs = "ok" });
        }
        public ActionResult CourseEdit(Guid courseId)
        {
            //CourseObject objCourse = new TrainingBcl().GetById(courseId);
            ViewBag.TagList = new TagBcl().getElementByMenuId(MenuId);
            ViewBag.MyTagList = new TagBcl().getTagByPostId(courseId);
            ViewBag.Title = "Sửa khóa học";

            ViewBag.ListCategory = from x in new TrainingBcl().GetCategoriesAll().OrderBy(x => x.TCCodeNumber)
                                   where x.TCCodeNumber != 0
                                   select x;

            List<BoxBelowObject> ListBoxBelowAll = new TrainingBcl().GetBoxBellowAll().ToList();
            List<BoxBelowObject> ListBoxBellowByCourseId = new TrainingBcl().ExecOfGetAllBoxBelowByCourseId(courseId).ToList();

            var ListBoxBellow = ListBoxBelowAll.Where(p => !ListBoxBellowByCourseId.Any(x => x.BoxBelowId == p.BoxBelowId)).ToList();

            ViewBag.ListBoxBellow = ListBoxBellow;
            ViewBag.ListBoxBellowByCourseId = ListBoxBellowByCourseId;

            List<DemoProjectObject> ListDemoProjectAll = new TrainingBcl().GetDemoProjectAll().OrderBy(n => n.ProjectName).ToList();
            List<DemoProjectObject> ListDemoProjectByCourseId = new TrainingBcl().ExecOfGetAllDemoProjectByCourseId(courseId).OrderBy(n => n.ProjectName).ToList();

            var ListDemoProject = ListDemoProjectAll.Where(p => !ListDemoProjectByCourseId.Any(x => x.DemoProjectId == p.DemoProjectId)).ToList();

            ViewBag.ListDemoProject = ListDemoProject;
            ViewBag.ListDemoProjectByCourseId = ListDemoProjectByCourseId;

            List<CourseTechnologyObject> ListCourseTechAll = new TrainingBcl().GetTechnologyAll().ToList();
            List<CourseTechnologyObject> ListCourseTechAllByCourseId = new TrainingBcl().ExecOfGetAllTechnologyByCourseId(courseId).ToList();

            var ListCourseTech = ListCourseTechAll.Where(p => !ListCourseTechAllByCourseId.Any(x => x.CourseTechImage == p.CourseTechImage)).ToList();

            ViewBag.ListCourseTech = ListCourseTech;
            ViewBag.ListCourseTechAllByCourseId = ListCourseTechAllByCourseId;

            List<ExperiencerObject> ListExperiencerAll = new TrainingBcl().GetExperiencerAll().ToList();
            List<ExperiencerObject> ListExperiencerAllByCourseId = new TrainingBcl().ExecOfGetExperiencerByCourseId(courseId).ToList();

            var ListExperiencer = ListExperiencerAll.Where(p => !ListExperiencerAllByCourseId.Any(x => x.ExperiencerId == p.ExperiencerId)).ToList();

            ViewBag.ListExperiencer = ListExperiencer;
            ViewBag.ListExperiencerAllByCourseId = ListExperiencerAllByCourseId;

            

            var listdata = new TrainingBcl().ExecOfGetCourseObjectByCourseId(courseId).FirstOrDefault();
            if (listdata == null)
            {
                return HttpNotFound();
            }
            return View(listdata);

            
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CourseEdit(CourseObject objCourse, HttpPostedFileBase fileAvatar, string[] lisBoxBelowIdSelected, string[] lisDemoProjectIdSelected, string[] lisCourseTechnologyIdSelected, string[] lisExperiencerIdSelected, string[] oldtag, string[] newtaglist)
        {
            //HttpContext.Server.ScriptTimeout = 900000; // Timeout tải file quá lâu
            if (ModelState.IsValid)
            {
                if (objCourse.RankVip == null)
                {
                    objCourse.RankVip = 1000;
                }
                if (fileAvatar != null)
                {
                    // Lưu avatar vào host
                    string fileName = Path.GetFileName(fileAvatar.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Galleries/Training/CourseImage/"),
                        fileName);
                    fileAvatar.SaveAs(path);

                    // Đóng gói đối tượng objCourse

                    objCourse.CourseImage = fileName;
                    // 1. BoxBelow

                    if (lisBoxBelowIdSelected != null)
                    {
                        objCourse.ListBoxBelowDetail = new List<BoxBelowDetailObject>();
                        foreach (var sBoxBelowId in lisBoxBelowIdSelected)
                        {
                            objCourse.ListBoxBelowDetail.Add(new BoxBelowDetailObject()
                            {
                                BoxBelowId = Guid.Parse(sBoxBelowId)
                            });
                        }
                    }

                    // 2. DemoProject
                    if (lisDemoProjectIdSelected != null)
                    {
                        objCourse.ListCourseDemoProject = new List<DemoProjectDetailObject>();
                        foreach (var sDemoProject in lisDemoProjectIdSelected)
                        {
                            objCourse.ListCourseDemoProject.Add(new DemoProjectDetailObject()
                            {
                                DemoProjectId = Guid.Parse(sDemoProject)
                            });
                        }
                    }

                    // 3. Course technology
                    if (lisCourseTechnologyIdSelected != null)
                    {
                        objCourse.ListCourseTechnologyDetail = new List<CourseTechnologyDetailObject>();
                        foreach (var sTechnologyId in lisCourseTechnologyIdSelected)
                        {
                            objCourse.ListCourseTechnologyDetail.Add(new CourseTechnologyDetailObject()
                            {
                                CourseTechnologyId = Guid.Parse(sTechnologyId)
                            });
                        }
                    }
                    if (lisExperiencerIdSelected != null)
                    {
                        objCourse.ListCourseTeacher = new List<CourseTeacherObject>();
                        foreach (var sExperiencer in lisExperiencerIdSelected)
                        {
                            objCourse.ListCourseTeacher.Add(new CourseTeacherObject()
                            {
                                ExperiencerId = Guid.Parse(sExperiencer)
                            });
                        }
                    }
                    // 4. Experiencer

                    new TrainingBcl().UpdateCourse(objCourse);
                }
                else
                {
                    // 1. BoxBelow

                    if (lisBoxBelowIdSelected != null)
                    {
                        objCourse.ListBoxBelowDetail = new List<BoxBelowDetailObject>();
                        foreach (var sBoxBelowId in lisBoxBelowIdSelected)
                        {
                            objCourse.ListBoxBelowDetail.Add(new BoxBelowDetailObject()
                            {
                                BoxBelowId = Guid.Parse(sBoxBelowId)
                            });
                        }
                    }

                    // 2. DemoProject
                    if (lisDemoProjectIdSelected != null)
                    {
                        objCourse.ListCourseDemoProject = new List<DemoProjectDetailObject>();
                        foreach (var sDemoProject in lisDemoProjectIdSelected)
                        {
                            objCourse.ListCourseDemoProject.Add(new DemoProjectDetailObject()
                            {
                                DemoProjectId = Guid.Parse(sDemoProject)
                            });
                        }
                    }

                    // 3. Course technology
                    if (lisCourseTechnologyIdSelected != null)
                    {
                        objCourse.ListCourseTechnologyDetail = new List<CourseTechnologyDetailObject>();
                        foreach (var sTechnologyId in lisCourseTechnologyIdSelected)
                        {
                            objCourse.ListCourseTechnologyDetail.Add(new CourseTechnologyDetailObject()
                            {
                                CourseTechnologyId = Guid.Parse(sTechnologyId)
                            });
                        }
                    }
                    if (lisExperiencerIdSelected != null)
                    {
                        objCourse.ListCourseTeacher = new List<CourseTeacherObject>();
                        foreach (var sExperiencer in lisExperiencerIdSelected)
                        {
                            objCourse.ListCourseTeacher.Add(new CourseTeacherObject()
                            {
                                ExperiencerId = Guid.Parse(sExperiencer)
                            });
                        }
                    }
                    // 4. Experiencer
                    new TrainingBcl().UpdateCourse(objCourse);
                    InsertTag(objCourse.CourseId, oldtag, newtaglist);
                }

                return RedirectToAction("ListCourses");
            }
            return Json(new { Success = false, Message = "Dữ liệu không hợp lệ" });
            
            
        }

        /*
         * Danh sách các khoá học
         * NgocNB - 14102016
         */
        public ActionResult ListCourses()
        {
            ViewBag.Title = "Danh sách khoá học";

            var lisCategoryAll = from x in new TrainingBcl().GetCategoriesAll().OrderBy(x => x.TCCodeNumber)
                                 where x.TCCodeNumber != 0
                                 select x;
            ViewBag.ListCategory = lisCategoryAll;

            //var categoryFirstId = lisCategoryAll.FirstOrDefault().TrainingCategoryId;
            return View(new TrainingBcl().ExecOfGetAllCourse().OrderBy(n => n.RankVip).ThenByDescending(n=>n.ModifiedTime));
            //return View(new TrainingBcl().ExecOfGetAllCourseByTrainingCategoryId(categoryFirstId));
        }

        [HttpPost]
        public ActionResult ListCourses(Guid categoryId)
        {
            ViewBag.Title = "Danh sách khoá học";
            var lisCategoryAll = from x in new TrainingBcl().GetCategoriesAll().OrderBy(x => x.TCCodeNumber)
                where x.TCCodeNumber != 0
                select x;

            ViewBag.ListCategory = lisCategoryAll;

            return View(new TrainingBcl().ExecOfGetAllCourseByTrainingCategoryId(categoryId).OrderBy(n => n.RankVip).ThenByDescending(n => n.ModifiedTime));
        }
        [HttpPost]
        public ActionResult Delete(Guid courseId)
        {
            try
            {
                new TrainingBcl().DeleteCourse(courseId);
                return Json(new { Success = "True", Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }
        }
        [HttpPost]
        public ActionResult DeleteCheckAll(string[] idArr)
        {
            try
            {
                foreach (string id in idArr)
                {
                    new TrainingBcl().DeleteCourse(Guid.Parse(id));
                }

                return Json(new { Success = "True", Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }
        }

        // Ngocnb - 02112016 - Ô thông tin bên dưới
        public ActionResult BoxBellowInsert()
        {
            return View();   
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BoxBellowInsert(BoxBelowObject objBB, HttpPostedFileBase fileAvatar)
        {
            if (fileAvatar != null)
            {
                // Lưu avatar vào host
                string fileName = Path.GetFileName(fileAvatar.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Galleries/Training/BoxBelow/"),
                    fileName);
                fileAvatar.SaveAs(path);

                objBB.Boxlmage = "BoxBelow/" + fileName;
            }

            new TrainingBcl().BoxBelowInsert(objBB);

            return RedirectToAction("BoxBelowList");
        }
        public ActionResult BoxBelowEdit(Guid bbId)
        {
            return View(new TrainingBcl().GetBelowObjectById(bbId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BoxBelowEdit(BoxBelowObject objBB, HttpPostedFileBase fileAvatar)
        {
            if (fileAvatar != null)
            {
                // Lưu avatar vào host
                string fileName = Path.GetFileName(fileAvatar.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Galleries/Training/BoxBelow/"),
                    fileName);
                fileAvatar.SaveAs(path);

                objBB.Boxlmage = fileName;
            }

            new TrainingBcl().BoxBelowUpdate(objBB);

            return RedirectToAction("BoxBelowList");
        }
        public ActionResult BoxBelowList()
        {
            return View(new TrainingBcl().GetBoxBellowAll());
        }
        [HttpPost]
        public ActionResult BoxBelowDelete(Guid BoxBelowId)
        {
            try
            {
                new TrainingBcl().BoxBelowDelete(BoxBelowId);
                return Json(new { Success = "True", Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }
        }
        [HttpPost]
        public ActionResult BoxBelowDeleteCheckAll(string[] idArr)
        {
            try
            {
                foreach (string id in idArr)
                {
                    new TrainingBcl().BoxBelowDelete(Guid.Parse(id));
                }

                return Json(new { Success = "True", Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }
        }
        // Ngocnb - 02112016 - Thêm các dự án demo
        public ActionResult DemoProjectInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DemoProjectInsert(DemoProjectObject objDP, HttpPostedFileBase fileAvatar, HttpPostedFileBase fileImageDemo)
        {
            if (fileAvatar != null)
            {
                // Lưu avatar vào host
                string fileAvatareName = Path.GetFileName(fileAvatar.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Galleries/Training/DemoProject/Thumbs/"),
                    fileAvatareName);
                fileAvatar.SaveAs(path);

                objDP.Thumbnail = fileAvatareName;
            }

            if (objDP.DemoType == true)
            {
                // fileImageDemo demo la hinh anh
                if (fileImageDemo != null)
                {
                    // Lưu vào host
                    string fileImageDemoName = Path.GetFileName(fileImageDemo.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Galleries/Training/DemoProject/Images/"),
                        fileImageDemoName);
                    fileImageDemo.SaveAs(path);

                    objDP.DemoLink = fileImageDemoName;
                }
            }

            new TrainingBcl().DemoProjectInsert(objDP);

            return RedirectToAction("DemoProjectInsert");
        }

        // Ngocnb - 02112016 - Thêm các công nghệ sử dụng
        public ActionResult CourseTech()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CourseTech(CourseTechnologyObject objCT, HttpPostedFileBase fileAvatar)
        {
            if (fileAvatar != null)
            {
                // Lưu avatar vào host
                string fileName = Path.GetFileName(fileAvatar.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Galleries/Training/CourseTech/"),
                    fileName);
                fileAvatar.SaveAs(path);

                objCT.CourseTechImage = "CourseTech/" + fileName;
            }

            new TrainingBcl().CourseTechInsert(objCT);

            return RedirectToAction("CourseTech");
        }
        public ActionResult TestModelGallerySelect()
        {
            return View();
        }
    }
}