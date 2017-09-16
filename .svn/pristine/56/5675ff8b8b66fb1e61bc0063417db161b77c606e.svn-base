using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class TechCommentReplyBcl
    {
        public List<TechCommentReplyObject> getByComment(Guid commentID)
        {
            return new TechCmtReplyDao().getByComment(commentID);
        }
        public void addElement(TechCommentReplyObject objReply)
        {
            new TechCmtReplyDao().addElement(objReply);
        }
    }
}
