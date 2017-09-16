using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class ClassWeekDayDao
    {
       public List<ClassWeekDayObject> GetAll()
       {
           List<ClassWeekDayObject> lisDetail = new List<ClassWeekDayObject>();
           WebIMicEntities db = new WebIMicEntities();
           foreach (var item in db.WEB_IMIC_SP_ClassWeekDay_GetAll())
           {
               ClassWeekDayObject obj = new ClassWeekDayObject();
               obj.ClassWeekDayId = item.ClassWeekDayId;
               obj.WeekName = item.WeekName;
               lisDetail.Add(obj);
           }
           return lisDetail;
       }

       public ClassWeekDayObject GetByID(int id)
       {
           WebIMicEntities db = new WebIMicEntities();
           ClassWeekDayObject obj = new ClassWeekDayObject();
           foreach (var item in db.WEB_IMIC_SP_ClassWeekDay_GetById(id))
           {
               obj.ClassWeekDayId = item.ClassWeekDayId;
               obj.WeekName = item.WeekName;
               return obj;
           }
           return null;
       }

       public void Insert(ClassWeekDayObject obj)
       {
          WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassWeekDay_Insert(obj.WeekName);
       }

       public void Update(ClassWeekDayObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassWeekDay_Update(obj.ClassWeekDayId,obj.WeekName);
       }

       public void Delete(int id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassWeekDay_Delete(id);
       }
    }
}
