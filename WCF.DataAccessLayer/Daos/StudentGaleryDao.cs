using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class StudentGaleryDao : BaseModel<StudentGaleryObject>
    {
        public List<StudentGaleryObject> getElements()
        {
            WebIMicEntities db = new WebIMicEntities();
            List<StudentGaleryObject> lstStudent = new List<StudentGaleryObject>();
            foreach (var i in db.WEB_IMIC_SP_StudentGalery_GetAll())
            {
                StudentGaleryObject objStudent = new StudentGaleryObject();
                objStudent.ImageID = i.ImageId;
                objStudent.imageName = i.ImageName;
                objStudent.ImageThumbnail = i.ImageThumbnail;
                objStudent.ImageLink = i.ImageLink;
                objStudent.TotalOfViews = (int)i.TotalOfViews;
                objStudent.StudentDescription = i.StudentDescription;
                objStudent.ModifiedBy = i.ModifiedBy.GetValueOrDefault();
                objStudent.ModifiedTime = (DateTime)i.ModifiedTime;
                objStudent.IsApproved = (bool)i.IsApproved;
                objStudent.ApprovedBy = i.ApprovedBy.GetValueOrDefault();
                objStudent.FlagThumbnail = (bool)i.FlagThumbnail;
                objStudent.FlagLink = (bool)i.FlagLink;
                objStudent.IsDeleted = (bool)i.IsDeleted;
                lstStudent.Add(objStudent);
            }
            return lstStudent;
        }
        public StudentGaleryObject getElementsById(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var i in db.WEB_IMIC_SP_StudentGalery_GetByID(id))
            {
                StudentGaleryObject objStudent = new StudentGaleryObject();
                objStudent.ImageID = i.ImageId;
                objStudent.imageName = i.ImageName;
                objStudent.ImageThumbnail = i.ImageThumbnail;
                objStudent.ImageLink = i.ImageLink;
                objStudent.TotalOfViews = (int)i.TotalOfViews;
                objStudent.StudentDescription = i.StudentDescription;
                objStudent.ModifiedBy = i.ModifiedBy.GetValueOrDefault();
                objStudent.ModifiedTime = (DateTime)i.ModifiedTime;
                objStudent.IsApproved = (bool)i.IsApproved;
                objStudent.ApprovedBy = i.ApprovedBy.GetValueOrDefault();
                objStudent.FlagThumbnail = (bool)i.FlagThumbnail;
                objStudent.FlagLink = (bool)i.FlagLink;
                objStudent.IsDeleted = (bool)i.IsDeleted;
                return objStudent;
            }
            return null;
        }
        public void addElements(StudentGaleryObject objStudent)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_StudentGalery_update(objStudent.ImageID, objStudent.imageName, objStudent.ImageThumbnail, objStudent.ImageLink,
                objStudent.TotalOfViews, objStudent.StudentDescription, objStudent.ModifiedBy, objStudent.ModifiedTime, objStudent.IsApproved,
                objStudent.ApprovedBy, objStudent.FlagThumbnail, objStudent.FlagLink, objStudent.IsDeleted, false);
            //db.SaveChanges();
        }
        public void updateElements(StudentGaleryObject objStudent)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_StudentGalery_update(objStudent.ImageID, objStudent.imageName, objStudent.ImageThumbnail, objStudent.ImageLink,
                objStudent.TotalOfViews, objStudent.StudentDescription, objStudent.ModifiedBy, objStudent.ModifiedTime, objStudent.IsApproved,
                objStudent.ApprovedBy, objStudent.FlagThumbnail, objStudent.FlagLink, objStudent.IsDeleted, true);
            //db.SaveChanges();
        }
        public void deleteElement(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_StudentGalery_Delete(id);
        }
    }
}
