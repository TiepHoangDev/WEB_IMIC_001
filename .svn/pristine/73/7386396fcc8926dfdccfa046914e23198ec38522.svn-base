using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class TechLinkBcl
    {
        public List<TechLinkObject> GetAll()
        {
            return new TechLinkDao().GetAll();
        }

        public TechLinkObject GetByID(Guid id)
        {
            return new TechLinkDao().getByID(id);
        }

        public void Insert(TechLinkObject obj)
        {
            new TechLinkDao().Insert(obj);
        }

        public void Update(TechLinkObject obj)
        {
             new TechLinkDao().Update(obj);
        }

        public void Delete(Guid id)
        {
             new TechLinkDao().Delete(id);
        }
    }
}
