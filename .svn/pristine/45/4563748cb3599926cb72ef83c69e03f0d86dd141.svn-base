using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class TechArticleLikeBcl
    {
        public void addElement(TechArticleLikeObject objLike)
        {
            new TechArticleLikeDao().addElement(objLike); 
        }
        public void deleteElement(TechArticleLikeObject objLike)
        {
            new TechArticleLikeDao().deleteElement(objLike);
        }
        public bool checkUserLike(Guid articleID,Guid userID)
        {
            return new TechArticleLikeDao().checkUserLike(articleID, userID);
        }
    }
}
