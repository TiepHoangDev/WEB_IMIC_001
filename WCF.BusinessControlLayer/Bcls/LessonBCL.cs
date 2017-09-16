using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class LessonBCL
    {
        public List<LessonObject> getElements()
        {
            return new LessonDAO().getElements();
        }

        public List<LessonObject> getElementsByCategoryId(Guid LessonCategoryId)
        {
            return new LessonDAO().getElementsByCategoryId(LessonCategoryId);
        }

        public LessonObject getElementById(Guid LessonId)
        {
            return new LessonDAO().getElementById(LessonId);
        }

        public bool addElement(LessonObject objLesson)
        {
            return new LessonDAO().addElement(objLesson);
        }

        public bool updateElement(LessonObject objLesson)
        {
            return new LessonDAO().updateElement(objLesson);
        }

        public void deleteElement(Guid LessonId)
        {
            new LessonDAO().deleteElement(LessonId);
        }
    }
}
