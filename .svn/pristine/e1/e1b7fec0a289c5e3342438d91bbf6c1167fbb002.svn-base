using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class TechBannerBcl
    {
       public List<TechBannerObject> BannerGetAll()
       {
           return new TechBannerDao().GetAll();
       }

       public TechBannerObject GetByID(Guid id)
       {
           return new TechBannerDao().GetByID(id);
       }

       public void BannerInsert(TechBannerObject obj)
       {
           new TechBannerDao().BannerInsert(obj);
       }

       public void BannerUpdate(TechBannerObject obj)
       {
           new TechBannerDao().BannerUpdate(obj);
       }

       public void BannerDelete(Guid id)
       {
           new TechBannerDao().BannerDelete(id);
       }
    }
}
