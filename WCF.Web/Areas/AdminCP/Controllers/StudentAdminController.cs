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
    public class StudentAdminController : Controller
    {
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
        // GET: AdminCP/StudentGalery
        public ActionResult Index()
        {
            if (((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]) == null)
                return RedirectToAction("Index", "TechPage", new { area = "" });
            return View();
        }
        [HttpGet]
        public ActionResult Student_Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Student_Insert(StudentGaleryObject objStudent)
        {
            objStudent.ImageID = Guid.NewGuid();
            objStudent.FlagThumbnail = false;
            objStudent.FlagLink = false;
            if (Request.Form["checkbox1"] != null)
            {
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/StudentGalery"), fileName);
                    file.SaveAs(path);
                    objStudent.ImageThumbnail = fileName;
                }
                objStudent.FlagThumbnail = true;
            }
            if (Request.Form["checkbox2"] != null)
            {
                HttpPostedFileBase file1 = Request.Files["Avatar1"];
                if (file1.ContentLength > 0 && file1.ContentType.Contains("image"))
                {
                    var fileName1 = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file1.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/StudentGalery"), fileName1);
                    file1.SaveAs(path);
                    objStudent.ImageLink = fileName1;
                }
                objStudent.FlagLink = true;
            }
            objStudent.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objStudent.ModifiedTime = DateTime.Now;
            objStudent.IsApproved = true;
            objStudent.ApprovedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objStudent.IsDeleted = false;
            new StudentGaleryBcl().addElements(objStudent);
            return RedirectToAction("ManageStudent", "StudentAdmin");
        }
        [HttpGet]
        public ActionResult Student_Edit(Guid id)
        {
            StudentGaleryObject objStudent = new StudentGaleryBcl().getElementByID(id);
            ViewBag.StudentList = new StudentGaleryBcl().getElements();
            return View(objStudent);
        }
        [HttpPost]
        public ActionResult Student_Edit(StudentGaleryObject objStudent)
        {
            objStudent.FlagThumbnail = false;
            objStudent.FlagLink = false;
            if (Request.Form["checkbox1"] != null)
            {
                objStudent.FlagThumbnail = true;
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/StudentGalery"), fileName);
                    file.SaveAs(path);
                    objStudent.ImageThumbnail = fileName;
                }
            }
            else
            {
                var imagethumbnail = Request.Form["ImageThumbnailNew"];
                objStudent.ImageThumbnail = imagethumbnail;
            }
            if (Request.Form["checkbox2"] != null)
            {
                objStudent.FlagLink = true;
                HttpPostedFileBase file1 = Request.Files["Avatar1"];
                if (file1.ContentLength > 0 && file1.ContentType.Contains("image"))
                {
                    var fileName1 = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file1.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/StudentGalery"), fileName1);
                    file1.SaveAs(path);
                    objStudent.ImageLink = fileName1;
                }
            }
            else
            {
                var imagelink = Request.Form["ImageLinkNew"];
                objStudent.ImageLink = imagelink;
            }
            objStudent.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objStudent.ModifiedTime = DateTime.Now;
            objStudent.IsApproved = true;
            objStudent.ApprovedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objStudent.IsDeleted = false;
            new StudentGaleryBcl().updateElements(objStudent);
            return RedirectToAction("ManageStudent", "StudentAdmin");
        }
        public JsonResult Student_Delete(Guid id)
        {
            new StudentGaleryBcl().deleteElement(id);
            return Json(new { rs = "ok" });
        }

        public ActionResult ManageStudent()
        {
            if (((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]) == null)
                return RedirectToAction("Index", "StudentGalery", new { area = "" });
            return View(new StudentGaleryBcl().getElements());
        }
    }
}