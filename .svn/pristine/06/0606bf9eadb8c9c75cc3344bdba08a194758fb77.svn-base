using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class TechCommentLikeBcl
    {
        public void addElement(TechCommentLikeObject objLike)
        {
            new TechCommentLikeDao().addElement(objLike);
        }
        public void deleteElement(TechCommentLikeObject objLike)
        {
            new TechCommentLikeDao().deleteElement(objLike);
        }
        public bool CheckIsLiked(TechCommentLikeObject objLike)
        {
            return new TechCommentLikeDao().CheckIsLiked(objLike);
        }
    }
}
