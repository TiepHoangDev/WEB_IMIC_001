using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
  public  class ClassSessionLogBcl
    {
      public List<ClassSessionLogObject> GetAll()
      {
          return new ClassSessionLogDao().GetAll();
      }

      public ClassSessionLogObject GetByID(Guid id)
      {
          return new ClassSessionLogDao().GetByID(id);
      }

      public void Insert(ClassSessionLogObject obj)
      {
          new ClassSessionLogDao().Insert(obj);
      }

      public void Update(ClassSessionLogObject obj)
      {
          new ClassSessionLogDao().Update(obj);
      }

      public void Delete(Guid id)
      {
          new ClassSessionLogDao().Delete(id);
      }
      public void IsActived(Guid id)
      {
          new ClassSessionLogDao().IsActived(id);
      }

      public void UnActive(Guid id)
      {
          new ClassSessionLogDao().IsUnActived(id);
      }
    }
}
