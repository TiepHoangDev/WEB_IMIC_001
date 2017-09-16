using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.Class.Controllers
{
    public class ClassSessionDetailController : Controller
    {
        // GET: Class/ClassSessionDetail
        //public ActionResult Index()
        //{
        //    return View();
        //}
        #region  ClassSessionDetail
        public ActionResult ClassSessionDetailIndex()
        {
            var lstClassSessionDetail = new ClassSessionDetailBcl().ClassSessionDetailGetAll();
            return View(lstClassSessionDetail);
        }

        public ActionResult ClassSessionDetailInsert()
        {
            var listClass = new ClassBcl().getAll();
            ViewBag.Class = listClass;
            var listShift = new ClassSessionDetailBcl().ClassShiftGetAll();
            ViewBag.Shift = listShift;
            var listWeekDay = new ClassSessionDetailBcl().ClassWeekDayGetAll();
            ViewBag.Weekday = listWeekDay;
            return View();
        }

        [HttpPost]
        public ActionResult ClassSessionDetailInsert(ClassSessionDetailObject obj)
        {
            obj.ClassSessionDetailId = Guid.NewGuid();
            //obj.IsActived = true;
            obj.OnDate = DateTime.Now;

            new ClassSessionDetailBcl().ClassSessionDetailInsert(obj);;
            return RedirectToAction("ClassSessionDetailIndex");
        }

        public ActionResult ClassSessionDetailUpdate(Guid id)
        {
            var obj = new ClassSessionDetailBcl().ClassSessionDetailGetById(id);
            var listClass = new ClassBcl().getAll();
            ViewBag.Class = listClass;
            var listShift = new ClassSessionDetailBcl().ClassShiftGetAll();
            ViewBag.Shift = listShift;
            var listWeekDay = new ClassSessionDetailBcl().ClassWeekDayGetAll();
            ViewBag.Weekday = listWeekDay;
            return View(obj);
        }

        [HttpPost]
        public ActionResult ClassSessionDetailUpdate(ClassSessionDetailObject obj)
        {
            new ClassSessionDetailBcl().ClassSessionDetailUpdate(obj);
            return RedirectToAction("ClassSessionDetailIndex");
        }

        [HttpPost]
        public JsonResult ClassSessionDetailDelete(Guid id)
        {
            new ClassSessionDetailBcl().ClassSessionDetailDelete(id);
            return Json(new { rs = "ok" });
        }
        #endregion

        #region  ClassShift
        public ActionResult ClassShiftIndex()
        {
            var lstClassShift = new ClassSessionDetailBcl().ClassShiftGetAll();
            return View(lstClassShift);
        }

        public ActionResult ClassShiftInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClassShiftInsert(ClassShiftObject obj)
        {
            obj.ClassShiftId = Guid.NewGuid();
            new ClassSessionDetailBcl().ClassShiftInsert(obj);
            return RedirectToAction("ClassShiftIndex");
        }

        public ActionResult ClassShiftUpdate(Guid id)
        {
            var obj = new ClassSessionDetailBcl().ClassShiftGetById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult ClassShiftUpdate(ClassShiftObject obj)
        {
            new ClassSessionDetailBcl().ClassShiftUpdate(obj);
            return RedirectToAction("ClassShiftIndex");
        }

        [HttpPost]
        public JsonResult ClassShiftDelete(Guid id)
        {
            new ClassSessionDetailBcl().ClassShiftDelete(id);
            return Json(new { rs = "ok" });
        }
        #endregion

        #region  ClassWeekDay
        public ActionResult ClassWeekDayIndex()
        {
            var lstClassWeekDay = new ClassSessionDetailBcl().ClassWeekDayGetAll();
            return View(lstClassWeekDay);
        }

        public ActionResult ClassWeekDayInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClassWeekDayInsert(ClassWeekDayObject obj)
        {
            new ClassSessionDetailBcl().ClassWeekDayInsert(obj); ;
            return RedirectToAction("ClassWeekDayIndex");
        }

        public ActionResult ClassWeekDayUpdate(int id)
        {
            var obj = new ClassSessionDetailBcl().ClassWeekDayGetById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult ClassWeekDayUpdate(ClassWeekDayObject obj)
        {
            new ClassSessionDetailBcl().ClassWeekDayUpdate(obj);
            return RedirectToAction("ClassWeekDayIndex");
        }

        [HttpPost]
        public JsonResult ClassWeekDayDelete(int id)
        {
            new ClassSessionDetailBcl().ClassWeekDayDelete(id);
            return Json(new { rs = "ok" });
        }
        #endregion
    }
}