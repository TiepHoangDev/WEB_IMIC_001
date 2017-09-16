using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class CommentBCL
    {
       // Begin Commnent
       public List<CommentObject> GetCommentByArticle(Guid id)
       {
           return new CommentDao().GetAllCommentByArticleId(id);
       }

       public CommentObject GetCommentByID(Guid id)
       {
           return new CommentDao().getByID(id);
       }

       public void CommentInsert(CommentObject obj)
       {
           new CommentDao().Insert(obj);
       }

       public void CommentUpdate(CommentObject obj)
       {
           new CommentDao().Update(obj);
       }

       public bool CommentDelete(Guid id)
       {
           new CommentDao().Delete(id);
           return true;
       }
       //Begin Comment Like 

       public void CommentLikeInsert(CommentLikeObject obj)
       {
           new CommentLikeDao().Insert(obj);
       }

       public void CommentLikeDelete(CommentLikeObject obj)
       {
           new CommentLikeDao().Delete(obj);
       }

       public bool CommentCheckUserLike(Guid cmtId, Guid userId)
       {
          return new CommentLikeDao().CheckUserLike(cmtId, userId);
         
       }

       //Begin CommentReply 
       public List<CommentReplyObject> CommentReplyGetByComment(Guid cmtId,Guid userid)
       {
           return new CommentReplyDao().GetAllByCommentID(cmtId,userid);
       }

       public CommentReplyObject CommentReplyByID(Guid id)
       {
           return new CommentReplyDao().GetByID(id);
       }

       public void CommentReplyInsert(CommentReplyObject obj)
       {
           new CommentReplyDao().Insert(obj);
       }
       public void CommentReplyUpdate(CommentReplyObject obj)
       {
           new CommentReplyDao().Update(obj);
       }

       public void CommentReplyDelete(Guid id)
       {
           new CommentReplyDao().Delete(id);
       }
       //Begin CommentReplyLike

       public void CommentReplyLikeInsert(CommentReplyLikeObject obj)
       {
           new CommentReplyLikeDao().Insert(obj);
       }

       public void CommentReplyLikeDelete(CommentReplyLikeObject obj)
       {
           new CommentReplyLikeDao().Delete(obj);
       }

       public bool CommentReplyLikeCheckUserLike(Guid cmtrId, Guid userid)
       {
           return new CommentReplyLikeDao().checkUserLike(cmtrId,userid);
       }
    }
}
