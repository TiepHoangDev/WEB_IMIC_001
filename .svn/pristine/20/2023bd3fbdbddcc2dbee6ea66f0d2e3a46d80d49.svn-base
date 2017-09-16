using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.BTV.Controllers
{
    public class BTVAccountController : Controller
    {
        //
        // GET: /BTV/BTVAccount/
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login(LoginObject objLogin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var rs = AccountBcl.Login(objLogin, true);
        //        if (rs == 1)
        //        {
        //            // kiem tra quyen
        //            // coding
        //            //AccountObject objAccount = new AccountObject()
        //            //{
        //            //    Username = objLogin.Username
        //            //}; // code them lay tk tu db
        //            AccountObject objAccount = new AccountBcl().getLoginAccount(objLogin.Username, objLogin.Password);
        //            // session
        //            Session.Add(CommonConstants.SESSION_ACCOUNT, objAccount);

        //            // cookie
        //            FormsAuthentication.SetAuthCookie(objLogin.Username, objLogin.RememberMe);

        //            return RedirectToAction("Index", "Upload");
        //        }
        //        else if (rs == 0)
        //        {
        //            ModelState.AddModelError("", "Tài khoản không tồn tại");

        //        }
        //        else if (rs == -2)
        //        {
        //            ModelState.AddModelError("", "Mật khẩu không đúng");
        //            //return Json(new { rs = -2 });
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Đăng nhập thất bại");
        //            //return Json(new { rs = -3 });
        //        }
        //    }

        //    return View(objLogin);
        //    //return Redirect(Request.UrlReferrer + "");
        //}

        public ActionResult Login()
        {

            AccountObject objAccount = new AccountObject();
            return View(objAccount);
        }
        [HttpPost]
        public ActionResult Login(AccountObject objAccount)
        {
            AccountObject objCheck = new AccountBcl().CheckLogin(objAccount);
            if (objCheck == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                return View(new AccountObject());
            }
            else if (objCheck.RoleId != CommonConstants.ADMIN && objCheck.RoleId != CommonConstants.SUPER_ADMIN
                && objCheck.RoleId != CommonConstants.UPLOADER)
            {
                ModelState.AddModelError("", "Bạn không đủ thẩm quyền");
                return View(new AccountObject());
            }
            else
            {
                Session.Add(CommonConstants.SESSION_USER, objCheck);
                if (objCheck.RoleId == CommonConstants.UPLOADER)
                    return RedirectToAction("Index", "Upload");
            }

            return RedirectToAction("Index", "Manage");
        }
        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.SESSION_USER);
            return RedirectToAction("Login", "BTVAccount");
        }
        public ActionResult Warning()
        {
            return View();
        }
        

	}
}