using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class RecruitmentGalleryImageBcl
    {
       public List<RecruitmentGalleryImageObject> GetAll()
       {
           return new RecruitmentGalleryImageDao().GetAll();
       }

       public RecruitmentGalleryImageObject GetByID(Guid id)
       {
           return new RecruitmentGalleryImageDao().GetByID(id);
       }

       public void GalleryInsert(RecruitmentGalleryImageObject obj)
       {
           new RecruitmentGalleryImageDao().GalleryInsert(obj);
       }

       public void GalleryUpdate(RecruitmentGalleryImageObject obj)
       {
           new RecruitmentGalleryImageDao().GalleryUpdate(obj);
       }

       public void GalleryDelete(Guid id)
       {
           new RecruitmentGalleryImageDao().GalleryDelete(id);
       }
    }
}
