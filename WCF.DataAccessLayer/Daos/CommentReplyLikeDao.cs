using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class CommentReplyLikeDao
    {
       public void Insert(CommentReplyLikeObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_CommentReplyLike_Insert(obj.CommentReplyLikeId, obj.CommentReplyId, obj.LikedBy,
               obj.CreatedTime);
       }

       public void Delete(CommentReplyLikeObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_CommentReplyLike_Delete(obj.CommentReplyLikeId, obj.LikedBy);
       }
       public bool checkUserLike(Guid CommentReplyID, Guid userID)
       {
           WebIMicEntities m_objDb = new WebIMicEntities();
           foreach (var item in m_objDb.WEB_IMIC_SP_CommentReplyLike_CheckUserLike(CommentReplyID, userID))
           {
               if (item.Value > 0) return true;
           }
           return false;
       }
    }
}
