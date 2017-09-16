using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.BusinessObjectsLayer.Commons;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class RegisterDetailDao : BaseModel<RegisterDetailObject>
    {

        public bool Insert(RegisterDetailObject objReg)
        {
            try
            {
                using (var db = new WebIMicEntities())
                {
                    db.WEB_IMIC_SP_RegisterDetail_Update(objReg.RegisterDetailId, objReg.ClassId,
                        objReg.RegisterPerson.RegisterPersonId, objReg.Message, objReg.Comment, objReg.Status,
                        objReg.IsSeen,
                        objReg.CreatedTime, objReg.CourseId, false);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public RegisterDetailObject getbyID(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            RegisterDetailObject obj = new RegisterDetailObject();
            foreach (var item in db.WEB_IMIC_SP_RegisterDetail_GetbyId_New(id))
            {
                obj.RegisterDetailId = item.RegisterDetailId;
                obj.Message = item.Message;
                obj.ClassId = item.ClassId;
                obj.CourseId = item.CourseId;
                obj.Comment = item.Comment;
                obj.CreatedTime = item.CreatedTime;
                obj.Status = item.Status;
                obj.IsDeleted = item.IsDeleted;
                obj.RegisterPersonId = item.RegisterPersonId;
                obj.IsSeen = item.IsSeen;
                obj.OpenClass = new OpenClassObject
                {
                    ClassName = item.ClassName
                };
                obj.Course = new CourseObject
                {
                    CourseName = item.CourseName
                };
                obj.RegisterPerson = new RegisterPersonObject();
                
                obj.RegisterPerson.FullName = item.FullName;
                obj.RegisterPerson.Address = item.Address;
                if (!string.IsNullOrEmpty(item.Email))
                {
                    obj.RegisterPerson.Email = new SecurityHelper().DecryptInfo(item.Email);
                }
                    
                obj.RegisterPerson.JobObj = new JobObject
                {
                    JobObjectName = item.JobObjectName
                };
                if (!string.IsNullOrEmpty(item.Phone))
                {
                    obj.RegisterPerson.Phone = new SecurityHelper().DecryptInfo(item.Phone);
                }
                    
                
                return obj;
            }
            return null;
        }
        public bool Update(RegisterDetailObject objReg)
        {
            
            try
            {
                using (var db = new WebIMicEntities())
                {
                    db.WEB_IMIC_SP_RegisterDetail_Update(objReg.RegisterDetailId, objReg.ClassId,
                        objReg.RegisterPersonId, objReg.Message, objReg.Comment, objReg.Status,
                        objReg.IsSeen,
                        objReg.CreatedTime, objReg.CourseId, true);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public List<RegisterDetailObject> GetRegisterDetail_IsSeen(bool isSeen = false)
        {
            List<RegisterDetailObject> lisRs = new List<RegisterDetailObject>();
            using (var db = new WebIMicEntities())
            {

                if (isSeen)
                {
                    var lisGet = db.WEB_IMIC_SP_RegisterDetail_GetAll_Seen();
                    foreach (var obj in lisGet)
                    {
                        lisRs.Add(new RegisterDetailObject()
                        {
                            ClassId = obj.ClassId,
                            Comment = obj.Comment,
                            CreatedTime = obj.CreatedTime,
                            IsSeen = obj.IsSeen,
                            Message = obj.Message,
                            IsDeleted = obj.IsDeleted,
                            RegisterDetailId = obj.RegisterDetailId,
                            //OpenClass = null,
                            //RegisterPerson = null,
                            RegisterPersonId = obj.RegisterPersonId,
                            Status = obj.Status,
                            CourseId = obj.CourseId
                        });
                    }
                }
                else
                {
                    var lisGet = db.WEB_IMIC_SP_RegisterDetail_GetAll_NotSeen();
                    foreach (var obj in lisGet)
                    {
                        lisRs.Add(new RegisterDetailObject()
                        {
                            ClassId = obj.ClassId,
                            Comment = obj.Comment,
                            CreatedTime = obj.CreatedTime,
                            IsSeen = obj.IsSeen,
                            Message = obj.Message,
                            IsDeleted = obj.IsDeleted,
                            RegisterDetailId = obj.RegisterDetailId,
                            //OpenClass = null,
                            //RegisterPerson = null,
                            RegisterPersonId = obj.RegisterPersonId,
                            CourseId = obj.CourseId
                        });
                    }
                }
            }
            //try
            //{
                
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
            return lisRs;
        }
    }
}
