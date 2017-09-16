using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class TechCommentLikeDao
    {
        public void addElement(TechCommentLikeObject objLike)
        {
            new WebIMicEntities().WEB_IMIC_SP_TechCommentLike_Insert(objLike.TechCommentLikeID, objLike.TechCommentID, objLike.LikedBy);
        }
        public void deleteElement(TechCommentLikeObject objLike)
        {
            new WebIMicEntities().WEB_IMIC_SP_TechCommentLike_Delete(objLike.TechCommentID, objLike.LikedBy);
        }
        public bool CheckIsLiked(TechCommentLikeObject objLike)
        {
            WebIMicEntities db = new WebIMicEntities();
            if (db.WEB_IMIC_SP_TechCommentLike_CheckIsLiked(objLike.TechCommentID, objLike.LikedBy).ToList()[0] > 0)
                return true;
            return false;
          
        }
    }
}
