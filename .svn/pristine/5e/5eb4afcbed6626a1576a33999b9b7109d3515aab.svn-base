using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class ClassShiftDao
    {
       public List<ClassShiftObject> GetAll()
       {
           List<ClassShiftObject> lisDetail = new List<ClassShiftObject>();
           WebIMicEntities db = new WebIMicEntities();
           foreach (var item in db.WEB_IMIC_SP_ClassShift_GetAll())
           {
               ClassShiftObject obj = new ClassShiftObject();
               obj.ClassShiftId = item.ClassShiftId;
               obj.EndTime = item.EndTime;
               obj.ShiftName = item.ShiftName;
               obj.StartTime = item.StartTime;
               obj.IsActived = (bool)item.IsActived;
               lisDetail.Add(obj);
           }
           return lisDetail;
       }

       public ClassShiftObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           ClassShiftObject obj = new ClassShiftObject();
           foreach (var item in db.WEB_IMIC_SP_ClassShift_GetById(id))
           {
               obj.ClassShiftId = item.ClassShiftId;
               obj.EndTime = item.EndTime;
               obj.ShiftName = item.ShiftName;
               obj.StartTime = item.StartTime;
               obj.IsActived = (bool)item.IsActived;
               return obj;
           }
           return null;
       }

       public void Insert(ClassShiftObject obj)
       {
          WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassShift_Insert(obj.ClassShiftId, obj.ShiftName,obj.StartTime, obj.EndTime,obj.IsActived);
       }

       public void Update(ClassShiftObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassShift_Update(obj.ClassShiftId, obj.ShiftName, obj.StartTime, obj.EndTime, obj.IsActived);
       }

       public void Delete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassShift_Delete(id);
       }
    }
}
