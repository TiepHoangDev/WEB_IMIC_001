using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Controllers
{
    public class VideoPageController : Controller
    {
        // GET: Video
        public ActionResult Academy()
        {
            return View();
        }
        public ActionResult Index_new()
        {
            var lstCate =  new VideoPageBcl().GetVideoCategoriesAll();
            return View(lstCate);
        }

        public ActionResult List_video(int catcode)
        {
            var lstvideo = new VideoPageBcl().GetVideoByVideoCategoryCodeNumber(catcode);
            return PartialView(lstvideo);
        }

        public ActionResult Index(int vcCodeNumber = 0)
        {
            ViewBag.vcCodeNumber = vcCodeNumber;
            return View(new VideoPageBcl().GetVideoCategoriesForDislay().OrderBy(n => n.VCCodeNumber));
        }

        public ActionResult Index_CategorySearch()
        {
            return View(new VideoPageBcl().GetVideoCategoriesAll().OrderBy(n => n.VCCodeNumber));
        }

        public ActionResult Index_VideoBanner()
        {
            return View(new VideoPageBcl().GetVideoBannerAll());
        }

        public ActionResult Index_ListVideoCategory(int pageIndex, int vcCodeNumber)
        {
            int pageSize = 3;
            ViewBag.vcCodeNumber = vcCodeNumber;
            if (vcCodeNumber == 0)
            {
                var lisAll =
                new VideoPageBcl().getVideoCategoriesForDisplay_Paging(pageIndex * pageSize, pageSize);
                return View(lisAll);
            }
            else
            {
                var lisData =
                new VideoPageBcl().GetVideoCategoriesByVCCodeNumber(vcCodeNumber);
                return View(lisData);
            }
        }

        public ActionResult Index_VideoCategoryDetail(int vcCodeNumber)
        {
            var lisData =
                new VideoPageBcl().GetVideoCategoriesByVCCodeNumber(vcCodeNumber);
            return View(lisData);
        }

        public ActionResult Index_ListTopVideo(int pageIndex, int vcCodeNumber)
        {
            ViewBag.vcCodeNumber = vcCodeNumber;
            if (vcCodeNumber == 0)
            {
                var lisAll =
                new VideoPageBcl().getTop10Videos();
                return View(lisAll);
            }
            else
            {
                int pageSize = 15;
                var lisData =
                new VideoPageBcl().getVideoByCategoryCode_Paging(vcCodeNumber, pageIndex * pageSize, pageSize);
                return View(lisData);
            }
        }

        public ActionResult Index_ListVideo(int pageIndex, int vcCodeNumber)
        {
            int pageSize = 10;
            var lisData =
            new VideoPageBcl().getVideoByCategoryCode_Paging(vcCodeNumber, pageIndex * pageSize, pageSize);
            return View(lisData);
        }

        //Chi tiết Video
         [ValidateInput(false)]
        [HttpPost]
        public JsonResult getvideo(string code)
        {
            var item = new VideoPageBcl().getVideoByVideoCodeNumber(code);
             return
                 Json(new {result = true, name = item.VideoName, src = item.VideoLink, sumary = item.VideoDescription , view=item.TotalOfViews});
        }



        public ActionResult VideoDetail(string videoCodeNumber)
        {
            var item = new VideoPageBcl().getVideoByVideoCodeNumber(videoCodeNumber);
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objUser != null)
            {
                bool liked = new VideoPageBcl().checkVideoLike(item.VideoId, objUser.AccountId);
                ViewBag.liked = liked;
                ViewBag.accountId = objUser.AccountId;
            }
            else
            {
                ViewBag.liked = false;
                ViewBag.accountId = null;
            }
            ViewBag.vcCodeNumber = 0;
            ViewBag.videoID = item.VideoId;
            item.TotalOfViews = item.TotalOfViews + 1;
            new VideoPageBcl().UpdateVideo(item);
            return View(item);
        }

        public ActionResult VideoDetail_Comment(int pageIndex, Guid VideoId)
        {
            int pageSize = 3;
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objUser != null)
            {
                var lisData = new VideoPageBcl().getCommentByVideoID_PAGING(VideoId, objUser.AccountId, pageIndex * pageSize, pageSize);
                return View(lisData);
            }
            else
            {
                var lisData = new VideoPageBcl().getCommentByVideoID_PAGING(VideoId, null, pageIndex * pageSize, pageSize);
                return View(lisData);
            }
        }

        public ActionResult VideoDetail_CommentReply(Guid VideoCommentId)
        {
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objUser != null)
            {
                var lisData = new VideoPageBcl().GetVideoCommentReplyByVideoCommentID(VideoCommentId, objUser.AccountId);
                return View(lisData);
            }
            else
            {
                var lisData = new VideoPageBcl().GetVideoCommentReplyByVideoCommentID(VideoCommentId, null);
                return View(lisData);
            }
        }

        public ActionResult VideoDetail_Playlist(Guid VideoID, Guid VideoSubCategoryID)
        {
            var lisData = new VideoPageBcl().GetVideoInPlaylist(VideoID, VideoSubCategoryID).OrderByDescending(x => x.ModifiedTime);
            return View(lisData);
        }

        public ActionResult VideoDetail_InvolveVideo(int pageIndexInvolve, Guid VideoID, Guid VideoCategoryID)
        {
            int pageSize = 4;
            var lisData = new VideoPageBcl().getInvolveVideo_PAGING(pageIndexInvolve * pageSize, pageSize, VideoID, VideoCategoryID);
            return View(lisData);
        }

        [HttpPost]
        public JsonResult VideoDetail_PostComment(string contentComment, Guid videoID)
        {
            AccountObject objAcc = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objAcc != null)
            {
                string contentAfter = "";
                string[] arrContent = contentComment.Split('\n');
                foreach (var item in arrContent)
                {
                    contentAfter = contentAfter + item + "<br/>";
                }
                contentComment = HttpUtility.HtmlEncode(contentComment);
                VideoCommentObject objCmt = new VideoCommentObject();
                objCmt.VideoCommentId = Guid.NewGuid();
                objCmt.VideoId = videoID;
                objCmt.CommentBy = objAcc.AccountId;
                objCmt.ContentComment = contentAfter;
                objCmt.TotalOfReplies = 0;
                objCmt.TotalOfLikes = 0;
                objCmt.TotalOfDislikes = 0;
                objCmt.ModifiedTime = DateTime.Now;
                objCmt.IsDeleted = false;
                new VideoPageBcl().InsertComment(objCmt);
                return Json(new { rs = objCmt.VideoCommentId, contentComment = contentAfter });
            }
            return Json(new { rs = "fail" });           
        }

        [HttpPost]
        public JsonResult VideoDetail_LikeVideo(Guid videoId, Guid accountId, bool status, string LikeCount)
        {
            decimal count = decimal.Parse(LikeCount);
            try
            {
                if (status == false)
                {
                    VideoLikeObject objLike = new VideoLikeObject();
                    objLike.VideoLikeId = Guid.NewGuid();
                    objLike.VideoId = videoId;
                    objLike.LikeBy = accountId;
                    objLike.CreatedTime = DateTime.Now;
                    count = count + 1;
                    new VideoPageBcl().AddVideoLike(objLike);
                }
                else
                {
                    count = count - 1;
                    new VideoPageBcl().DeleteVideoLike(videoId, accountId);
                }
            }
            catch (Exception e)
            {
                return Json(new { result = false, Message = "An error has occured during data transfer" });
            }
            return Json(new { result = true, LikeCount = count.ToString("n0") });
        }

        public JsonResult VideoDetail_LikeComment(Guid CommentId, string LikeCount)
        {
            decimal count = decimal.Parse(LikeCount);
            try
            {
                VideoPageBcl videoPageBcl = new VideoPageBcl();
                AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
                VideoCommentLikeObject objLike = new VideoCommentLikeObject()
                {
                    VideoCommentLikeId = Guid.NewGuid(),
                    VideoCommentId = CommentId,
                    LikeBy = objAccount.AccountId,
                    CreatedTime = DateTime.Now
                };
                if (!videoPageBcl.checkVideoCommentLike(objLike.VideoCommentId, objLike.LikeBy))
                {
                    videoPageBcl.AddVideoCommentLike(objLike);
                    count = count + 1;
                    return Json(new { rs = "like", likeCount = count.ToString("n0") });
                }
                else
                {
                    videoPageBcl.DeleteVideoCommentLike(objLike);
                    count = count - 1;
                    return Json(new { rs = "unlike", likeCount = count.ToString("n0") });
                }

            }
            catch (Exception e)
            {
                return Json(new { rs = "fail" });
            }
        }

        [HttpPost]
        public JsonResult VideoDetail_ReplyComment(Guid CommentId, string ContentReply)
        {
            AccountObject objAcc = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objAcc != null)
            {
                VideoCommentReplyObject objReply = new VideoCommentReplyObject();
                objReply.VideoCommentReplyId = Guid.NewGuid();
                objReply.VideoCommentId = CommentId;
                objReply.ReplyBy = objAcc.AccountId;
                objReply.ContentReply = ContentReply;
                objReply.TotalOfLikes = 0;
                objReply.TotalOfDislikes = 0;
                objReply.ModifiedTime = DateTime.Now;
                objReply.IsDeleted = false;
                new VideoPageBcl().InsertCommentReply(objReply);
                return Json(new { rs = objReply.VideoCommentReplyId });
            }
            return Json(new { rs = "fail" }); 
        }

        public JsonResult VideoDetail_LikeCommentReply(Guid CommentReplyId, string LikeCount)
        {
            decimal count = decimal.Parse(LikeCount);
            try
            {
                VideoPageBcl videoPageBcl = new VideoPageBcl();
                AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
                VideoCommentReplyLikeObject objLike = new VideoCommentReplyLikeObject()
                {
                    VideoCommentReplyLikeId = Guid.NewGuid(),
                    VideoCommentReplyId = CommentReplyId,
                    LikedBy = objAccount.AccountId,
                    CreatedTime = DateTime.Now
                };
                if (!videoPageBcl.checkVideoCommentReplyLike(objLike.VideoCommentReplyId, objLike.LikedBy))
                {
                    videoPageBcl.AddVideoCommentReplyLike(objLike);
                    count = count + 1;
                    return Json(new { rs = "like", likeCount = count.ToString("n0") });
                }
                else
                {
                    videoPageBcl.DeleteVideoCommentReplyLike(objLike);
                    count = count - 1;
                    return Json(new { rs = "unlike", likeCount = count.ToString("n0") });
                }

            }
            catch (Exception e)
            {
                return Json(new { rs = "fail" });
            }
        }

        public ActionResult VideoDetail_Tags(string VideoCodeNumber)
        {
            return View(new VideoTagBcl().getByVideoCode(VideoCodeNumber));
        }
    }
}