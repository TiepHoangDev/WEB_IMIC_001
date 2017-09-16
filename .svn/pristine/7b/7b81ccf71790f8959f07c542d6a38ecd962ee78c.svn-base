using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.Class.Controllers
{
    public class ClassAccountController : Controller
    {
        //
        // GET: /Class/ClassAccount/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageAccount( string id)
        {
            if (id == "hs")
            {
                var lstAcchs = new AccountBcl().getElement().Where(x => x.RoleId == 21);
                return View(lstAcchs);
            }

            var lstAcc = new AccountBcl().getElement().Where(x => x.RoleId == 20);
            return View(lstAcc);
        }

        public ActionResult AccountInsert()
        {
            var lstRole = new RoleBcl().getElement().Where(x=>x.RoleId ==20 || x.RoleId==21 );
            ViewBag.Role = lstRole;
            return View();
        }

        [HttpPost]
        public ActionResult AccountInsert(AccountObject model)
        {
            model.AccountId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/images/avatar"), fileName);
                file.SaveAs(path);
                model.ImageAvatar = fileName;
            }
            model.Password = new EncodeMD5().EncodingMD5(model.Password);
            model.LastLoginTime = DateTime.Now.ToString();
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_USER]).AccountId;
            model.ModifiedTime = DateTime.Now.ToString();
            model.IsDeleted = false;
            model.IsActived = true;
            new AccountBcl().addElements(model);
            if (model.RoleId == 21)
            {
                return RedirectToAction("ManageAccount", "ClassAccount", new {id = "hs"});
            }
            return RedirectToAction("ManageAccount", "ClassAccount", new { id = "gv" });
        }

        public ActionResult AccountUpdate(Guid id)
        {
            var lstRole = new RoleBcl().getElement().Where(x => x.RoleId == 20 || x.RoleId == 21);
            ViewBag.Role = lstRole;
            var  obj =  new AccountBcl().getElementById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult AccountUpdate(AccountObject model)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/images/avatar"), fileName);
                file.SaveAs(path);
                model.ImageAvatar = fileName;
            }
            model.Password = new EncodeMD5().EncodingMD5(model.Password);
            model.LastLoginTime = DateTime.Now.ToString();
            model.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_USER]).AccountId;
            model.ModifiedTime = DateTime.Now.ToString();
            model.IsDeleted = false;
            model.IsActived = true;
            new AccountBcl().updateElements(model);
            if (model.RoleId == 21)
            {
                return RedirectToAction("ManageAccount", "ClassAccount", new { id = "hs" });
            }
            return RedirectToAction("ManageAccount", "ClassAccount", new { id = "gv" });
        }
	} 
}