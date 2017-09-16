using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.DataAccessLayer.Daos
{
    public class BaseModel<T>
    {
        
        public virtual List<T> getElements()
        {
            return null;
        }

        public virtual List<T> getAllElements()
        {
            return null;
        }

        public virtual List<T> getElements(object obj)
        {
            return null;
        }

        public virtual List<T> getElementsById(Guid id)
        {
            return null;
        }

        public virtual List<T> getElementByPageIndex(int pageSize, int pageIndex)
        {
            return null;
        }
    }
}
