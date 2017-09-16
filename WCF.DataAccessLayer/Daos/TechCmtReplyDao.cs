using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class TechCmtReplyDao
    {
        public List<TechCommentReplyObject> getByComment(Guid commentID)
        {
            List<TechCommentReplyObject> lstReply = new List<TechCommentReplyObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach(var item in db.WEB_IMIC_SP_TechCommentReply_getByComment(commentID))
            {
                TechCommentReplyObject objReply = new TechCommentReplyObject();
                objReply.ContentReply = item.ContentReply;
                objReply.isDeleted = false;
                objReply.MofifiedTime = (DateTime)item.ModifiedTime;
                objReply.objReplyBy = new AccountObject()
                {
                    FullName = item.FullName,
                    ImageAvatar = item.ImageAvatar,
                    Username = item.Username
                };
                objReply.ReplyBy = (Guid)item.ReplyBy;
                objReply.TechCommentID = commentID;
                objReply.TechCommentReplyID = item.TechCommentReplyId;
               
                lstReply.Add(objReply);
            }
            return lstReply;
        }
        public void addElement(TechCommentReplyObject objReply)
        {
            new WebIMicEntities().WEB_IMIC_SP_TechCommentReply_Insert(objReply.TechCommentReplyID, objReply.TechCommentID,
                objReply.ReplyBy, objReply.ContentReply, objReply.MofifiedTime, objReply.isDeleted);
        }
    }
}
