using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class RecruitmentGalleryImageDao
    {
       public List<RecruitmentGalleryImageObject> GetAll()
       {
           WebIMicEntities db = new WebIMicEntities();
           var lstGallery = db.WEB_IMIC_SP_RecruitmentGalleryImage_GetAll();
           List<RecruitmentGalleryImageObject> lisObj = new List<RecruitmentGalleryImageObject>();
           foreach (var item in lstGallery)
           {
               RecruitmentGalleryImageObject obj = new RecruitmentGalleryImageObject();
               obj.GalleryImageId = item.GalleryImageId;
               obj.ImageTitle = item.ImageTitle;
               obj.ImageSummary = item.ImageSummary;
               obj.Image_Link = item.Image_Link;
               obj.Image_Alt = item.Image_Alt;
               obj.Rank = item.Rank;
               lisObj.Add(obj);
           }
           return lisObj;
       }

       public RecruitmentGalleryImageObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           var lstGallery = db.WEB_IMIC_SP_RecruitmentGalleryImage_GetByID(id);
           RecruitmentGalleryImageObject obj = new RecruitmentGalleryImageObject();
           foreach (var item in lstGallery)
           {
               obj.GalleryImageId = item.GalleryImageId;
               obj.ImageTitle = item.ImageTitle;
               obj.ImageSummary = item.ImageSummary;
               obj.Image_Link = item.Image_Link;
               obj.Image_Alt = item.Image_Alt;
               obj.Rank = item.Rank;
           }
           return obj;
       }

       public void GalleryInsert(RecruitmentGalleryImageObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_RecruitmentGalleryImage_Insert(obj.GalleryImageId, obj.ImageTitle, obj.ImageSummary,
               obj.Image_Link, obj.Image_Alt, obj.Rank);
       }
       public void GalleryUpdate(RecruitmentGalleryImageObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_RecruitmentGalleryImage_Update(obj.GalleryImageId, obj.ImageTitle, obj.ImageSummary,
               obj.Image_Link, obj.Image_Alt, obj.Rank);
       }

       public void GalleryDelete(Guid id)
       {
           WebIMicEntities db =new WebIMicEntities();
           db.WEB_IMIC_SP_RecruitmentGalleryImage_Delete(id);
       }
    }
}
