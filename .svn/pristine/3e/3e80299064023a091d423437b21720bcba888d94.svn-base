using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
  public class ClassSessionLogDao
    {
      public List<ClassSessionLogObject> GetAll()
      {
          WebIMicEntities db = new WebIMicEntities();
          List<ClassSessionLogObject> list = new List<ClassSessionLogObject>();
          foreach (var item in db.WEB_IMIC_SP_ClassSessionLog_GetAll())
          {
              ClassSessionLogObject obj = new ClassSessionLogObject();
              obj.ClassSessionLogId = item.ClassSessionLogId;
              obj.ClassId = item.ClassId;
              obj.OnDate = item.OnDate;
              obj.TeacherAccountId = item.TeacherAccountId;
              obj.Description = item.Description;
              obj.LessonContent = item.LessonContent;
              obj.IsActived = item.IsActived;
              obj.IsDeleted = item.IsDeleted;
              obj.objAcc = new AccountObject
              {
                  AccountId = (Guid)item.TeacherAccountId,
                  FullName = item.FullName
              };
              obj.objClass = new ClassObject
              {
                  ClassId = (Guid)item.ClassId,
                  ClassName = item.ClassName
              };
              list.Add(obj);
          }
          return list;
      }

      public ClassSessionLogObject GetByID(Guid id)
      {
          WebIMicEntities db = new WebIMicEntities();
          ClassSessionLogObject obj = new ClassSessionLogObject();
          foreach (var item in db.WEB_IMIC_SP_ClassSessionLog_GetByID(id))
          {
              obj.ClassSessionLogId = item.ClassSessionLogId;
              obj.ClassId = item.ClassId;
              obj.OnDate = item.OnDate;
              obj.TeacherAccountId = item.TeacherAccountId;
              obj.Description = item.Description;
              obj.LessonContent = item.LessonContent;
              obj.IsActived = item.IsActived;
              obj.IsDeleted = item.IsDeleted;
              return obj;
          }
          return null;
      }

      public void Insert(ClassSessionLogObject obj)
      {
          WebIMicEntities db = new WebIMicEntities();
          db.WEB_IMIC_SP_ClassSessionLog_Insert(obj.ClassSessionLogId, obj.ClassId, obj.TeacherAccountId, obj.OnDate,
              obj.LessonContent, obj.Description, obj.IsActived, obj.IsDeleted);
      }
      public void Update(ClassSessionLogObject obj)
      {
          WebIMicEntities db = new WebIMicEntities();
          db.WEB_IMIC_SP_ClassSessionLog_Update(obj.ClassSessionLogId, obj.ClassId, obj.TeacherAccountId, obj.OnDate,
              obj.LessonContent, obj.Description, obj.IsActived, obj.IsDeleted);
      }

      public void Delete(Guid id)
      {
          WebIMicEntities db = new WebIMicEntities();
          db.WEB_IMIC_SP_ClassSessionLog_Delete(id);
      }
      public void IsActived(Guid id)
      {
          WebIMicEntities db = new WebIMicEntities();
          db.WEB_IMIC_SP_ClassSessionLog_IsActived(id, false);
      }

      public void IsUnActived(Guid id)
      {
          WebIMicEntities db = new WebIMicEntities();
          db.WEB_IMIC_SP_ClassSessionLog_IsActived(id, true);
      }
    }
}
