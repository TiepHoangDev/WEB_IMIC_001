using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class ClassDetailBcl
    {
        public List<ClassDetailObject> GetAll()
        {
            return new ClassDetailDao().GetAll();
        }

        public ClassDetailObject GetById(Guid id)
        {
            return new ClassDetailDao().GetByID(id);
        }

        public void Insert(ClassDetailObject obj)
        {
            new ClassDetailDao().Insert(obj);
        }

        public void Update(ClassDetailObject obj)
        {
            new ClassDetailDao().Update(obj);
        }

        public void Delelte(Guid id)
        {
            new ClassDetailDao().Delete(id);
        }
    }
}
