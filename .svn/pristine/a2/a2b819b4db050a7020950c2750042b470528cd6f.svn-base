using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class LessonAdminController : Controller
    {
        // GET: AdminCP/LessonAdmin
        public ActionResult Index()
        {
            return View();
        }

        #region Lesson Category
        public ActionResult Manage_LessonCategory()
        {
            return View(new LessonCategoryBCL().getElements());
        }

        public ActionResult LessonCategory_Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LessonCategory_Insert(LessonCategoryObject objLessonCategory)
        {
            objLessonCategory.LessonCategoryId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Categories"), fileName);
                file.SaveAs(path);
                objLessonCategory.CategoryImage = fileName;
            }
            objLessonCategory.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objLessonCategory.ModifiedTime = DateTime.Now;
            objLessonCategory.IsDeleted = false;
            new LessonCategoryBCL().addElement(objLessonCategory);
            return RedirectToAction("Manage_LessonCategory", "LessonAdmin");
        }

        public ActionResult LessonCategory_Update(Guid LessonCategoryId)
        {
            return View(new LessonCategoryBCL().getElementById(LessonCategoryId));
        }

        [HttpPost]
        public ActionResult LessonCategory_Update(LessonCategoryObject objLessonCategory)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Categories"), fileName);
                file.SaveAs(path);
                objLessonCategory.CategoryImage = fileName;
            }
            new LessonCategoryBCL().updateElement(objLessonCategory);
            return RedirectToAction("Manage_LessonCategory", "LessonAdmin");
        }

        [HttpPost]
        public JsonResult LessonCategory_Delete(Guid LessonCategoryId)
        {
            try
            {
                new LessonCategoryBCL().deleteElement(LessonCategoryId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
            }
            return Json(new { result = true, message = "Xóa danh mục thành công!" });
        }
        #endregion

        #region Lesson
        public ActionResult Manage_Lesson(Guid? LessonCategoryId)
        {
            ViewBag.LessonCategoryList = new LessonCategoryBCL().getElements();
            ViewBag.LessonCategoryId = LessonCategoryId;
            if (LessonCategoryId == null)
            {
                return View(new LessonBCL().getElements());
            }
            else
            {
                return View(new LessonBCL().getElementsByCategoryId((Guid)LessonCategoryId));
            }
        }

        public ActionResult Lesson_Insert()
        {
            ViewBag.LessonCategoryList = new LessonCategoryBCL().getElements();
            return View();
        }

        [HttpPost]
        public ActionResult Lesson_Insert(LessonObject objLesson)
        {
            objLesson.LessonId = Guid.NewGuid();
            objLesson.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objLesson.ModifiedTime = DateTime.Now;
            objLesson.IsDeleted = false;
            objLesson.ImageFlag = false;
            if (Request.Form["localfile"] != null)
            {
                objLesson.ImageFlag = true;
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Lesson"), fileName);
                    file.SaveAs(path);
                    objLesson.SeoImage = fileName;
                }
            }
            new LessonBCL().addElement(objLesson);
            return RedirectToAction("Lesson_Update", "LessonAdmin", new { LessonId = objLesson.LessonId });
        }

        public ActionResult Lesson_Update(Guid LessonId)
        {
            ViewBag.LessonCategoryList = new LessonCategoryBCL().getElements();
            return View(new LessonBCL().getElementById(LessonId));
        }

        public ActionResult Lesson_DetailTable(Guid LessonId)
        {
            ViewBag.LessonId = LessonId;
            return View(new LessonDetailBCL().getElementsByLessonId(LessonId));
        }

        [HttpPost]
        public ActionResult Lesson_Update(LessonObject objLesson)
        {
            objLesson.ImageFlag = false;
            if (Request.Form["localfile"] != null)
            {
                objLesson.ImageFlag = true;
                HttpPostedFileBase file = Request.Files["Avatar"];
                if (file.ContentLength > 0 && file.ContentType.Contains("image"))
                {
                    var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Lesson"), fileName);
                    file.SaveAs(path);
                    objLesson.SeoImage = fileName;
                }
            }
            else
            {
                var imagelink = Request.Form["SeoImage"];
                objLesson.SeoImage = imagelink;
            }
            new LessonBCL().updateElement(objLesson);
            return RedirectToAction("Manage_Lesson", "LessonAdmin");
        }

        [HttpPost]
        public JsonResult Lesson_Delete(Guid LessonId)
        {
            try
            {
                new LessonBCL().deleteElement(LessonId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
            }
            return Json(new { result = true, message = "Xóa bài học thành công!" });
        }
        #endregion

        #region Detail
        public ActionResult Manage_LessonDetail(Guid? LessonId, int pageIndex)
        {
            ViewBag.LessonList = new LessonBCL().getElements();
            int pageSize = 10;
            ViewBag.pageIndex = pageIndex;

            ViewBag.pageIndex = pageIndex;
            if (pageIndex >= 1)
            {
                pageIndex = pageIndex - 1;
            }

            if (LessonId != null)
            {
                ViewBag.LessonId = LessonId;
                int totalItem = new LessonDetailBCL().getCount(LessonId);
                ViewBag.totalItem = totalItem;
            }
            else
            {
                int totalItem = new LessonDetailBCL().getCount(null);
                ViewBag.totalItem = totalItem;
            }
            return View(new LessonDetailBCL().getElementsByLessonId_PAGING(LessonId, pageIndex * pageSize, pageSize));
        }

        public ActionResult LessonDetail_Insert(Guid? LessonId, int Option)
        {
            ViewBag.LessonList = new LessonBCL().getElements();
            ViewBag.Option = Option;
            ViewBag.TagList = new LessonDetailTagBCL().getElements();
            LessonDetailObject objDetail = new LessonDetailObject();
            if (LessonId != null)
            {
                objDetail.LessonId = (Guid)LessonId;
            }
            return View(objDetail);
        }

        [HttpPost]
        public ActionResult LessonDetail_Insert(LessonDetailObject objDetail, int Option, string[] oldtag, string[] newtaglist)
        {
            objDetail.LessonDetailId = Guid.NewGuid();
            objDetail.TotalOfComment = 0;
            objDetail.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objDetail.ModifiedTime = DateTime.Now;
            objDetail.IsApproved = true;
            objDetail.ApprovedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objDetail.IsDeleted = false;
            new LessonDetailBCL().addElement(objDetail);
            InsertLessonDetailTag(objDetail.LessonDetailId, oldtag, newtaglist);

            if (Option == 0)
            {
                return RedirectToAction("Manage_LessonDetail", "LessonAdmin", new { pageIndex = 0 });
            }
            if (Option == 1)
            {
                return RedirectToAction("Lesson_Update", "LessonAdmin", new { LessonId = objDetail.LessonId });
            }
            return RedirectToAction("Manage_LessonDetail", "LessonAdmin", new { pageIndex = 0 });
        }

        public ActionResult LessonDetail_Update(Guid LessonDetailId, int Option)
        {
            ViewBag.LessonList = new LessonBCL().getElements();
            ViewBag.Option = Option;
            ViewBag.TagList = new LessonDetailTagBCL().getElements();
            ViewBag.MyTagList = new LessonDetailTagBCL().getByLessonDetail(LessonDetailId);
            return View(new LessonDetailBCL().getElementById(LessonDetailId));
        }

        [HttpPost]
        public ActionResult LessonDetail_Update(LessonDetailObject objDetail, int Option, string[] oldtag, string[] newtaglist)
        {
            new LessonDetailBCL().updateElement(objDetail);
            InsertLessonDetailTag(objDetail.LessonDetailId, oldtag, newtaglist);
            if (Option == 0)
            {
                return RedirectToAction("Manage_LessonDetail", "LessonAdmin", new { pageIndex = 0 });
            }
            if (Option == 1)
            {
                return RedirectToAction("Lesson_Update", "LessonAdmin", new { LessonId = objDetail.LessonId });
            }
            return RedirectToAction("Manage_LessonDetail", "LessonAdmin", new { pageIndex = 0 });
        }

        public JsonResult LessonDetailTag_CheckName(string TagName)
        {
            if (new LessonDetailTagBCL().CheckNameExisted(TagName))
                return Json(new { rs = "fail" });
            return Json(new { rs = "ok" });
        }

        public void InsertLessonDetailTag(Guid LessonDetailId, string[] tag, string[] newtag)
        {
            LessonDetailTagBCL tagBCL = new LessonDetailTagBCL();
            LessonDetailTagDetailBCL detailBCL = new LessonDetailTagDetailBCL();
            detailBCL.deleteElementByLessonDetail(LessonDetailId);
            if (tag != null)
            {
                foreach (var item in tag)
                {
                    detailBCL.addElement(new LessonDetailTagDetailObject()
                    {
                        LessonDetailId = LessonDetailId,
                        LessonDetailTagDetailId = Guid.NewGuid(),
                        LessonDetailTagId = Guid.Parse(item)
                    });
                }
            }
            if (newtag != null)
            {
                foreach (var item in newtag)
                {
                    if (item.Length > 0)
                    {
                        LessonDetailTagObject objTag = new LessonDetailTagObject();
                        objTag.LessonDetailTagId = Guid.NewGuid();
                        objTag.LessonDetailTagName = item;
                        objTag.TotalOfLessons = 0;
                        tagBCL.addElement(objTag);
                        detailBCL.addElement(new LessonDetailTagDetailObject()
                        {
                            LessonDetailId = LessonDetailId,
                            LessonDetailTagDetailId = Guid.NewGuid(),
                            LessonDetailTagId = objTag.LessonDetailTagId
                        });
                    }
                }
            }
        }

        [HttpPost]
        public JsonResult LessonDetail_Delete(Guid LessonDetailId)
        {
            try
            {
                new LessonDetailBCL().deleteElement(LessonDetailId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
            }
            return Json(new { result = true, message = "Xóa chi tiết bài học thành công!" });
        }
        #endregion

        #region LessonDetailTag
        public ActionResult Manage_LessonDetailTag()
        {
            return View(new LessonDetailTagBCL().getElements());
        }

        public ActionResult LessonDetailTag_Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LessonDetailTag_Insert(LessonDetailTagObject objTag)
        {
            LessonDetailTagBCL tagBcl = new LessonDetailTagBCL();
            if (tagBcl.CheckNameExisted(objTag.LessonDetailTagName))
            {
                ModelState.AddModelError("", "Tên tag đã bị trùng");
                return View(objTag);
            }
            objTag.LessonDetailTagId = Guid.NewGuid();
            objTag.TotalOfLessons = 0;
            tagBcl.addElement(objTag);
            return RedirectToAction("Manage_LessonDetailTag", "LessonAdmin");
        }

        public ActionResult LessonDetailTag_Update(Guid LessonDetailTagId)
        {
            return View(new LessonDetailTagBCL().getElementById(LessonDetailTagId));
        }

        [HttpPost]
        public ActionResult LessonDetailTag_Update(LessonDetailTagObject objTag)
        {
            LessonDetailTagBCL tagBcl = new LessonDetailTagBCL();
            if (tagBcl.CheckNameExisted(objTag.LessonDetailTagName))
            {
                ModelState.AddModelError("", "Tên tag đã bị trùng");
                return View(objTag);
            }
            tagBcl.updateElement(objTag);
            return RedirectToAction("Manage_LessonDetailTag", "LessonAdmin");
        }

        public JsonResult LessonDetailTag_Delete(Guid LessonDetailTagId)
        {
            new LessonDetailTagBCL().deleteElement(LessonDetailTagId);
            return Json(new { rs = "ok" });
        }
        #endregion

#region Comment

        public ActionResult ManageComment( Guid ArticleId ,string Title)
        {
            ViewBag.Title = Title;
            ViewBag.ArticleId = ArticleId;
            return View(new CommentBCL().GetCommentByArticle(ArticleId));
        }

        public ActionResult CommentInsert(Guid ArticleId)
        {
            ViewBag.ArticleId = ArticleId;
            return View();
        }

        [HttpPost]
        public ActionResult CommentInsert(CommentObject obj)
        {
            var objAcc = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]);
            obj.CommentId = Guid.NewGuid();
            obj.CommentBy = objAcc.AccountId;
            obj.ModifiedTime = DateTime.Now;
            obj.TotalOfDislikes = 0;
            obj.IsDeleted = false;
            obj.TotalOfReplies = 0;
            new CommentBCL().CommentInsert(obj);
            return RedirectToAction("ManageComment", "LessonAdmin", new { ArticleId=obj.ArticleId, Title ="" });
        }
        public ActionResult CommentUpdate(Guid id)
        {
            
            return View(new CommentBCL().GetCommentByID(id));
        }

        [HttpPost]
        public ActionResult CommentUpdate(CommentObject obj)
        {
            var objAcc = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]);
          
            obj.CommentBy = objAcc.AccountId;
            new CommentBCL().CommentUpdate(obj);
            return RedirectToAction("ManageComment", "LessonAdmin", new { ArticleId = obj.ArticleId, Title = "" });
        }

        [HttpPost]
        public JsonResult CommentDelete(Guid id)
        {
            new CommentBCL().CommentDelete(id);
            return Json(new {rs = "ok"});
        }

#endregion
    }
}