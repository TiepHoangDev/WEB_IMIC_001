using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class BannerDao
    {
       public List<BannerObject> GetAll()
       {
           WebIMicEntities db =  new WebIMicEntities();
           List<BannerObject> LisObj = new List<BannerObject>();
           foreach (var item in db.WEB_IMIC_SP_Baner_GetAll())
           {
               BannerObject obj = new BannerObject();
               obj.BannerId = item.BannerId;
               obj.FlagImage = item.FlagImage;
               obj.MenuId = item.MenuId;
               obj.ImageLink = item.ImageLink;
               obj.ImageAlt = item.ImageAlt;
               obj.Text1 = item.Text1;
               obj.Text2 = item.Text2;
               obj.Text3 = item.Text3;
               obj.Text4 = item.Text4;
               obj.Text5 = item.Text5;
               obj.Rank = item.Rank;
               LisObj.Add(obj);
           }
           return LisObj;
       }

       public BannerObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           foreach (var item in db.WEB_IMIC_SP_Baner_GetAll())
           {
               BannerObject obj = new BannerObject();
               obj.BannerId = item.BannerId;
               obj.FlagImage = item.FlagImage;
               obj.MenuId = item.MenuId;
               obj.ImageLink = item.ImageLink;
               obj.ImageAlt = item.ImageAlt;
               obj.Text1 = item.Text1;
               obj.Text2 = item.Text2;
               obj.Text3 = item.Text3;
               obj.Text4 = item.Text4;
               obj.Text5 = item.Text5;
               obj.Rank = item.Rank;
               return obj;
           }
           return null;
       }

       public void BannerInsert(BannerObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Baner_Insert(obj.BannerId, obj.FlagImage, obj.MenuId, obj.ImageLink, obj.ImageAlt, obj.Text1,
               obj.Text2, obj.Text3, obj.Text4, obj.Text5, obj.Rank);
       }

       public void BannerUpdate(BannerObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Baner_Update(obj.BannerId, obj.FlagImage, obj.MenuId, obj.ImageLink, obj.ImageAlt, obj.Text1,
               obj.Text2, obj.Text3, obj.Text4, obj.Text5, obj.Rank);
       }

       public void BannerDelete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Baner_Delete(id);
       }
    }
}
