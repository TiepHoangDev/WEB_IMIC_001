using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.BTV.Controllers
{
    public class ProposeController : BaseController
    {
        //
        // GET: /BTV/Propose/
        public ActionResult ManagePropose(Guid? userid, DateTime? begin, DateTime? end)
        {
            ViewBag.uploader = ViewBag.uploader = new AccountBcl().getByRoleID(4);

            if (userid == null & begin == null & end == null)
            {
                return View(new ProposeBcl().GetAll().Where(x => x.IsRegister == true));
            }
            else if (begin == null || end == null)
            {
                return View(new ProposeBcl().GetAll().Where(x => x.IsRegister == true && x.RegisterBy == userid));
            }
            else if (userid == null)
            {
                return
                    View(new ProposeBcl().GetAll().Where(x => x.IsRegister == true && x.RegisterDate >= begin && x.RegisterDate <= end));
            }
          return  View(new ProposeBcl().GetAll().Where(x => x.IsRegister == true && x.RegisterBy ==userid && x.RegisterDate >= begin && x.RegisterDate <= end));
        }

        public ActionResult ManageProposeUnRegister()
        {
            return View(new ProposeBcl().GetAll().Where(x => x.IsRegister == false));
        }
        public ActionResult ProposeInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProposeInsert(ProposeObject obj)
        {
            obj.ProposeId = Guid.NewGuid();
            obj.CreateDate = DateTime.Now;
            obj.IsRegister = false;
            new ProposeBcl().Insert(obj);
            return RedirectToAction("ManagePropose");
        }

        public ActionResult ProposeUpdate(Guid id)
        {
            return View(new ProposeBcl().GetById(id));
        }

        [HttpPost]
        public ActionResult ProposeUpdate(ProposeObject obj)
        {
            new ProposeBcl().Update(obj);
            return RedirectToAction("ManagePropose");
        }

        public ActionResult Index(bool IsRegister = false)
        {
            ViewBag.isregister = IsRegister;
            return View(new ProposeBcl().GetAll().Where(x => x.IsRegister == IsRegister));
         
        }
        [HttpPost]
        public JsonResult UpdateByUser(Guid id)
        {
            ProposeObject obj = new ProposeObject();
            obj.ProposeId = id;
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_USER];
            obj.RegisterBy = objUser.AccountId;
            obj.RegisterDate =DateTime.Now;
            obj.IsRegister = true;
            new ProposeBcl().UpdateByUser(obj);
            return Json(new {rs = "ok"});
        }

        [HttpPost]
        public JsonResult UnRegister(Guid id)
        {
            new ProposeBcl().UnRegister(id);
            return Json(new {rs = "ok"});
        }
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            new ProposeBcl().Delete(id);
            return Json(new {rs = "ok"});
        }
	}
}