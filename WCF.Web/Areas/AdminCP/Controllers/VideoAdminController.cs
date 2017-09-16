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
    public class VideoAdminController : Controller
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
        // GET: AdminCP/VideoAdmin
        public ActionResult Index()
        {
            return View();
        }

        #region Category
        public ActionResult Manage_Category()
        {
            return View(new VideoPageBcl().GetVideoCategoriesForAdmin().OrderBy(x => x.VCCodeNumber));
        }

        public ActionResult Category_Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Category_Insert(VideoCategoryObject objVideoCategory)
        {
            objVideoCategory.VideoCategoryId = Guid.NewGuid();
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Video/Categories"), fileName);
                file.SaveAs(path);
                objVideoCategory.VideoCategoryIcon = fileName;
            }
            objVideoCategory.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objVideoCategory.ModifiedTime = DateTime.Now;
            objVideoCategory.IsDeleted = false;
            new VideoPageBcl().InsertCategory(objVideoCategory);
            return RedirectToAction("Manage_Category", "VideoAdmin");
        }

        public ActionResult Category_Edit(Guid VideoCategoryId)
        {
            return View(new VideoPageBcl().GetVideoCategoriesById(VideoCategoryId));
        }   

        [HttpPost]
        public ActionResult Category_Edit(VideoCategoryObject objCategory)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var extension = "." + Path.GetFileName(file.FileName).Split('.')[1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Video/Categories"), fileName);
                file.SaveAs(path);
                objCategory.VideoCategoryIcon = fileName;
            }
            objCategory.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objCategory.ModifiedTime = DateTime.Now;
            new VideoPageBcl().UpdateCategory(objCategory);

            return RedirectToAction("Manage_Category", "VideoAdmin");
        }

        [HttpPost]
        public JsonResult Delete_VideoCategory(Guid VideoCategoryId)
        {
            try
            {
                new VideoPageBcl().DeleteCategory(VideoCategoryId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "An error has occured during data transfer" });
            }
            return Json(new { result = true });
        }
        #endregion

        #region Video
        public ActionResult Manage_Video(int vcCodeNumber)
        {
            List<VideoCategoryObject> listCategory = new VideoPageBcl().GetVideoCategoriesForAdmin();
            ViewBag.CategoryList = listCategory;
            ViewBag.vcCodeNumber = vcCodeNumber;
            if (vcCodeNumber == 0)
            {
                return View(new VideoPageBcl().GetVideoForView());
            }
            else
            {
                return View(new VideoPageBcl().GetVideoByVideoCategoryCodeNumber(vcCodeNumber));
            }
        }

        public ActionResult Manage_PendingVideo(int vcCodeNumber)
        {
            List<VideoCategoryObject> listCategory = new VideoPageBcl().GetVideoCategoriesForAdmin();
            ViewBag.CategoryList = listCategory;
            ViewBag.vcCodeNumber = vcCodeNumber;
            if (vcCodeNumber == 0)
            {
                return View(new VideoPageBcl().GetPendingVideo());
            }
            else
            {
                return View(new VideoPageBcl().GetPendingVideoByCategoryCodeNumber(vcCodeNumber));
            }
        }

        public ActionResult Video_Insert()
        {
            List<VideoCategoryObject> listCategory = new VideoPageBcl().GetVideoCategoriesForAdmin();
            ViewBag.CategoryList = listCategory;
            AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objAccount.RoleId == CommonConstants.ROLE_ADMIN || objAccount.RoleId == CommonConstants.ROLE_SYSADMIN)
                ViewBag.EditorList = new TechArticleBcl().getEditorAccount();
            ViewBag.TagList = new VideoTagBcl().getElements();
            return View();
        }

        [HttpPost]
        public ActionResult Video_Insert(VideoObject objVideo, string[] oldtag, string[] newtaglist)
        {
            objVideo.VideoId = Guid.NewGuid();

            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                String[] arrFilename = Path.GetFileName(file.FileName).Split('.');
                var extension = "." + arrFilename[arrFilename.Length - 1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Video/Thumbnails"), fileName);
                file.SaveAs(path);
                objVideo.VideoThumbnail = fileName;
            }
            objVideo.VideoCodeNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
            objVideo.TotalOfComments = 0;
            objVideo.ModifiedTime = DateTime.Now;
            objVideo.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objVideo.IsApproved = false;
            objVideo.CreatedTime = DateTime.Now;
            if (objVideo.CreatedBy == null)
            {
                objVideo.CreatedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            }
            objVideo.IsDeleted = false;
            new VideoPageBcl().InsertVideo(objVideo);
            InsertVideoTag(objVideo.VideoId, oldtag, newtaglist);
            return RedirectToAction("Manage_PendingVideo", "VideoAdmin", new { vcCodeNumber = 0 });
        }

        public ActionResult Video_Edit(Guid VideoId)
        {
            VideoObject objVideo = new VideoPageBcl().getVideoByID(VideoId);
            List<VideoCategoryObject> listCategory = new VideoPageBcl().GetVideoCategoriesForAdmin();
            ViewBag.CategoryList = listCategory;
            AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objAccount.RoleId == CommonConstants.ROLE_ADMIN || objAccount.RoleId == CommonConstants.ROLE_SYSADMIN)
                ViewBag.EditorList = new TechArticleBcl().getEditorAccount();
            ViewBag.TagList = new VideoTagBcl().getElements();
            ViewBag.MyTagList = new VideoTagBcl().getByVideoCode(objVideo.VideoCodeNumber);
            return View(objVideo);
        }

        [HttpPost]
        public ActionResult Video_Edit(VideoObject objVideo, string[] oldtag, string[] newtaglist)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                String[] arrFilename = Path.GetFileName(file.FileName).Split('.');
                var extension = "." + arrFilename[arrFilename.Length - 1];
                var fileName = "IMG_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + extension;
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Video/Thumbnails"), fileName);
                file.SaveAs(path);
                objVideo.VideoThumbnail = fileName;
            }
            objVideo.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objVideo.ModifiedTime = DateTime.Now;
            objVideo.IsDeleted = false;

            new VideoPageBcl().UpdateVideo(objVideo);
            InsertVideoTag(objVideo.VideoId, oldtag, newtaglist);
            return RedirectToAction("Manage_Video", "VideoAdmin", new { vcCodeNumber = 0 });
        }

        [HttpPost]
        public JsonResult Approve_Video(Guid VideoId)
        {
            try
            {
                VideoObject objVideo = new VideoPageBcl().getVideoByID(VideoId);
                objVideo.IsApproved = true;
                objVideo.ApprovedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
                new VideoPageBcl().UpdateVideo(objVideo);
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "An error has occured during data transfer" });
            }
            return Json(new { result = true });
        }

        [HttpPost]
        public JsonResult Delete_Video(Guid VideoId)
        {
            try
            {
                new VideoPageBcl().DeleteVideo(VideoId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "An error has occured during data transfer" });
            }
            return Json(new { result = true });
        }

        public JsonResult VideoTag_CheckName(string TagName)
        {
            if (new VideoTagBcl().CheckNameExisted(TagName))
                return Json(new { rs = "fail" });
            return Json(new { rs = "ok" });
        }

        public void InsertVideoTag(Guid VideoId, string[] tag, string[] newtag)
        {
            VideoTagBcl tagBCL = new VideoTagBcl();
            VideoTagDetailBcl detailBCL = new VideoTagDetailBcl();
            detailBCL.deleteElementByVideo(VideoId);
            if (tag != null)
            {
                foreach (var item in tag)
                {
                    detailBCL.addElement(new VideoTagDetailObject()
                    {
                        VideoId = VideoId,
                        VideoTagDetailId = Guid.NewGuid(),
                        VideoTagId = Guid.Parse(item)
                    });
                }
            }
            if (newtag != null)
            {
                foreach (var item in newtag)
                {
                    if (item.Length > 0)
                    {
                        VideoTagObject objTag = new VideoTagObject();
                        objTag.VideoTagId = Guid.NewGuid();
                        objTag.VideoTagName = item;
                        objTag.TotalOfVideos = 0;
                        tagBCL.addElement(objTag);
                        detailBCL.addElement(new VideoTagDetailObject()
                        {
                            VideoId = VideoId,
                            VideoTagDetailId = Guid.NewGuid(),
                            VideoTagId = objTag.VideoTagId
                        });
                    }
                }
            }
        }
        #endregion

        #region VideoTag
        public ActionResult Manage_VideoTag()
        {
            return View(new VideoTagBcl().getElements());
        }

        public ActionResult VideoTag_Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VideoTag_Insert(VideoTagObject objTag)
        {
            VideoTagBcl tagBcl = new VideoTagBcl();
            if (tagBcl.CheckNameExisted(objTag.VideoTagName))
            {
                ModelState.AddModelError("", "Tên tag đã bị trùng");
                return View(objTag);
            }
            objTag.VideoTagId = Guid.NewGuid();
            objTag.TotalOfVideos = 0;
            tagBcl.addElement(objTag);
            return RedirectToAction("Manage_VideoTag", "VideoAdmin");
        }

        public ActionResult VideoTag_Edit(Guid VideoTagId)
        {
            return View(new VideoTagBcl().getByID(VideoTagId));
        }

        [HttpPost]
        public ActionResult VideoTag_Edit(VideoTagObject objTag)
        {
            VideoTagBcl tagBcl = new VideoTagBcl();
            if (tagBcl.CheckNameExisted(objTag.VideoTagName))
            {
                ModelState.AddModelError("", "Tên tag đã bị trùng");
                return View(objTag);
            }
            tagBcl.updateElement(objTag);
            return RedirectToAction("Manage_VideoTag", "VideoAdmin");
        }

        public JsonResult VideoTag_Delete(Guid VideoTagId)
        {
            new VideoTagBcl().deleteElement(VideoTagId);
            return Json(new { rs = "ok" });
        }
        #endregion

        #region Playlist
        public ActionResult Manage_SubCategory()
        {
            return View(new VideoPageBcl().getAllSubCategory());
        }

        public ActionResult SubCategory_Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubCategory_Insert(VideoSubCategoryObject objSubCategory)
        {
            objSubCategory.VideoSubCategoryID = Guid.NewGuid();
            objSubCategory.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objSubCategory.ModifiedTime = DateTime.Now;
            objSubCategory.TotalVideo = 0;
            objSubCategory.IsDeleted = false;
            new VideoPageBcl().InsertVideoSubCategory(objSubCategory);
            return RedirectToAction("Manage_SubCategory", "VideoAdmin");
        }

        public ActionResult SubCategory_Edit(Guid SubCategoryId)
        {
            return View(new VideoPageBcl().getSubCategoryByID(SubCategoryId));
        }

        [HttpPost]
        public ActionResult SubCategory_Edit(VideoSubCategoryObject objSubCategory)
        {
            objSubCategory.ModifiedBy = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]).AccountId;
            objSubCategory.ModifiedTime = DateTime.Now;
            new VideoPageBcl().UpdateVideoSubCategory(objSubCategory);
            return RedirectToAction("Manage_SubCategory", "VideoAdmin");
        }
        #endregion

        #region Video Comments
        public ActionResult Manage_VideoComments(Guid VideoId, string VideoName)
        {
            ViewBag.Title = VideoName;
            return View(new VideoPageBcl().GetVideoCommentByVideoID(VideoId));
        }

        public JsonResult Delete_VideoComments(Guid VideoCommentId)
        {
            try
            {
                new VideoPageBcl().DeleteComment(VideoCommentId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
            }
            return Json(new { result = true, message = "Đã xóa bình luận!" });
        }

        public JsonResult Save_VideoComments(Guid VideoCommentId, string content, int likeCount)
        {
            try
            {
                VideoCommentObject objCmt = new VideoPageBcl().GetVideoCommentByID(VideoCommentId);
                objCmt.ContentComment = content;
                objCmt.TotalOfLikes = likeCount;
                new VideoPageBcl().UpdateComment(objCmt);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
            }
            return Json(new { result = true, message = "Sửa bình luận thành công!" });
        }

        public ActionResult Manage_VideoReplies(Guid VideoCommentId)
        {
            return View(new VideoPageBcl().GetVideoCommentReplyByVideoCommentID(VideoCommentId, null));
        }

        public JsonResult Delete_VideoCommentReply(Guid VideoCommentReplyId)
        {
            try
            {
                //new VideoPageBcl().DeleteComment(VideoCommentId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
            }
            return Json(new { result = true, message = "Đã xóa bình luận!" });
        }

        public JsonResult Save_VideoCommentReply(Guid VideoCommentReplyId, string content, int likeCount)
        {
            try
            {
                //VideoCommentObject objCmt = new VideoPageBcl().GetVideoCommentByID(VideoCommentId);
                //objCmt.ContentComment = content;
                //objCmt.TotalOfLikes = likeCount;
                //new VideoPageBcl().UpdateComment(objCmt);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
            }
            return Json(new { result = true, message = "Sửa bình luận thành công!" });
        }
        #endregion
    }
}