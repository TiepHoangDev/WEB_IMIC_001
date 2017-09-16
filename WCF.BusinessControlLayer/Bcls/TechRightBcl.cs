using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class TechRightBcl
    {
       public List<TechRightObject> GetAll()
       {
           return new TechRightDao().GetAll();
       }

       public TechRightObject GetByID(Guid id)
       {
           return new TechRightDao().GetByID(id);
       }

       public void Insert(TechRightObject obj)
       {
           new TechRightDao().Insert(obj);
       }

       public void Update(TechRightObject obj)
       {
           new TechRightDao().Update(obj);
       }

       public void Delete(Guid id)
       {
           new TechRightDao().Delete(id);
       }
    }
}
