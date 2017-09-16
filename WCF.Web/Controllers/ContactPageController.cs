using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Controllers
{
    public class ContactPageController : Controller
    {
        // GET: ContactPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Modal_Notification()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Contact_Request(string fullName, string email, string title, string content)
        {
            if (String.IsNullOrEmpty(fullName) || String.IsNullOrEmpty(email)
                || String.IsNullOrEmpty(title) || String.IsNullOrEmpty(content))
            {
                return Json(new { result = false, Message = "Vui lòng điền đầy đủ thông tin liên hệ !" });
            }
            else
            {
                ContactObject objContact = new ContactObject();
                objContact.ContactId = Guid.NewGuid();
                objContact.FullName = fullName;
                objContact.Email = email;
                objContact.Title = title;
                objContact.ContentContact = content;
                objContact.CreatedTime = DateTime.Now;
                objContact.IsSeen = false;
                objContact.IsDeleted = false;
                new ContactPageBcl().Insert(objContact);
                return Json(new { result = true, Message = "Gửi liên hệ thành công !" });
            }

        }

        //[HttpPost]
        //public ActionResult Contact_Request(ContactObject objContact)
        //{
        //    objContact.ContactId = Guid.NewGuid();
        //    objContact.CreatedTime = DateTime.Now;
        //    objContact.IsSeen = false;
        //    objContact.IsDeleted = false;
        //    new ContactPageBcl().Insert(objContact);
        //    return RedirectToAction("Index", "ContactPage");
        //}
    }
}