using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class LessonDetailTagDetailDAO : BaseModel<LessonDetailTagDetailObject>
    {
        public void addElement(LessonDetailTagDetailObject objDetail)
        {
            new WebIMicEntities().WEB_IMIC_SP_LessonDetailTagDetail_INSERT(objDetail.LessonDetailTagDetailId, 
                objDetail.LessonDetailId, objDetail.LessonDetailTagId);
        }
        public void deleteElementByLessonDetail(Guid LessonDetailId)
        {
            new WebIMicEntities().WEB_IMIC_SP_LessonDetailTagDetail_DELETEBYLESSONDETAILID(LessonDetailId);
        }
    }
}
