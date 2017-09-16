using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class CommentLikeDao
    {
       public void Insert(CommentLikeObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_CommentLike_Insert(obj.CommentLikeId, obj.CommentId, obj.LikeBy, obj.CreatedTime);
       }

       public void Delete(CommentLikeObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_CommentLike_Delete(obj.CommentId, obj.LikeBy);
       }

       public bool CheckUserLike(Guid cmtId, Guid UserId)
       {
           WebIMicEntities db = new WebIMicEntities();
           foreach (var item in db.WEB_IMIC_SP_CommentLike_CheckUserLike(cmtId,UserId))
           {
               if (item.Value > 0) return true;
           }
           return false;
       }
    }
}
