using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class TechArticleLikeDao
    {
        public void addElement(TechArticleLikeObject objLike)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticleLike_Insert(objLike.LikeID, objLike.ArticleID, objLike.LikeBy, objLike.CreateTime);
        }
        public void deleteElement(TechArticleLikeObject objLike)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticleLike_Delete(objLike.ArticleID, objLike.LikeBy);
        }
        public bool checkUserLike(Guid articleID,Guid userID)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach(var item in db.WEB_IMIC_SP_TechArticleLike_CheckUserLike(articleID,userID))
            {
                if (item.Value > 0) return true;
            }
            return false;
        }
    }
}
