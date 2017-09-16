using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
  public  class ClassSessionLogAbsentDao
    {
      public List<ClassSessionLogAbsentObject> GetAll()
      {
          WebIMicEntities db = new WebIMicEntities();
          List<ClassSessionLogAbsentObject> lstObj = new List<ClassSessionLogAbsentObject>();
          foreach (var item in  db.WEB_IMIC_SP_ClassSessionAbsent_GetAll())
          {
              ClassSessionLogAbsentObject obj = new ClassSessionLogAbsentObject();
              obj.LogAbsentStudentId = item.LogAbsentStudentId;
              obj.ClassSessionLogId = item.ClassSessionLogId;
              obj.StudentAccountId = item.StudentAccountId;
              obj.objAcc = new AccountObject
              {
                  AccountId = (Guid)item.StudentAccountId,
                  FullName = item.FullName
              };
              obj.objSessionLog = new ClassSessionLogObject
              {
                  ClassSessionLogId = item.ClassSessionLogId,
                  OnDate = item.OnDate
              };
              obj.Reason = item.Reason;
              lstObj.Add(obj);
          }
          return lstObj;
      }

      public ClassSessionLogAbsentObject GetByID(Guid id)
      {
          WebIMicEntities db = new WebIMicEntities();
          ClassSessionLogAbsentObject obj = new ClassSessionLogAbsentObject();
          foreach (var item in db.WEB_IMIC_SP_ClassSessionAbsent_GetByID(id))
          {
              obj.LogAbsentStudentId = item.LogAbsentStudentId;
              obj.ClassSessionLogId = item.ClassSessionLogId;
              obj.StudentAccountId = item.StudentAccountId;
              obj.Reason = item.Reason;
              return obj;
          }
          return null;
      }

      public void Insert(ClassSessionLogAbsentObject obj)
      {
          WebIMicEntities db = new WebIMicEntities();
          db.WEB_IMIC_SP_ClassSessionAbsent_Insert(obj.LogAbsentStudentId, obj.ClassSessionLogId, obj.StudentAccountId,
              obj.Reason);
      }

       public void Update(ClassSessionLogAbsentObject obj)
      {
          WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassSessionAbsent_Update(obj.LogAbsentStudentId, obj.ClassSessionLogId, obj.StudentAccountId,
               obj.Reason);
      }

      public void Delete(Guid id)
      {
          WebIMicEntities db = new WebIMicEntities();
          db.WEB_IMIC_SP_ClassSessionAbsent_Delete(id);
      }

    }
}
