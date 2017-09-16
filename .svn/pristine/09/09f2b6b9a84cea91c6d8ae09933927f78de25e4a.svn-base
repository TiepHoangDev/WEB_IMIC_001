using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoCommentDao : BaseModel<VideoCommentObject>
    {
        public List<VideoCommentObject> getAllByVideoID(Guid VideoID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoComment_GetAllByVideoId(VideoID).ToList();

            List<VideoCommentObject> lisRs = new List<VideoCommentObject>();

            foreach (var item in lisGet)
            {
                VideoCommentObject objComment = new VideoCommentObject();
                objComment.VideoCommentId = item.VideoCommentId;
                objComment.VideoId = (Guid)item.VideoId;
                objComment.CommentBy = (Guid)item.CommentBy;
                objComment.ContentComment = item.ContentComment;
                objComment.TotalOfReplies = (int)item.TotalOfReplies;
                objComment.TotalOfLikes = (int)item.TotalOfLikes;
                objComment.TotalOfDislikes = (int)item.TotalOfDislikes;
                objComment.ModifiedTime = (DateTime)item.ModifiedTime;
                objComment.IsDeleted = (bool)item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = (Guid)item.AccountId;
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objComment.Account = objAcc;
                lisRs.Add(objComment);
            }
            return lisRs;
        }

        public List<VideoCommentObject> getByVideoID_PAGING(Guid VideoID, Guid? AccountId, int Start, int Length)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoComment_GetByVideoId_PAGING(VideoID, AccountId, Start, Length);

            List<VideoCommentObject> lisRs = new List<VideoCommentObject>();

            foreach (var item in lisGet)
            {
                VideoCommentObject objComment = new VideoCommentObject();
                objComment.VideoCommentId = item.VideoCommentId;
                objComment.VideoId = (Guid)item.VideoId;
                objComment.CommentBy = (Guid)item.CommentBy;
                objComment.ContentComment = item.ContentComment;
                objComment.TotalOfReplies = (int)item.TotalOfReplies;
                objComment.TotalOfLikes = (int)item.TotalOfLikes;
                objComment.TotalOfDislikes = (int)item.TotalOfDislikes;
                objComment.ModifiedTime = (DateTime)item.ModifiedTime;
                objComment.IsDeleted = (bool)item.IsDeleted;
                objComment.IsLiked = false;
                if (item.isLiked > 0)
                {
                    objComment.IsLiked = true;
                }
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = (Guid)item.AccountId;
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objComment.Account = objAcc;
                lisRs.Add(objComment);
            }
            return lisRs;
        }

        public VideoCommentObject getByID(Guid VideoCommentID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoComment_GETBYID(VideoCommentID).ToList();

            foreach (var item in lisGet)
            {
                VideoCommentObject objComment = new VideoCommentObject();
                objComment.VideoCommentId = item.VideoCommentId;
                objComment.VideoId = (Guid)item.VideoId;
                objComment.CommentBy = (Guid)item.CommentBy;
                objComment.ContentComment = item.ContentComment;
                objComment.TotalOfReplies = (int)item.TotalOfReplies;
                objComment.TotalOfLikes = (int)item.TotalOfLikes;
                objComment.TotalOfDislikes = (int)item.TotalOfDislikes;
                objComment.ModifiedTime = (DateTime)item.ModifiedTime;
                objComment.IsDeleted = (bool)item.IsDeleted;
                return objComment;
            }
            return null;
        }

        public bool Insert(VideoCommentObject objVideoCmt)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoComment_update(objVideoCmt.VideoCommentId, objVideoCmt.VideoId, objVideoCmt.CommentBy,
                objVideoCmt.ContentComment, objVideoCmt.TotalOfReplies, objVideoCmt.TotalOfLikes, objVideoCmt.TotalOfDislikes,
                objVideoCmt.ModifiedTime, objVideoCmt.IsDeleted, false);
            return true;
        }

        public bool Update(VideoCommentObject objVideoCmt)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoComment_update(objVideoCmt.VideoCommentId, objVideoCmt.VideoId, objVideoCmt.CommentBy,
                objVideoCmt.ContentComment, objVideoCmt.TotalOfReplies, objVideoCmt.TotalOfLikes, objVideoCmt.TotalOfDislikes,
                objVideoCmt.ModifiedTime, objVideoCmt.IsDeleted, true);
            return true;
        }

        public bool Delete(Guid VideoCommentId)
        {
            new WebIMicEntities().WEB_IMIC_SP_VideoComment_DELETE(VideoCommentId);
            return true;
        }
    }
}
