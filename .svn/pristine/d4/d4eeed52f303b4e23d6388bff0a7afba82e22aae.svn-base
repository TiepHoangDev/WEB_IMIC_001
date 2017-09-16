using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class JobBcl
    {
       public List<ReJobObject> GetAll()
       {
           return  new RecJobDao().GetAll();
       }

       public ReJobObject GetByID(Guid id)
       {
           return new RecJobDao().GetByID(id);
       }

       public void JobInsert(ReJobObject obj)
       {
           new RecJobDao().JobInsert(obj);
       }

       public void JobUpdate(ReJobObject obj)
       {
           new RecJobDao().JobUpdate(obj);
       }

       public void JobDelete(Guid id)
       {
           new RecJobDao().JobDelete(id);
       }
    }
}
