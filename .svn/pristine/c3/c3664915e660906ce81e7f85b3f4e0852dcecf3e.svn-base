using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class TechLogoBcl
    {
        public List<TechLogoObject> GetAll()
        {
            return new TechLogoDao().GetAll();
        }

        public TechLogoObject GetById(Guid id)
        {
            return new TechLogoDao().GetByID(id);
        }

        public void Insert(TechLogoObject obj)
        {
            new TechLogoDao().Insert(obj);
        }

        public void Update(TechLogoObject obj)
        {
            new TechLogoDao().Update(obj);
        }

        public void Delete(Guid id)
        {
            new TechLogoDao().Delete(id);
        }
    }
}
