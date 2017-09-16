using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class TechCommentBcl
    {
        public List<TechCommentObject> getByArticle(Guid articleid, Guid? accountid)
        {
            return new TechCommentDao().getByArticle(articleid, accountid);
        }
        public List<TechCommentObject> getByArticle_PAGING(Guid articleid, Guid? accountid, int start, int length)
        {
            return new TechCommentDao().getByArticle_PAGING(articleid, accountid, start, length);
        }
        public int getLikeCount(Guid commentID)
        {
            return new TechCommentDao().getLikeCount(commentID);
        }
        public void addElement(TechCommentObject objComment)
        {
            new TechCommentDao().addElement(objComment);
        }
        public void deleteElement(Guid id)
        {
            new TechCommentDao().deleteElement(id);
        }
    }
}
