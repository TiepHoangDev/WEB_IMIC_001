using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class TechLinkDao
    {
       public List<TechLinkObject> GetAll()
       {
          WebIMicEntities db = new WebIMicEntities();
           var LstTechLink = db.WEB_IMIC_SP_TechLink_GetAll();
           List<TechLinkObject> lisObj= new List<TechLinkObject>();
           foreach (var item in LstTechLink)
           {
               TechLinkObject obj = new TechLinkObject();
               obj.TechLinkId = item.TechLinkId;
               obj.TechLinkTitle = item.TechLinkTitle;
               obj.Title1 = item.Title1;
               obj.Sumary1 = item.Sumary1;
               obj.Title2 = item.Title2;
               obj.Sumary2 = item.Sumary2;
               obj.TechLinkImage = item.TechLinkImage;
               obj.TechLinkUrl = item.TechLinkUrl;
               obj.Number1 = item.Number1;
               obj.Number2 = item.Number2;
               obj.Rank = item.Rank;
               lisObj.Add(obj);
           }
           return lisObj;
       }

       public TechLinkObject getByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           var LstTechLink = db.WEB_IMIC_SP_TechLink_ByID(id);
           TechLinkObject obj = new TechLinkObject();
           foreach (var item in LstTechLink)
           {
               
               obj.TechLinkId = item.TechLinkId;
               obj.TechLinkTitle = item.TechLinkTitle;
               obj.Title1 = item.Title1;
               obj.Sumary1 = item.Sumary1;
               obj.Title2 = item.Title2;
               obj.Sumary2 = item.Sumary2;
               obj.TechLinkImage = item.TechLinkImage;
               obj.TechLinkUrl = item.TechLinkUrl;
               obj.Number1 = item.Number1;
               obj.Number2 = item.Number2;
               obj.Rank = item.Rank;
           }
           return obj;
       }

       public void Insert(TechLinkObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechLink_Insert(obj.TechLinkId, obj.TechLinkTitle, obj.Title1, obj.Sumary1, obj.Title2,
               obj.Sumary2, obj.TechLinkUrl, obj.TechLinkImage, obj.Number1, obj.Number2, obj.Rank);
       }

       public void Update(TechLinkObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechLink_Update(obj.TechLinkId, obj.TechLinkTitle, obj.Title1, obj.Sumary1, obj.Title2,
               obj.Sumary2, obj.TechLinkUrl, obj.TechLinkImage, obj.Number1, obj.Number2, obj.Rank);
       }

       public void Delete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_TechLink_Delete(id);
       }
    }
}
