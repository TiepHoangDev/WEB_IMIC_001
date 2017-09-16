using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class LessonCategoryBCL
    {
        public List<LessonCategoryObject> getElements()
        {
            return new LessonCategoryDAO().getElements();
        }

        public LessonCategoryObject getElementById(Guid LessonCategoryId)
        {
            return new LessonCategoryDAO().getElementById(LessonCategoryId);
        }

        public bool addElement(LessonCategoryObject objCategory)
        {
            return new LessonCategoryDAO().addElement(objCategory);
        }

        public bool updateElement(LessonCategoryObject objCategory)
        {
            return new LessonCategoryDAO().updateElement(objCategory);
        }

        public void deleteElement(Guid LessonCategoryId)
        {
            new LessonCategoryDAO().deleteElement(LessonCategoryId);
        }
    }
}
