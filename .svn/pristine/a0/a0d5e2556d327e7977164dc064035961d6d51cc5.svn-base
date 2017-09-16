using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class ProposeBcl
    {
       public List<ProposeObject> GetAll()
       {
           return  new ProposeDao().GetAll();
       }

       public ProposeObject GetById(Guid id)
       {
           return  new ProposeDao().GetByID(id);
       }

       public void Insert(ProposeObject obj)
       {
           new ProposeDao().Insert(obj);
       }

       public void UnRegister(Guid id)
       {
           new ProposeDao().UnRegister(id);
       }
       public void Update(ProposeObject obj)
       {
           new ProposeDao().Update(obj);
       }

       public void UpdateByUser(ProposeObject obj)
       {
           new ProposeDao().UpdateByUser(obj);
       }

       public void Delete(Guid id)
       {
           new ProposeDao().Delete(id);
       }
    }
}
