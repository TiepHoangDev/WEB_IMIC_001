using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class LessonDetailTagBCL
    {
        public List<LessonDetailTagObject> getElements()
        {
            return new LessonDetailTagDAO().getElements();
        }

        public List<LessonDetailTagObject> getByLessonDetail(Guid LessonDetailId)
        {
            return new LessonDetailTagDAO().getByLessonDetail(LessonDetailId);
        }

        public LessonDetailTagObject getElementById(Guid Id)
        {
            return new LessonDetailTagDAO().getElementById(Id);
        }

        public bool CheckNameExisted(string TagName)
        {
            return new LessonDetailTagDAO().CheckNameExisted(TagName);
        }

        public void addElement(LessonDetailTagObject objTag)
        {
            new LessonDetailTagDAO().addElement(objTag);
        }

        public void updateElement(LessonDetailTagObject objTag)
        {
            new LessonDetailTagDAO().updateElement(objTag);
        }

        public void deleteElement(Guid id)
        {
            new LessonDetailTagDAO().deleteElement(id);
        }
    }
}
