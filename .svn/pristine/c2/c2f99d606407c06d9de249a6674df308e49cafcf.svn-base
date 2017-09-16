using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.Class.Controllers
{
    public class LoginController : Controller
    {
        // GET: Class/Login
        public ActionResult Index()
        {
            AccountObject objAccount = new AccountObject();
            return View(objAccount);
        }
        [HttpPost]
        public ActionResult Index(AccountObject obj)
        {
            AccountObject objCheck = new AccountBcl().CheckLogin(obj);
            if (objCheck == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                return View(new AccountObject());
            }
            else if (objCheck.RoleId != CommonConstants.ADMIN && objCheck.RoleId != CommonConstants.SUPER_ADMIN
                && objCheck.RoleId != CommonConstants.TEACHER  && objCheck.RoleId != CommonConstants.STUDENT)
            {
                ModelState.AddModelError("", "Bạn không đủ thẩm quyền");
                return View(new AccountObject());
            }
            else
            {
                Session.Add(CommonConstants.SESSION_USER, objCheck);
                if (objCheck.RoleId == CommonConstants.ADMIN || objCheck.RoleId == CommonConstants.SUPER_ADMIN || objCheck.RoleId == CommonConstants.TEACHER || objCheck.RoleId ==CommonConstants.STUDENT)
                    return RedirectToAction("Index", "Class");
            }

            
            return View();
        }
    }
}