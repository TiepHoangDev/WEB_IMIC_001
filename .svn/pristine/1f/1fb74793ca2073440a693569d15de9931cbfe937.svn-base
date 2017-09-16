using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class ClassSessionDetailDao
    {
       public List<ClassSessionDetailObject> GetAll()
       {
           List<ClassSessionDetailObject> lisDetail = new List<ClassSessionDetailObject>();
           WebIMicEntities db = new WebIMicEntities();
           foreach (var item in db.WEB_IMIC_SP_ClassSessionDetail_GetAll())
           {
               ClassSessionDetailObject obj = new ClassSessionDetailObject();
               
               obj.ClassSessionDetailId = item.ClassSessionDetailId;
               obj.ClassId = (Guid)item.ClassId;
               obj.ClassShiftid = (Guid)item.ClassShiftId;
               obj.ClassWeekdayId = (int)item.ClassWeekdayId;
               obj.IsActived = (bool)item.IsActived;
               obj.OnDate = (DateTime)item.OnDate;
               obj.ClassObject = new ClassObject
               {
                   ClassId = (Guid)item.ClassId,
                   ClassName = item.ClassName
               };
               obj.ClassShiftObject = new ClassShiftObject
               {
                   ClassShiftId = (Guid) item.ClassShiftId,
                   ShiftName = item.ShiftName
               };
               obj.ClassWeekDayObject = new ClassWeekDayObject
               {
                   ClassWeekDayId = (int) item.ClassWeekdayId,
                   WeekName = item.WeekName
               };
               lisDetail.Add(obj);
           }
           return lisDetail;
       }

       public ClassSessionDetailObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           ClassSessionDetailObject obj = new ClassSessionDetailObject();
           foreach (var item in db.WEB_IMIC_SP_ClassSessionDetail_GetById(id))
           {
               obj.ClassSessionDetailId = item.ClassSessionDetailId;
               obj.ClassId = (Guid)item.ClassId;
               obj.ClassShiftid = (Guid)item.ClassShiftId;
               obj.ClassWeekdayId = (int)item.ClassWeekdayId;
               obj.IsActived = (bool)item.IsActived;
               obj.OnDate = (DateTime)item.OnDate;
               obj.ClassObject = new ClassObject
               {
                   ClassId = (Guid)item.ClassId,
                   ClassName = item.ClassName
               };
               obj.ClassShiftObject = new ClassShiftObject
               {
                   ClassShiftId = (Guid)item.ClassShiftId,
                   ShiftName = item.ShiftName
               };
               obj.ClassWeekDayObject = new ClassWeekDayObject
               {
                   ClassWeekDayId = (int)item.ClassWeekdayId,
                   WeekName = item.WeekName
               };
               return obj;
           }
           return null;
       }

       public void Insert(ClassSessionDetailObject obj)
       {
          WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassSessionDetail_Insert(obj.ClassSessionDetailId,obj.ClassId,obj.ClassShiftid,obj.ClassWeekdayId,obj.IsActived,obj.OnDate);
       }

       public void Update(ClassSessionDetailObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassSessionDetail_Update(obj.ClassSessionDetailId, obj.ClassId, obj.ClassShiftid,obj.ClassWeekdayId, obj.IsActived, obj.OnDate);
       }

       public void Delete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassSessionDetail_Delete(id);
       }
    }
}
