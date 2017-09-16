using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class CommentDao
    {
       public List<CommentObject> GetAllCommentByArticleId(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           List<CommentObject> LisCmt = new List<CommentObject>();
           foreach (var item in db.WEB_IMIC_SP_Comment_GetAllByArticleId(id))
           {
               CommentObject obj = new CommentObject();
               obj.CommentId = item.CommentId;
               obj.ArticleId = item.ArticleId;
               obj.CommentBy = item.CommentBy;
               obj.ContentComment = item.ContentComment;
               obj.IsDeleted = item.IsDeleted;
               obj.ModifiedTime = item.ModifiedTime;
               obj.TotalOfDislikes = item.TotalOfDislikes;
               obj.TotalOfLikes = item.TotalOfLikes;
               obj.TotalOfReplies = item.TotalOfReplies;
               obj.objUser = new AccountObject
               {
                   AccountId = item.AccountId.Value,
                   FullName = item.FullName,
                   Username = item.Username,
                   ImageAvatar = item.ImageAvatar
               };
               LisCmt.Add(obj);
           }
           return LisCmt;
       }

       public CommentObject getByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           CommentObject obj = new CommentObject();
           foreach (var item in db.WEB_IMIC_SP_Comment_GETBYID(id))
           {
              
               obj.CommentId = item.CommentId;
               obj.ArticleId = item.ArticleId;
               obj.CommentBy = item.CommentBy;
               obj.ContentComment = item.ContentComment;
               obj.IsDeleted = item.IsDeleted;
               obj.ModifiedTime = item.ModifiedTime;
               obj.TotalOfDislikes = item.TotalOfDislikes;
               obj.TotalOfLikes = item.TotalOfLikes;
               obj.TotalOfReplies = item.TotalOfReplies;
               return obj;
           }
           return null;
       }

       public void Insert(CommentObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Comment_update(obj.CommentId, obj.ArticleId, obj.CommentBy, obj.ContentComment,
               obj.TotalOfReplies, obj.TotalOfLikes, obj.TotalOfDislikes, obj.ModifiedTime, obj.IsDeleted, false);
       }

       public void Update(CommentObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Comment_update(obj.CommentId, obj.ArticleId, obj.CommentBy, obj.ContentComment,
               obj.TotalOfReplies, obj.TotalOfLikes, obj.TotalOfDislikes, obj.ModifiedTime, obj.IsDeleted, true);
       }

       public bool Delete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Comment_DELETE(id);
           return true;
       }
    }
}
