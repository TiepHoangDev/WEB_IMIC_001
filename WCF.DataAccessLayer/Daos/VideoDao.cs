using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoDao : BaseModel<VideoObject>
    {
        public List<VideoObject> getForView()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetForView().ToList();

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }

            return lisRs;
        }

        public List<VideoObject> getPendingVideo()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetPendingVideo().ToList();

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }

            return lisRs;
        }

        public List<VideoObject> getPendingVideoByCategoryCodeNumber(int vcCodeNumber)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetPendingVideoByVideoCategoryNumber(vcCodeNumber).ToList();

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }

            return lisRs;
        }

        public List<VideoObject> getByVideoCategoryID(Guid VideoCategoryID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetForViewByVideoCategoryId(VideoCategoryID).ToList();

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }

            return lisRs;
        }

        public List<VideoObject> getByVideoCategoryCodeNumber(int VCCodeNumber)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetForViewByVideoCategoryNumber(VCCodeNumber).ToList();

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }

            return lisRs;
        }

        public List<VideoObject> getInvolveVideo(Guid VideoID, Guid VideoCategoryID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetInvolveVideoForView(VideoID, VideoCategoryID).ToList();

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }

            return lisRs;
        }

        public List<VideoObject> getVideoInPlaylist(Guid VideoID, Guid VideoSubCategoryID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetVideoInPlaylistForView(VideoID, VideoSubCategoryID).ToList();

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }

            return lisRs;
        }

        public List<VideoObject> getByAccount(Guid AccountID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetByAccountID(AccountID);

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }
            return lisRs;
        }

        public List<VideoObject> getForViewerByAccount(Guid AccountID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetForViewByAccountID(AccountID);

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                lisRs.Add(objVideo);
            }
            return lisRs;
        }

        public VideoObject getByID(Guid VideoID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetById(VideoID).ToList();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                return objVideo;
            }

            return null;
        }

        public VideoObject getByVideoCodeNumber(string videoCodeNumber)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetByVideoCodeNumber(videoCodeNumber).ToList();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = item.VideoCategoryId.GetValueOrDefault();
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId.GetValueOrDefault();
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.VideoLink = item.VideoLink + "";
                objVideo.VideoDescription = item.VideoDescription + "";
                objVideo.TotalOfViews = item.TotalOfViews.GetValueOrDefault();
                objVideo.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objVideo.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objVideo.TotalOfComments = item.TotalOfComments;
                objVideo.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objVideo.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objVideo.IsApproved = item.IsApproved.GetValueOrDefault();
                objVideo.ApprovedBy = item.ApprovedBy.GetValueOrDefault();
                objVideo.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objVideo.CreatedBy = item.CreatedBy.GetValueOrDefault();
                objVideo.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objVideo.Account = objAcc;
                return objVideo;
            }

            return null;
        }

        //Paging
        public List<VideoObject> getTop10Video()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetForView_GetTop10();
            List<VideoObject> lisRs = new List<VideoObject>();
            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = (Guid)item.VideoCategoryId;
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId;
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName;
                objVideo.VideoThumbnail = item.VideoThumbnail;
                objVideo.TotalOfViews = (int)item.TotalOfViews;
                objVideo.CreatedBy = (Guid)item.CreatedBy;
                objVideo.IsDeleted = (bool)item.IsDeleted;
                AccountObject objAccount = new AccountObject();
                objAccount.AccountId = (Guid)item.AccountId;
                objAccount.Username = item.Username;
                objAccount.FullName = item.FullName;
                objVideo.Account = objAccount;
                lisRs.Add(objVideo);
            }
            return lisRs;
        }

        public List<VideoObject> getForView_Paging(int start, int length)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetForView_PAGING(start, length);
            List<VideoObject> lisRs = new List<VideoObject>();
            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = (Guid)item.VideoCategoryId;
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId;
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName;
                objVideo.VideoThumbnail = item.VideoThumbnail;
                objVideo.TotalOfViews = (int)item.TotalOfViews;
                objVideo.CreatedBy = (Guid)item.CreatedBy;
                objVideo.IsDeleted = (bool)item.IsDeleted;
                AccountObject objAccount = new AccountObject();
                objAccount.AccountId = (Guid)item.AccountId;
                objAccount.Username = item.Username;
                objAccount.FullName = item.FullName;
                objVideo.Account = objAccount;
                lisRs.Add(objVideo);
            }
            return lisRs;
        }

        public List<VideoObject> getByCategoryCode_Paging(int CategoryCode, int start, int length)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetForViewByVideoCategoryNumber_PAGING(CategoryCode, start, length);
            List<VideoObject> lisRs = new List<VideoObject>();
            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = (Guid)item.VideoCategoryId;
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId;
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName;
                objVideo.VideoThumbnail = item.VideoThumbnail;
                objVideo.TotalOfViews = (int)item.TotalOfViews;
                objVideo.CreatedBy = (Guid)item.CreatedBy;
                AccountObject objAccount = new AccountObject();
                objAccount.AccountId = (Guid)item.AccountId;
                objAccount.Username = item.Username;
                objAccount.FullName = item.FullName;
                objVideo.Account = objAccount;
                lisRs.Add(objVideo);
            }
            return lisRs;
        }

        public List<VideoObject> getInvolveVideo_PAGING(int Start, int Length, Guid VideoID, Guid VideoCategoryID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_Video_GetInvolveVideoForView_PAGING(Start, Length, VideoID, VideoCategoryID);

            List<VideoObject> lisRs = new List<VideoObject>();

            foreach (var item in lisGet)
            {
                VideoObject objVideo = new VideoObject();
                objVideo.VideoId = item.VideoId;
                objVideo.VideoCategoryId = (Guid)item.VideoCategoryId;
                objVideo.VideoSubCategoryId = item.VideoSubCategoryId;
                objVideo.VideoCodeNumber = item.VideoCodeNumber;
                objVideo.VideoName = item.VideoName + "";
                objVideo.VideoThumbnail = item.VideoThumbnail + "";
                objVideo.TotalOfViews = (int)item.TotalOfViews;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = (Guid)item.AccountId;
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objVideo.Account = objAcc;
                VideoCategoryObject objCategory = new VideoCategoryObject();
                objCategory.VideoCategoryId = (Guid)item.VideoCategoryId;
                objCategory.VCCodeNumber = (int)item.VCCodeNumber;
                objCategory.VideoCategoryName = item.VideoCategoryName;
                objVideo.objVideoCategory = objCategory;
                lisRs.Add(objVideo);
            }

            return lisRs;
        }

        //Insert and Update
        public bool Insert(VideoObject objVideo)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_Video_update(objVideo.VideoId, objVideo.VideoCategoryId, objVideo.VideoSubCategoryId, objVideo.VideoCodeNumber,
                objVideo.VideoName, objVideo.VideoLink, objVideo.VideoThumbnail, objVideo.VideoDescription,
                objVideo.TotalOfViews, objVideo.TotalOfLikes, objVideo.TotalOfDislikes, objVideo.TotalOfComments,
                objVideo.ModifiedBy, objVideo.ModifiedTime, objVideo.IsApproved, objVideo.ApprovedBy, objVideo.CreatedTime,
                objVideo.CreatedBy, objVideo.IsDeleted, false);
            return true;
        }

        public bool Update(VideoObject objVideo)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            if (objVideo.VideoSubCategoryId == Guid.Empty)
            {
                objVideo.VideoSubCategoryId = null;
            }
            m_objDb.WEB_IMIC_SP_Video_update(objVideo.VideoId, objVideo.VideoCategoryId, objVideo.VideoSubCategoryId, objVideo.VideoCodeNumber,
                objVideo.VideoName, objVideo.VideoLink, objVideo.VideoThumbnail, objVideo.VideoDescription,
                objVideo.TotalOfViews, objVideo.TotalOfLikes, objVideo.TotalOfDislikes, objVideo.TotalOfComments,
                objVideo.ModifiedBy, objVideo.ModifiedTime, objVideo.IsApproved, objVideo.ApprovedBy, objVideo.CreatedTime,
                objVideo.CreatedBy, objVideo.IsDeleted, true);
            return true;
        }

        public bool Delete(Guid videoID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_Video_delete(videoID);
            return true;
        }
    }
}
