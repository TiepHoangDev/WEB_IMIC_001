using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class CommentReplyDao
    {
        public List<CommentReplyObject> GetAllByCommentID(Guid cmtId, Guid UserId)
        {
            WebIMicEntities db = new WebIMicEntities();
            List<CommentReplyObject> Lisobj = new List<CommentReplyObject>();
            foreach (var item in db.WEB_IMIC_SP_CommentReply_GetByCommentId(cmtId, UserId))
            {
                CommentReplyObject obj = new CommentReplyObject();
                obj.CommentId = item.CommentId;
                obj.CommentReplyId = item.CommentReplyId;
                obj.ContentReply = item.ContentReply;
                obj.IsDeleted = item.IsDeleted;
                obj.IsLiked = false;
                if (item.IsLiked > 0)
                {
                    obj.IsLiked = true;
                }
                obj.ModifiedTime = item.ModifiedTime;
                obj.ReplyBy = item.ReplyBy;
                obj.TotalOfDislikes = item.TotalOfDislikes;
                obj.TotalOfLikes = item.TotalOfLikes;
                AccountObject objAcc = new AccountObject ();
                objAcc.AccountId = item.AccountId.GetValueOrDefault();
                objAcc.FullName = item.FullName;
                objAcc.Username = item.Username;
                objAcc.ImageAvatar = item.ImageAvatar;
                obj.objUser = objAcc;
                Lisobj.Add(obj);
            }
            return Lisobj;
        }

        public CommentReplyObject GetByID(Guid CmtrId)
        {
            WebIMicEntities db = new WebIMicEntities();
            CommentReplyObject obj =  new CommentReplyObject();
            foreach (var item in db.WEB_IMIC_SP_CommentReply_GETBYID(CmtrId))
            {
                obj.CommentReplyId = item.CommentReplyId;
                obj.CommentId = item.CommentId;
                obj.ReplyBy = item.ReplyBy;
                obj.ContentReply = item.ContentReply;
                obj.TotalOfDislikes = item.TotalOfDislikes;
                obj.TotalOfLikes = item.TotalOfLikes;
                obj.ModifiedTime = item.ModifiedTime;
                obj.IsDeleted = item.IsDeleted;
                return obj;
            }
            return null;
        }

        public void Insert(CommentReplyObject obj)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_CommentReply_update(obj.CommentReplyId, obj.CommentId, obj.ReplyBy, obj.ContentReply,
                obj.TotalOfLikes, obj.TotalOfDislikes, obj.ModifiedTime, obj.IsDeleted, false);
        }

        public void Update(CommentReplyObject obj)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_CommentReply_update(obj.CommentReplyId, obj.CommentId, obj.ReplyBy, obj.ContentReply,
                obj.TotalOfLikes, obj.TotalOfDislikes, obj.ModifiedTime, obj.IsDeleted, true);
        }

        public void Delete(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_CommentReply_DELETE(id);
        }
    }
}
