using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoCommentReplyDao : BaseModel<VideoCommentReplyObject>
    {
        public List<VideoCommentReplyObject> getAllByVideoCommentID(Guid VideoCommentID, Guid? AccountId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();

            var lisGet = m_objDb.WEB_IMIC_SP_VideoCommentReply_GetByVideoCommentId(VideoCommentID, AccountId).ToList();

            List<VideoCommentReplyObject> lisRs = new List<VideoCommentReplyObject>();

            foreach (var item in lisGet)
            {
                VideoCommentReplyObject objReply = new VideoCommentReplyObject();
                objReply.VideoCommentReplyId = item.VideoCommentReplyId;
                objReply.VideoCommentId = item.VideoCommentId.GetValueOrDefault();
                objReply.ReplyBy = item.ReplyBy.GetValueOrDefault();
                objReply.ContentReply = item.ContentReply;
                objReply.TotalOfLikes = item.TotalOfLikes.GetValueOrDefault();
                objReply.TotalOfDislikes = item.TotalOfDislikes.GetValueOrDefault();
                objReply.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objReply.IsDeleted = item.IsDeleted;
                objReply.IsLiked = false;
                if (item.IsLiked > 0)
                {
                    objReply.IsLiked = true;
                }
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.Username = item.Username;
                objAcc.FullName = item.FullName;
                objAcc.ImageAvatar = item.ImageAvatar;
                objReply.Account = objAcc;
                lisRs.Add(objReply);
            }

            return lisRs;
        }

        public VideoCommentReplyObject getByID(Guid VideoCommentReplyID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoCommentReply_GETBYID(VideoCommentReplyID).ToList();

            foreach (var item in lisGet)
            {
                VideoCommentReplyObject objReply = new VideoCommentReplyObject();
                objReply.VideoCommentReplyId = item.VideoCommentReplyId;
                objReply.VideoCommentId = (Guid)item.VideoCommentId;
                objReply.ReplyBy = (Guid)item.ReplyBy;
                objReply.ContentReply = item.ContentReply;
                objReply.TotalOfLikes = (int)item.TotalOfLikes;
                objReply.TotalOfDislikes = (int)item.TotalOfDislikes;
                objReply.ModifiedTime = (DateTime)item.ModifiedTime;
                objReply.IsDeleted = (bool)item.IsDeleted;
                return objReply;
            }
            return null;
        }

        public bool Insert(VideoCommentReplyObject objReply)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCommentReply_update(objReply.VideoCommentReplyId, objReply.VideoCommentId, objReply.ReplyBy,
                objReply.ContentReply, objReply.TotalOfLikes, objReply.TotalOfDislikes,
                objReply.ModifiedTime, objReply.IsDeleted, false);
            return true;
        }

        public bool Update(VideoCommentReplyObject objReply)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCommentReply_update(objReply.VideoCommentReplyId, objReply.VideoCommentId, objReply.ReplyBy,
                objReply.ContentReply, objReply.TotalOfLikes, objReply.TotalOfDislikes,
                objReply.ModifiedTime, objReply.IsDeleted, true);
            return true;
        }

        public bool Delete(Guid VideoCommentReplyId)
        {
            new WebIMicEntities().WEB_IMIC_SP_VideoCommentReply_DELETE(VideoCommentReplyId);
            return true;
        }
    }
}
