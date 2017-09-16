using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
  public class ClassSessionLogAbsentBcl
    {
      public List<ClassSessionLogAbsentObject> GetAll()
      {
          return  new ClassSessionLogAbsentDao().GetAll();
      }

      public ClassSessionLogAbsentObject GetByID(Guid id)
      {
          return new ClassSessionLogAbsentDao().GetByID(id);
      }

      public void Insert(ClassSessionLogAbsentObject obj)
      {
          new ClassSessionLogAbsentDao().Insert(obj);
      }

      public void Update(ClassSessionLogAbsentObject obj)
      {
          new ClassSessionLogAbsentDao().Update(obj);
      }

      public void Delete(Guid id)
      {
          new ClassSessionLogAbsentDao().Delete(id);
      }
    }
}
