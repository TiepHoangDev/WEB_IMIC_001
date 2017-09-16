using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class NewsCategoryBcl:BaseController<NewsCategoryObject>
    {
        public override List<NewsCategoryObject> execOfGetElements()
        {
            
            return new NewsCategoryDao().getAllElements();
        }
        public override List<NewsCategoryObject> execOfGetElementsById(Guid id)
        {
            return new NewsCategoryDao().getElementsById(id);
        }
    }
}
