using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class OpenClassDao:BaseModel<OpenClassObject>
    {
        // Ngocnb 05112016 - Lấy 1 lớp học qua mã - code chưa toi uu
        public override List<OpenClassObject> getElementsById(Guid id)
        {
            List<OpenClassObject> lisAll = this.getAllElements();
            List<OpenClassObject> lisRs = lisAll.Where(q => q.ClassId == id).ToList();
            return lisRs;
        }
        public OpenClassObject getById(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_OpenClass_GetByID(id))
            {
                OpenClassObject objOc = new OpenClassObject();

                objOc.ClassId = item.ClassId;
                objOc.ClassName = item.ClassName;
                objOc.ClassAvatar = item.ClassAvatar;
                objOc.ClassTime = item.ClassTime;
                objOc.ContentPopup = item.ContentPopup;
                objOc.DayOfMonth = item.DayOfMonth;
                objOc.DayOfWeek = item.DayOfWeek;
                objOc.Month = item.Month;
                objOc.ApprovedBy = item.ApprovedBy;
                objOc.MaxTotalOfStudents = item.MaxTotalOfStudents;
                objOc.ModifiedTime = item.ModifiedTime;
                objOc.CourseId = item.CourseId;
                objOc.ModifiedBy = item.ModifiedBy;
                objOc.TotalOfRegisters = item.TotalOfRegisters;
                objOc.IsApproved = item.IsApproved;
                objOc.LocationID =item.LocationID;
               
                objOc.IsDeleted = item.IsDeleted;
                return objOc;
            }
            return null;
            //List<OpenClassObject> lisAll = this.getAllElements();
            //List<OpenClassObject> lisRs = lisAll.Where(q => q.ClassId == id).ToList();
            //return lisRs;
        }

        public override List<OpenClassObject> getAllElements()
        {
            List<OpenClassObject> lisOc = new List<OpenClassObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_OPENCLASS_GetAll().ToList();
                foreach (var item in lisTemp)
                {
                    OpenClassObject objOc = new OpenClassObject();
                    
                    objOc.ClassId = item.ClassId;
                    objOc.ClassName = item.ClassName;
                    objOc.ClassAvatar = item.ClassAvatar;
                    objOc.ClassTime = item.ClassTime;
                    objOc.ContentPopup = item.ContentPopup;
                    objOc.DayOfMonth = item.DayOfMonth;
                    objOc.DayOfWeek = item.DayOfWeek;
                    objOc.Month = item.Month;
                    objOc.ApprovedBy = item.ApprovedBy;
                    objOc.MaxTotalOfStudents = item.MaxTotalOfStudents;
                    objOc.ModifiedTime = item.ModifiedTime;
                    objOc.CourseId = item.CourseId;
                    objOc.ModifiedBy = item.ModifiedBy;
                    objOc.TotalOfRegisters = item.TotalOfRegisters;
                    objOc.IsApproved = item.IsApproved;
                    objOc.LocationID =item.LocationID;
                
                    objOc.IsDeleted = item.IsDeleted;
                    try
                    {
                        var temp = new CourseDao().GetCourseObjectByCourseId((Guid) objOc.CourseId).FirstOrDefault();
                        objOc.Course = new CourseObject
                        {
                            CourseCodeNumber = temp.CourseCodeNumber,
                            CourseName = temp.CourseName
                        };
                    }
                    catch(Exception e)
                    {
                        objOc.Course = null;
                    }
                    
                    lisOc.Add(objOc);
                }
            }
            return lisOc;
        }
        public bool InsertClass(OpenClassObject objCO)
        {
            using (var dbContext = new WebIMicEntities())
            {
                objCO.ClassId = Guid.NewGuid();

                // Insert tblOpenClass
                dbContext.WEB_IMIC_SP_OPENCLASS_update(objCO.ClassId, objCO.CourseId, objCO.ClassName, objCO.ClassAvatar,
                    objCO.ClassTime, objCO.Month, objCO.DayOfMonth, objCO.ContentPopup, objCO.DayOfWeek,
                    objCO.TotalOfRegisters, objCO.ModifiedBy, DateTime.Now, null, null, null, objCO.MaxTotalOfStudents,objCO.LocationID,
                    false);

            }
            return true;
        }
        public bool UpdateClass(OpenClassObject objCO)
        {
            using (var dbContext = new WebIMicEntities())
            {


                // Update tblOpenClass
                dbContext.WEB_IMIC_SP_OPENCLASS_update(objCO.ClassId, objCO.CourseId, objCO.ClassName, objCO.ClassAvatar,
                    objCO.ClassTime, objCO.Month, objCO.DayOfMonth, objCO.ContentPopup, objCO.DayOfWeek,
                    objCO.TotalOfRegisters, objCO.ModifiedBy, DateTime.Now, true, null, false, objCO.MaxTotalOfStudents,objCO.LocationID,
                    true);


            }
            return true;
        }
        public bool DeleteClass(Guid classId)
        {
            using (var dbContext = new WebIMicEntities())
            {
                // Chuyển isdeleted của news = true
                dbContext.WEB_IMIC_SP_OPENCLASS_updateIsDeleted(classId, true);

            }
            return true;
        }
        public List<OpenClassObject> getAllElementsByTCCodeNumber(int tcCodeNumber)
        {
            List<OpenClassObject> lisOc = new List<OpenClassObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_OPENCLASS_GetAllByTCCodeNumber(tcCodeNumber).ToList();
                foreach (var item in lisTemp)
                {
                    OpenClassObject objOc = new OpenClassObject();

                    objOc.ClassId = item.ClassId;
                    objOc.ClassName = item.ClassName;
                    objOc.ClassAvatar = item.ClassAvatar;
                    objOc.ClassTime = item.ClassTime;
                    objOc.ContentPopup = item.ContentPopup;
                    objOc.DayOfMonth = item.DayOfMonth;
                    objOc.DayOfWeek = item.DayOfWeek;
                    objOc.Month = item.Month;
                    objOc.ApprovedBy = item.ApprovedBy;
                    objOc.MaxTotalOfStudents = item.MaxTotalOfStudents;
                    objOc.ModifiedTime = item.ModifiedTime;
                    objOc.CourseId = item.CourseId;
                    objOc.ModifiedBy = item.ModifiedBy;
                    objOc.TotalOfRegisters = item.TotalOfRegisters;
                    objOc.IsApproved = item.IsApproved;
                    objOc.IsDeleted = item.IsDeleted;
                    lisOc.Add(objOc);
                }
            }
            return lisOc;
        }
        public List<OpenClassObject> getAllElementsByTrainingCategoryId(Guid trainingCatId)
        {
            List<OpenClassObject> lisOc = new List<OpenClassObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_OPENCLASS_GetAllByTrainingCatId(trainingCatId);
                foreach (var item in lisTemp)
                {
                    OpenClassObject objOc = new OpenClassObject();

                    objOc.ClassId = item.ClassId;
                    objOc.ClassName = item.ClassName;
                    objOc.ClassAvatar = item.ClassAvatar;
                    objOc.ClassTime = item.ClassTime;
                    objOc.ContentPopup = item.ContentPopup;
                    objOc.DayOfMonth = item.DayOfMonth;
                    objOc.DayOfWeek = item.DayOfWeek;
                    objOc.Month = item.Month;
                    objOc.ApprovedBy = item.ApprovedBy;
                    objOc.MaxTotalOfStudents = item.MaxTotalOfStudents;
                    objOc.ModifiedTime = item.ModifiedTime;
                    objOc.CourseId = item.CourseId;
                    objOc.ModifiedBy = item.ModifiedBy;
                    objOc.TotalOfRegisters = item.TotalOfRegisters;
                    objOc.IsApproved = item.IsApproved;
                    objOc.IsDeleted = item.IsDeleted;
                    lisOc.Add(objOc);
                }
            }
            return lisOc;
        }
    }
}
