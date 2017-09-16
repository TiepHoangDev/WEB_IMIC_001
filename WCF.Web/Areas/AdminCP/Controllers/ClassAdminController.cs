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
    public class ClassAdminController : Controller
    {
        // GET: AdminCP/ClassAdmin
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
                else if (session.RoleId != CommonConstants.ROLE_ADMIN && session.RoleId != CommonConstants.ROLE_SYSADMIN )
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "AccountAdmin", action = "Login", Area = "AdminCP" }));
            }


            base.OnActionExecuting(filterContext);
        }
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult ListClass(Guid? trainingCatId)
        {
            ViewBag.trainingCatId = trainingCatId;
            if (trainingCatId == Guid.Parse("68dc1bcd-9a5e-433c-8f79-e44ed5ff28fc") || trainingCatId == null)
            {
                return View(new OpenClassBcl().execOfGetAllElements().OrderByDescending(n=>n.ModifiedTime));
            }
            return View(new OpenClassBcl().GetAllElementsByTrainingCategoryId((Guid)trainingCatId));
        }
        [HttpGet]
        public ActionResult ClassInsert()
        {
            ViewBag.Title = "Đăng lớp mới";
            var lis = new TrainingBcl().ExecOfGetAllCourse().ToList();
            var lstLocation = new LocationBcl().getElement();
            ViewBag.lstLocation = lstLocation;
            ViewBag.ListCourse = lis;

            return View();
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult ClassInsert(OpenClassObject objOc, HttpPostedFileBase fileAvatar)
        {
            //HttpContext.Server.ScriptTimeout = 900000; // Timeout tải file quá lâu

            // Lưu avatar vào host
            string fileName = Path.GetFileName(fileAvatar.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/Galleries/Class/"),
                fileName);
            fileAvatar.SaveAs(path);

            objOc.ClassAvatar = fileAvatar.FileName;

            // Gọi BCL insert news
            new OpenClassBcl().InsertClass(objOc);
            return RedirectToAction("ListClass");
        }

        public ActionResult ClassEdit(Guid classId)
        {
            ViewBag.Title = "Sửa khóa học";
            ViewBag.ListCourse = new TrainingBcl().ExecOfGetAllCourse().OrderBy(x => x.ModifiedTime);
            ViewBag.ListLocation = new LocationBcl().getElement();

            //var listdata = new OpenClassBcl().execOfGetElementsById(classId).FirstOrDefault();
            //if (listdata == null)
            //{
            //    return HttpNotFound();
            //}
            OpenClassObject objClass = new OpenClassBcl().GetElementsById(classId);
            return View(objClass);

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ClassEdit(OpenClassObject objOc, HttpPostedFileBase fileAvatar)
        {
            
                HttpContext.Server.ScriptTimeout = 1000;

                if (ModelState.IsValid)
                {
                    if (fileAvatar != null)
                    {
                        string fileName = Path.GetFileName(fileAvatar.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/Galleries/Class/"), fileName);
                        fileAvatar.SaveAs(path);
                        objOc.ClassAvatar = fileAvatar.FileName;
                    }
                    
                    new OpenClassBcl().UpdateClass(objOc);
                    return RedirectToAction("ListClass");
                }
                return Json(new { Success = false, Message = "Dữ liệu không hợp lệ" });
            
            //catch (Exception e)
            //{
            //    return RedirectToAction("ListClass");
            //}
        }

        [HttpPost]
        public ActionResult Delete(Guid classId)
        {
            try
            {
                new OpenClassBcl().DeleteClass(classId);
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
                    new OpenClassBcl().DeleteClass(Guid.Parse(id));
                }

                return Json(new { Success = "True", Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }
        }
        
        public ActionResult ListClass_Dropdownlist()
        {
            return View(new TrainingBcl().GetCategoriesAll().OrderBy(n=> n.TCCodeNumber));
        }

        // Ngocnb - 13112016 - Đơn đăng ký chưa duyệt
        public ActionResult Register_RegisterDetail_ChuaDuyet()
        {
            var lisRD = new OpenClassBcl().GetRegister_IsSeen(false);
            return View(lisRD);
        }
        
        public ActionResult getResByID(Guid id ,bool daduyet)
        {
            ViewBag.daduyet = daduyet;
            var obj = new OpenClassBcl().getRegisterById(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult getResByID(RegisterDetailObject obj, bool daduyet =false)
        {
           
            obj.IsSeen = true;
            obj.IsDeleted = false;
            new OpenClassBcl().UpdateRegisterDetail(obj);

            if (daduyet) return RedirectToAction("Register_RegisterDetail_DaDuyet");

            return RedirectToAction("Register_RegisterDetail_ChuaDuyet");
        }


        public ActionResult Register_Aprroving(Guid registerDetailId, Guid classCourseId, bool typeReg, Guid personId, string message, int status, string comment, DateTime createdTime, bool daDuyet = false)
        {
            RegisterDetailObject objRD = new RegisterDetailObject()
            {
                RegisterDetailId = registerDetailId,
                ClassId = typeReg == true ? (Guid?)classCourseId : null,
                Comment = comment,
                CreatedTime = createdTime,
                IsDeleted = false,
                IsSeen = true,
                Status = (byte)status,
                Message = message,
                OpenClass = null,
                RegisterPersonId = personId,
                RegisterPerson = null,
                CourseId = typeReg == false ? (Guid?)classCourseId : null
            };

            new OpenClassBcl().UpdateRegisterDetail(objRD);

            if (daDuyet) return RedirectToAction("Register_RegisterDetail_DaDuyet");
            
            return RedirectToAction("Register_RegisterDetail_ChuaDuyet");
        }

        // Ngocnb - 29112016 - Đơn đăng ký đã duyệt
        public ActionResult Register_RegisterDetail_DaDuyet()
        {
            var lisRD = new OpenClassBcl().GetRegister_IsSeen(true);
            return View(lisRD);
        }
    }
}