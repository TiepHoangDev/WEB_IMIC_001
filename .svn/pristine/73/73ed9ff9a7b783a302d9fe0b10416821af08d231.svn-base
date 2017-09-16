using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class ClassDao
    {
       public List<ClassObject> GetAll()
       {
           List<ClassObject> lstClass = new List<ClassObject>();
           WebIMicEntities db = new WebIMicEntities();
           foreach (var item in db.WEB_IMIC_SP_Class_GetAll())
           {
               ClassObject obj = new ClassObject();
               obj.ClassId = item.ClassId;
               obj.ClassName = item.ClassName;
               obj.BeginDate = item.BeginDate;
               obj.EndDate = item.EndDate;
               obj.IsStatus = item.IsStatus;
               obj.StudentNo = item.StudentNo;
               obj.Teached = item.Teached;
               lstClass.Add(obj);
           }
           return lstClass;
       }

       public ClassObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           ClassObject obj = new ClassObject();
           foreach (var item in db.WEB_IMIC_SP_Class_GetByID(id))
           {
               obj.ClassId = item.ClassId;
               obj.ClassName = item.ClassName;
               obj.BeginDate = item.BeginDate;
               obj.EndDate = item.EndDate;
               obj.IsStatus = item.IsStatus;
               obj.StudentNo = item.StudentNo;
               obj.Teached = item.Teached;
               return obj;
           }
           return null;
       }

       public void Insert(ClassObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Class_Insert(obj.ClassId, obj.ClassName, obj.BeginDate, obj.EndDate, obj.StudentNo,
               obj.IsStatus, obj.Teached);
       }

       public void Update(ClassObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Class_Update(obj.ClassId, obj.ClassName, obj.BeginDate, obj.EndDate, obj.StudentNo,
               obj.IsStatus, obj.Teached);
       }

       public void Delete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Class_Delete(id);
       }

       public void IsActived(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Class_IsActived(id, false);
       }

       public void IsUnActived(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Class_IsActived(id, true);
       }
    }
}
