using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class BannerBcl
    {
       public List<BannerObject> GetAll()
       {
           return new BannerDao().GetAll();
       }

       public BannerObject GetById(Guid id)
       {
           return new BannerDao().GetByID(id);
       }

       public void Insert(BannerObject obj)
       {
           new BannerDao().BannerInsert(obj);
       }

       public void Update(BannerObject obj)
       {
           new BannerDao().BannerUpdate(obj);
       }

       public void Delete(Guid id)
       {
           new BannerDao().BannerDelete(id);
       }
    }
}
