using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class TechRightDao
    {
       public List<TechRightObject> GetAll()
       {
           WebIMicEntities db = new WebIMicEntities();
           var lstTechRight = db.WEB_IMIC_SP_TechRight_GetAll();
           List<TechRightObject> lisobj = new List<TechRightObject>();
           foreach (var item in lstTechRight)
           {
             TechRightObject obj= new TechRightObject();
               obj.TechRightId = item.TechRightId;
               obj.TechRightTitle = item.TechRightTitle;
               obj.TechRightImage = item.TechRightImage;
               obj.TechRightUrl = item.TechRightUrl;
               obj.TechRightLine1 = item.TechRightLine1;
               obj.TechRightUrl1 = item.TechRightUrl1;
               obj.TechRightLine2 = item.TechRightLine2;
               obj.TechRightUrl2 = item.TechRightUrl2;
               obj.TechRightLine3 = item.TechRightLine3;
               obj.TechRightUrl3 = item.TechRightUrl3;
               obj.TechRightLine4 = item.TechRightLine4;
               obj.TechRightUrl4 = item.TechRightUrl4;
               obj.TechRightLine5 = item.TechRightLine5;
               obj.TechRightUrl5 = item.TechRightUrl5;
               obj.IsShowed = (bool)item.IsShowed;
               obj.Rank = item.Rank;
               lisobj.Add(obj);
           }
           return lisobj;
       }

       public TechRightObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           var lstTechRight = db.WEB_IMIC_SP_TechRight_ByID(id);
           TechRightObject obj = new TechRightObject();
           foreach (var item in lstTechRight)
           {
               
               obj.TechRightId = item.TechRightId;
               obj.TechRightTitle = item.TechRightTitle;
               obj.TechRightImage = item.TechRightImage;
               obj.TechRightUrl = item.TechRightUrl;
               obj.TechRightLine1 = item.TechRightLine1;
               obj.TechRightUrl1 = item.TechRightUrl1;
               obj.TechRightLine2 = item.TechRightLine2;
               obj.TechRightUrl2 = item.TechRightUrl2;
               obj.TechRightLine3 = item.TechRightLine3;
               obj.TechRightUrl3 = item.TechRightUrl3;
               obj.TechRightLine4 = item.TechRightLine4;
               obj.TechRightUrl4 = item.TechRightUrl4;
               obj.TechRightLine5 = item.TechRightLine5;
               obj.TechRightUrl5 = item.TechRightUrl5;
               obj.IsShowed = (bool)item.IsShowed;
               obj.Rank = item.Rank;
          
           }
           return obj;
       }

       public void Insert(TechRightObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechRight_Insert(obj.TechRightId, obj.TechRightTitle, obj.TechRightImage, obj.TechRightUrl,
               obj.TechRightLine1, obj.TechRightUrl1, obj.TechRightLine2, obj.TechRightUrl2, obj.TechRightLine3,
               obj.TechRightUrl3, obj.TechRightLine4, obj.TechRightUrl4, obj.TechRightLine5, obj.TechRightUrl5,
               obj.IsShowed, obj.Rank);
       }

       public void Update(TechRightObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechRight_Update(obj.TechRightId, obj.TechRightTitle, obj.TechRightImage, obj.TechRightUrl,
               obj.TechRightLine1, obj.TechRightUrl1, obj.TechRightLine2, obj.TechRightUrl2, obj.TechRightLine3,
               obj.TechRightUrl3, obj.TechRightLine4, obj.TechRightUrl4, obj.TechRightLine5, obj.TechRightUrl5,
               obj.IsShowed, obj.Rank);
       }

       public void Delete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechRight_Delete(id);
       }
    }
}
