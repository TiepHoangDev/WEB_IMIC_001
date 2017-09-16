using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class TechCommentDao
    {
        public List<TechCommentObject> getByArticle(Guid articleid,Guid? accountid)
        {
            List<TechCommentObject> lstCmt = new List<TechCommentObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechComment_GetByArticle(articleid, accountid))
            {
                TechCommentObject objCmt = new TechCommentObject();
                objCmt.CommentBy = (Guid)item.CommentBy;
                objCmt.ContentComment = item.ConTentComment;
                objCmt.isDeleted = false;
                objCmt.MofifiedTime = (DateTime)item.ModifiedTime;
                objCmt.objCommentBy = new AccountObject();
                objCmt.objCommentBy.AccountId = (Guid)item.CommentBy;
                objCmt.objCommentBy.FullName = item.FullName;
                objCmt.objCommentBy.ImageAvatar = item.ImageAvatar;
                objCmt.TechArticleID = articleid;
                objCmt.TechCommentID = item.TechCommentId;
                objCmt.TotalOfLikes = (int)item.TotalOfLikes;
                objCmt.TotalOfReplies = (int)item.TotalOfReplies;
                lstCmt.Add(objCmt);
            }
            return lstCmt;
        }
        public int getLikeCount(Guid commentID)
        {
            return new WebIMicEntities().WEB_IMIC_SP_TechCommentLike_getLikeCount(commentID).ToList()[0].Value;
        }
        public List<TechCommentObject> getByArticle_PAGING(Guid articleid,Guid? accountid,int start,int length)
        {
            List<TechCommentObject> lstCmt = new List<TechCommentObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechComment_GetByArticle_PAGING(articleid, accountid,start, length))
            {
                TechCommentObject objCmt = new TechCommentObject();
                objCmt.CommentBy = (Guid)item.CommentBy;
                objCmt.ContentComment = item.ConTentComment;
                objCmt.isDeleted = false;
                objCmt.MofifiedTime = (DateTime)item.ModifiedTime;
                objCmt.objCommentBy = new AccountObject();
                objCmt.objCommentBy.AccountId = (Guid)item.CommentBy;
                objCmt.objCommentBy.FullName = item.FullName;
                objCmt.objCommentBy.ImageAvatar = item.ImageAvatar;
                objCmt.objCommentBy.Username = item.Username;
                objCmt.TechArticleID = articleid;
                objCmt.TechCommentID = item.TechCommentId;
                objCmt.TotalOfLikes = (int)item.TotalOfLikes;
                objCmt.TotalOfReplies = (int)item.TotalOfReplies;
                objCmt.isLiked = false;
                if (item.isLiked >0)
                    objCmt.isLiked = true;
                lstCmt.Add(objCmt);
            }
            return lstCmt;
        }
        public void addElement(TechCommentObject objComment)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_tbl_TechComment_Insert(objComment.TechCommentID, objComment.TechArticleID, objComment.CommentBy,
                objComment.ContentComment, objComment.TotalOfLikes, objComment.TotalOfReplies, objComment.MofifiedTime, false);
        }
        public void deleteElement(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_tbl_TechComment_Delete(id);
        }
    }
}
