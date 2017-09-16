using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class ClassBcl
    {
       public List<ClassObject> getAll()
       {
           return new ClassDao().GetAll();
       }

       public ClassObject GetByID(Guid id)
       {
           return new ClassDao().GetByID(id);
       }

       public void Insert(ClassObject obj)
       {
           new ClassDao().Insert(obj);
       }

       public void Update(ClassObject obj)
       {
           new ClassDao().Update(obj);
       }

       public void Delete(Guid id)
       {
           new ClassDao().Delete(id);
       }

       public void IsActived(Guid id)
       {
           new ClassDao().IsActived(id);
       }

       public void UnActive(Guid id)
       {
           new ClassDao().IsUnActived(id);
       }
    }
}
