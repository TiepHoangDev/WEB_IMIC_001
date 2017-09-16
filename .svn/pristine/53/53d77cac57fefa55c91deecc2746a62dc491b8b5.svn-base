using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.Class.Controllers
{
    public class ClassController : Controller
    {
        //
        // GET: /Class/Class/
        #region  Class
        public ActionResult Index()
        {
            var  lstClass =  new ClassBcl().getAll();
            return View(lstClass);
        }

        public ActionResult ClassInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClassInsert(ClassObject obj)
        {
            obj.ClassId = Guid.NewGuid();
            obj.IsStatus = true;
        

            new ClassBcl().Insert(obj);
            return RedirectToAction("Index");
        }

        public ActionResult ClassUpdate(Guid id)
        {
            var obj = new ClassBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult ClassUpdate(ClassObject obj)
        {
            new ClassBcl().Update(obj);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ClassDelete(Guid id)
        {
            new ClassBcl().Delete(id);
            return Json(new {rs = "ok"});
        }

        public JsonResult IsActived(Guid id)
        {
            var obj = new ClassBcl().GetByID(id);
            if (obj.IsStatus == false)
            {
                new ClassBcl().IsActived(id);
                return Json(new { rs = "ok" });
            }
            else
            {
                new ClassBcl().UnActive(id);
                return Json(new { rs = "ok" });
            }
           
        }
#endregion

        // ClassDetail
#region ClassDetail

        public ActionResult ManageClassDetail(Guid id, string name )
        {
            ViewBag.Title = name;
            ViewBag.id = id;
            var lstDetail = new ClassDetailBcl().GetAll().Where(x=>x.ClassId==id);
            return View(lstDetail);
        }

        public ActionResult DetailInsert(Guid id )
        {
            ViewBag.ClassId = id;
            var lstClass =  new ClassBcl().getAll();
            ViewBag.Class = lstClass;
            var lstAcc =  new AccountBcl().getElement().Where(x=>x.RoleId ==20 || x.RoleId ==21);
            ViewBag.Acc = lstAcc;
            return View();
        }

        [HttpPost]
        public ActionResult DetailInsert(ClassDetailObject obj)
        {
            obj.ClassDetailId = Guid.NewGuid();
            new ClassDetailBcl().Insert(obj);
            return RedirectToAction("ManageClassDetail","Class",new{id=obj.ClassId,name=""});
        }

        public ActionResult Detailupdate(Guid id)
        {
            var lstClass = new ClassBcl().getAll();
            ViewBag.Class = lstClass;
            var lstAcc = new AccountBcl().getElement().Where(x => x.RoleId == 20 || x.RoleId == 21);
            ViewBag.Acc = lstAcc;
            var obj = new ClassDetailBcl().GetById(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Detailupdate(ClassDetailObject obj)
        {
            new ClassDetailBcl().Update(obj);
            return RedirectToAction("ManageClassDetail", "Class", new { id = obj.ClassId, name = "" });
        }

        [HttpPost]
        public JsonResult DetailDelete(Guid id)
        {
            new ClassDetailBcl().Delelte(id);
            return Json(new {rs = "ok"});
        }
#endregion


        // ClassSessionLog

#region ClassSessionLog

        public ActionResult ManageClassSessionlog()
        {
            var lst= new ClassSessionLogBcl().GetAll();
            return View(lst);
        }

        public ActionResult SessionLogInsert()
        {
            var lstClass = new ClassBcl().getAll();
            ViewBag.Class = lstClass;
            var lstAcc = new AccountBcl().getElement().Where(x => x.RoleId == 20);
            ViewBag.Acc = lstAcc;
            return View();
        }

        [HttpPost]
        public ActionResult SessionLogInsert(ClassSessionLogObject obj)
        {
            obj.ClassSessionLogId = Guid.NewGuid();
            obj.IsActived = true;
            obj.IsDeleted = false;
            new ClassSessionLogBcl().Insert(obj);
            return RedirectToAction("ManageClassSessionlog");
        }

        public ActionResult SessionLogUpdate(Guid id)
        {
            var lstClass = new ClassBcl().getAll();
            ViewBag.Class = lstClass;
            var lstAcc = new AccountBcl().getElement().Where(x => x.RoleId == 20);
            ViewBag.Acc = lstAcc;
            var obj = new ClassSessionLogBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult SessionLogUpdate(ClassSessionLogObject obj)
        {
            new ClassSessionLogBcl().Update(obj);
            return RedirectToAction("ManageClassSessionlog");
        }

        [HttpPost]
        public JsonResult SessionLogDelete(Guid id)
        {
            new ClassSessionLogBcl().Delete(id);
            return Json(new {rs = "ok"});
        }

        [HttpPost]
        public JsonResult SessionLog_Actived(Guid id)
        {
            var obj = new ClassSessionLogBcl().GetByID(id);
            if (obj.IsActived == false)
            {
                new ClassSessionLogBcl().IsActived(id);
                return Json(new { rs = "ok" });
            }
            else
            {
                new ClassSessionLogBcl().UnActive(id);
                return Json(new { rs = "ok" });
            }
        }
#endregion

        // ClassSessionLogAbsent
#region

        public ActionResult ManageStudentAbsent(Guid id ,string date)
        {
            ViewBag.date = date;
            ViewBag.id = id;
            var lstAbsent = new ClassSessionLogAbsentBcl().GetAll().Where(x=>x.ClassSessionLogId ==id);
            return View(lstAbsent);
        }

        public ActionResult AbsentInsert( Guid id)
        {
            ViewBag.id = id;
            var lstAcc = new AccountBcl().getElement().Where(x => x.RoleId == 21);
            ViewBag.Acc = lstAcc;
            return View();
        }

        [HttpPost]
        public ActionResult AbsentInsert(ClassSessionLogAbsentObject obj)
        {
            obj.LogAbsentStudentId = Guid.NewGuid();
            new ClassSessionLogAbsentBcl().Insert(obj);
            return RedirectToAction("ManageStudentAbsent","Class",new{id=obj.ClassSessionLogId , date ="" });
        }

        public ActionResult AbsentUpdate(Guid id)
        {
            var lstAcc = new AccountBcl().getElement().Where(x => x.RoleId == 21);
            ViewBag.Acc = lstAcc;
            var obj = new ClassSessionLogAbsentBcl().GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult AbsentUpdate(ClassSessionLogAbsentObject obj)
        {
            new ClassSessionLogAbsentBcl().Update(obj);
            return RedirectToAction("ManageStudentAbsent");
        }

        [HttpPost]
        public JsonResult AbsentDelete(Guid id)
        {
            new ClassSessionLogAbsentBcl().Delete(id);
            return Json(new {rs = "ok"});
        }

#endregion
    }
}