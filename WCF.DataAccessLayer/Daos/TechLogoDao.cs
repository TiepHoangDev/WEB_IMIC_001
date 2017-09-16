using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class TechLogoDao
    {
      public List<TechLogoObject> GetAll()
       {
           WebIMicEntities db = new WebIMicEntities();
           var lstLogo = db.WEB_IMIC_SP_TechLogo_GetAll();
           List<TechLogoObject> lisObj = new List<TechLogoObject>();
           foreach (var item in lstLogo)
           {
               TechLogoObject obj = new TechLogoObject();
               obj.TehLogoId = item.TehLogoId;
               obj.TechLogoTitle = item.TechLogoTitle;
               obj.TechLogoImage = item.TechLogoImage;
               obj.TechLogoUrl = item.TechLogoUrl;
               obj.Rank = item.Rank;
               lisObj.Add(obj);
           }
           return lisObj;
       }

       public TechLogoObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           var lstLogo = db.WEB_IMIC_SP_TechLogo_ById(id);
           TechLogoObject obj = new TechLogoObject();
           foreach (var item in lstLogo)
           {
              
               obj.TehLogoId = item.TehLogoId;
               obj.TechLogoTitle = item.TechLogoTitle;
               obj.TechLogoImage = item.TechLogoImage;
               obj.TechLogoUrl = item.TechLogoUrl;
               obj.Rank = item.Rank;
               
           }
           return obj;
       }

       public void Insert(TechLogoObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechLogo_Insert(obj.TehLogoId, obj.TechLogoTitle, obj.TechLogoImage, obj.TechLogoUrl, obj.Rank);
       }

       public void Update(TechLogoObject obj)
       {

           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechLogo_Update(obj.TehLogoId, obj.TechLogoTitle, obj.TechLogoImage, obj.TechLogoUrl, obj.Rank);
       }

       public void Delete(Guid id)
       {

           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechLogo_Delete(id);
       }
    }
}
