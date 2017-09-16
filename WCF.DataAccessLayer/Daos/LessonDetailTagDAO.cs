using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class LessonDetailTagDAO : BaseModel<LessonDetailTagObject>
    {
        public List<LessonDetailTagObject> getElements()
        {
            WebIMicEntities db = new WebIMicEntities();
            List<LessonDetailTagObject> lisRs = new List<LessonDetailTagObject>();
            foreach (var item in db.WEB_IMIC_SP_LessonDetailTag_GETALL())
            {
                LessonDetailTagObject objTag = new LessonDetailTagObject();
                objTag.LessonDetailTagId = (Guid)item.LessonDetailTagId;
                objTag.LessonDetailTagName = item.LessonDetailTagName;
                objTag.TotalOfLessons = (int)item.TotalOfLessons;
                objTag.isShowed = (bool) item.IsShowed;
                lisRs.Add(objTag);
            }
            return lisRs;

        }

        public List<LessonDetailTagObject> getByLessonDetail(Guid LessonDetailId)
        {
            WebIMicEntities db = new WebIMicEntities();
            List<LessonDetailTagObject> lisRs = new List<LessonDetailTagObject>();
            foreach (var item in db.WEB_IMIC_SP_LessonDetailTag_GETBYLESSONDETAILID(LessonDetailId))
            {
                LessonDetailTagObject objTag = new LessonDetailTagObject();
                objTag.LessonDetailTagId = (Guid)item.LessonDetailTagId;
                objTag.LessonDetailTagName = item.LessonDetailTagName;
                lisRs.Add(objTag);
            }
            return lisRs;
        }

        public LessonDetailTagObject getElementById(Guid Id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_LessonDetailTag_GETBYID(Id))
            {
                LessonDetailTagObject objTag = new LessonDetailTagObject();
                objTag.LessonDetailTagId = (Guid)item.LessonDetailTagId;
                objTag.LessonDetailTagName = item.LessonDetailTagName;
                objTag.TotalOfLessons = (int)item.TotalOfLessons;
                return objTag;
            }
            return null;

        }
        public bool CheckNameExisted(string TagName)
        {
            WebIMicEntities db = new WebIMicEntities();
            if (db.WEB_IMIC_SP_LessonDetailTag_CHECKNAME(TagName).ToList()[0] > 0)
                return true;
            return false;
        }
        public void addElement(LessonDetailTagObject objTag)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_LessonDetailTag_INSERT(objTag.LessonDetailTagId, objTag.LessonDetailTagName, objTag.TotalOfLessons);
        }
        public void updateElement(LessonDetailTagObject objTag)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_LessonDetailTag_UPDATE(objTag.LessonDetailTagId, objTag.LessonDetailTagName, objTag.TotalOfLessons);
        }
        public void deleteElement(Guid id)
        {
            new WebIMicEntities().WEB_IMIC_SP_LessonDetailTag_DELETE(id);
        }
    }
}
