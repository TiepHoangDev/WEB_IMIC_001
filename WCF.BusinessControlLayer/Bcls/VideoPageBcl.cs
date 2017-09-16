using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class VideoPageBcl
    {
        public List<VideoCategoryObject> GetVideoCategoriesAll()
        {
            return new VideoCategoryDao().getForView();
        }

        public List<VideoCategoryObject> GetVideoCategoriesForAdmin()
        {
            return new VideoCategoryDao().getForAdmin();
        }

        public VideoCategoryObject GetVideoCategoriesByVCCodeNumber(int VCCodeNumber)
        {
            return new VideoCategoryDao().getElementsByVCCodeNumber(VCCodeNumber);
        }

        public VideoCategoryObject GetVideoCategoriesById(Guid VideoCategoryId)
        {
            return new VideoCategoryDao().getElementsById(VideoCategoryId);
        }

        public List<VideoCategoryObject> GetVideoCategoriesForDislay()
        {
            return new VideoCategoryDao().getForDislay();
        }

        public List<VideoBannerObject> GetVideoBannerAll()
        {
            return new VideoBannerDao().getForView();
        }

        public List<VideoObject> GetVideoByVideoCategoryID(Guid VideoCategoryId)
        {
            return new VideoDao().getByVideoCategoryID(VideoCategoryId);
        }

        public List<VideoObject> GetVideoByVideoCategoryCodeNumber(int VCCodeNumber)
        {
            return new VideoDao().getByVideoCategoryCodeNumber(VCCodeNumber);
        }

        public List<VideoObject> GetVideoForView()
        {
            return new VideoDao().getForView();
        }

        public List<VideoObject> GetPendingVideo()
        {
            return new VideoDao().getPendingVideo();
        }

        public List<VideoObject> GetByAccount(Guid AccountID)
        {
            return new VideoDao().getByAccount(AccountID);
        }

        public List<VideoObject> GetForViewerByAccount(Guid AccountID)
        {
            return new VideoDao().getForViewerByAccount(AccountID);
        }

        public List<VideoObject> GetPendingVideoByCategoryCodeNumber(int vcCodeNumber)
        {
            return new VideoDao().getPendingVideoByCategoryCodeNumber(vcCodeNumber);
        }

        public List<VideoObject> GetInvolveVideo(Guid VideoID, Guid VideoCategoryID)
        {
            return new VideoDao().getInvolveVideo(VideoID, VideoCategoryID);
        }

        public List<VideoObject> GetVideoInPlaylist(Guid VideoID, Guid VideoSubCategoryID)
        {
            return new VideoDao().getVideoInPlaylist(VideoID, VideoSubCategoryID);
        }

        public VideoObject getVideoByID(Guid VideoID)
        {
            return new VideoDao().getByID(VideoID);
        }

        public VideoObject getVideoByVideoCodeNumber(string VideoCodeNumber)
        {
            return new VideoDao().getByVideoCodeNumber(VideoCodeNumber);
        }

        public List<VideoCommentObject> GetVideoCommentByVideoID(Guid VideoID)
        {
            return new VideoCommentDao().getAllByVideoID(VideoID);
        }

        public VideoCommentObject GetVideoCommentByID(Guid VideoCommentID)
        {
            return new VideoCommentDao().getByID(VideoCommentID);
        }

        public List<VideoCommentReplyObject> GetVideoCommentReplyByVideoCommentID(Guid VideoCommentID, Guid? AccountId)
        {
            return new VideoCommentReplyDao().getAllByVideoCommentID(VideoCommentID, AccountId);
        }

        public VideoCommentReplyObject GetVideoCommentReplyByID(Guid VideoCommentReplyID)
        {
            return new VideoCommentReplyDao().getByID(VideoCommentReplyID);
        }

        public bool checkVideoLike(Guid videoID, Guid userID)
        {
            return new VideoLikeDao().checkUserLike(videoID, userID);
        }

        public bool checkVideoCommentLike(Guid videoCommentID, Guid userID)
        {
            return new VideoCommentLikeDao().checkUserLike(videoCommentID, userID);
        }

        public bool checkVideoCommentReplyLike(Guid videoCommentReplyID, Guid userID)
        {
            return new VideoCommentReplyLikeDao().checkUserLike(videoCommentReplyID, userID);
        }

        public List<VideoSubCategoryObject> getAllSubCategory()
        {
            return new VideoSubCategoryDao().getAll();
        }

        public List<VideoSubCategoryObject> getSubCategoryByAccountID(Guid AccountID)
        {
            return new VideoSubCategoryDao().getByAccountID(AccountID);
        }

        public VideoSubCategoryObject getSubCategoryByID(Guid SubCategoryId)
        {
            return new VideoSubCategoryDao().getByID(SubCategoryId);
        }

        //Paging
        public List<VideoCategoryObject> getVideoCategoriesForDisplay_Paging(int start, int length)
        {
            return new VideoCategoryDao().getForDislay_Paging(start, length);
        }

        public List<VideoObject> getTop10Videos()
        {
            return new VideoDao().getTop10Video();
        }

        public List<VideoObject> getVideoByCategoryCode_Paging(int CategoryCodeNumber, int start, int length)
        {
            return new VideoDao().getByCategoryCode_Paging(CategoryCodeNumber, start, length);
        }

        public List<VideoObject> getInvolveVideo_PAGING(int Start, int Length, Guid VideoID, Guid VideoCategoryID)
        {
            return new VideoDao().getInvolveVideo_PAGING(Start, Length, VideoID, VideoCategoryID);
        }

        public List<VideoCommentObject> getCommentByVideoID_PAGING(Guid VideoID, Guid? AccountId, int Start, int Length)
        {
            return new VideoCommentDao().getByVideoID_PAGING(VideoID, AccountId, Start, Length);
        }


        //Insert, Update and Delete
        public bool InsertCategory(VideoCategoryObject objVideoCategory)
        {
            return new VideoCategoryDao().Insert(objVideoCategory);
        }

        public bool UpdateCategory(VideoCategoryObject objVideoCategory)
        {
            return new VideoCategoryDao().Update(objVideoCategory);
        }

        public bool DeleteCategory(Guid VideoCategoryId)
        {
            return new VideoCategoryDao().Delete(VideoCategoryId);
        }

        public bool InsertVideo(VideoObject objVideo)
        {
            return new VideoDao().Insert(objVideo);
        }

        public bool UpdateVideo(VideoObject objVideo)
        {
            return new VideoDao().Update(objVideo);
        }

        public bool DeleteVideo(Guid videoID)
        {
            return new VideoDao().Delete(videoID);
        }

        public bool InsertComment(VideoCommentObject objVideoCmt)
        {
            return new VideoCommentDao().Insert(objVideoCmt);
        }

        public bool UpdateComment(VideoCommentObject objVideoCmt)
        {
            return new VideoCommentDao().Update(objVideoCmt);
        }

        public bool DeleteComment(Guid VideoCommentId)
        {
            return new VideoCommentDao().Delete(VideoCommentId);
        }

        public void AddVideoLike(VideoLikeObject objVideoLike)
        {
            new VideoLikeDao().Insert(objVideoLike);
        }

        public void DeleteVideoLike(Guid VideoId, Guid AccountId)
        {
            new VideoLikeDao().Delete(VideoId, AccountId);
        }

        public void AddVideoCommentLike(VideoCommentLikeObject objVideoCmtLike)
        {
            new VideoCommentLikeDao().Insert(objVideoCmtLike);
        }

        public void DeleteVideoCommentLike(VideoCommentLikeObject objVideoCmtLike)
        {
            new VideoCommentLikeDao().Delete(objVideoCmtLike);
        }

        public bool InsertVideoSubCategory(VideoSubCategoryObject objSubCategory)
        {
            return new VideoSubCategoryDao().Insert(objSubCategory);
        }

        public bool UpdateVideoSubCategory(VideoSubCategoryObject objSubCategory)
        {
            return new VideoSubCategoryDao().Update(objSubCategory);
        }

        public bool DeleteVideoSubCategory(Guid VideoSubCategoryId)
        {
            return new VideoSubCategoryDao().Delete(VideoSubCategoryId);
        }

        public bool InsertCommentReply(VideoCommentReplyObject objReply)
        {
            return new VideoCommentReplyDao().Insert(objReply);
        }

        public bool UpdateCommentReply(VideoCommentReplyObject objReply)
        {
            return new VideoCommentReplyDao().Update(objReply);
        }

        public bool DeleteCommentReply(Guid VideoCommentReplyId)
        {
            return new VideoCommentReplyDao().Delete(VideoCommentReplyId);
        }

        public void AddVideoCommentReplyLike(VideoCommentReplyLikeObject objVideoReplyLike)
        {
            new VideoCommentReplyLikeDao().Insert(objVideoReplyLike);
        }

        public void DeleteVideoCommentReplyLike(VideoCommentReplyLikeObject objVideoReplyLike)
        {
            new VideoCommentReplyLikeDao().Delete(objVideoReplyLike);
        }
    }
}
