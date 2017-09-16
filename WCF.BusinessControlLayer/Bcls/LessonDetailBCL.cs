using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class LessonDetailBCL
    {
        public List<LessonDetailObject> getElements()
        {
            return new LessonDetailDAO().getElements();
        }

        public LessonDetailObject getByCatIdAndRank(Guid id)
        {
            return new LessonDetailDAO().getElementById(id);
        }
        public List<LessonDetailObject> getElementsByLessonId(Guid LessonId)
        {
            return new LessonDetailDAO().getElementsByLessonId(LessonId);
        }

        public List<LessonDetailObject> GetByPrev_Next(long code)
        {
            return  new LessonDetailDAO().GetByPrev_Next(code);
        }
        public List<LessonDetailObject> getElementsByLessonId_PAGING(Guid? LessonId, int pageIndex, int pageSize)
        {
            return new LessonDetailDAO().getElementsByLessonId_PAGING(LessonId, pageIndex, pageSize);
        }

        public LessonDetailObject getElementById(Guid LessonDetailId)
        {
            return new LessonDetailDAO().getElementById(LessonDetailId);
        }

        public int getCount(Guid? LessonId)
        {
            return new LessonDetailDAO().getCount(LessonId);
        }

        public bool addElement(LessonDetailObject objLessonDetail)
        {
            return new LessonDetailDAO().addElement(objLessonDetail);
        }

        public bool updateElement(LessonDetailObject objLessonDetail)
        {
            return new LessonDetailDAO().updateElement(objLessonDetail);
        }

        public void deleteElement(Guid LessonDetailId)
        {
            new LessonDetailDAO().deleteElement(LessonDetailId);
        }
    }
}
