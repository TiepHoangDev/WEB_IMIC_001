using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class RecruitmentBannerBcl
    {
       public List<RecruitmentBannerObject> GetAll()
       {
           return new RecruitmentBannerDao().GetAll();
       }

       public RecruitmentBannerObject GetByID(Guid id)
       {
           return new RecruitmentBannerDao().GetByID(id);
       }

       public void BannerInsert(RecruitmentBannerObject obj)
       {
           new RecruitmentBannerDao().BannerInsert(obj);
       }

       public void BannerUpdate(RecruitmentBannerObject obj)
       {
           new RecruitmentBannerDao().BannerUpdate(obj);
       }

       public void BannerDelete(Guid id)
       {
           new RecruitmentBannerDao().BannerDelete(id);
       }
    }
}
