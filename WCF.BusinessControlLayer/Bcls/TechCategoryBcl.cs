using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class TechCategoryBcl
    {
        public List<TechCategoryObject> getElements()
        {
            return new TechCategoryDao().getElements();
        }
        public TechCategoryObject getElementById(Guid id)
        {
            return new TechCategoryDao().getElementById(id);
        }
        public void addElement(TechCategoryObject objCat)
        {
            new TechCategoryDao().addElement(objCat);
        }
        public void updateElement(TechCategoryObject objCat)
        {
            new TechCategoryDao().updateElement(objCat);
        }
        public void deleteElement(Guid id)
        {
            new TechCategoryDao().deleteElement(id);
        }
    }
}
