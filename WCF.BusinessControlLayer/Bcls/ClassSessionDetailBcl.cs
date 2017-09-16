using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class ClassSessionDetailBcl
    {
        #region Class Session Detail
        public List<ClassSessionDetailObject> ClassSessionDetailGetAll()
        {
            return new ClassSessionDetailDao().GetAll();
        }

        public ClassSessionDetailObject ClassSessionDetailGetById(Guid id)
        {
            return new ClassSessionDetailDao().GetByID(id);
        }

        public void ClassSessionDetailInsert(ClassSessionDetailObject obj)
        {
            new ClassSessionDetailDao().Insert(obj);
        }

        public void ClassSessionDetailUpdate(ClassSessionDetailObject obj)
        {
            new ClassSessionDetailDao().Update(obj);
        }

        public void ClassSessionDetailDelete(Guid id)
        {
            new ClassSessionDetailDao().Delete(id);
        }
        #endregion
        
        
        #region Class Weekday

        public List<ClassWeekDayObject> ClassWeekDayGetAll()
        {
            return new ClassWeekDayDao().GetAll();
        }

        public ClassWeekDayObject ClassWeekDayGetById(int id)
        {
            return new ClassWeekDayDao().GetByID(id);
        }

        public void ClassWeekDayInsert(ClassWeekDayObject obj)
        {
            new ClassWeekDayDao().Insert(obj);
        }

        public void ClassWeekDayUpdate(ClassWeekDayObject obj)
        {
            new ClassWeekDayDao().Update(obj);
        }

        public void ClassWeekDayDelete(int id)
        {
            new ClassWeekDayDao().Delete(id);
        }
        #endregion
        
        
        #region Class Shift
        public List<ClassShiftObject> ClassShiftGetAll()
        {
            return new ClassShiftDao().GetAll();
        }

        public ClassShiftObject ClassShiftGetById(Guid id)
        {
            return new ClassShiftDao().GetByID(id);
        }

        public void ClassShiftInsert(ClassShiftObject obj)
        {
            new ClassShiftDao().Insert(obj);
        }

        public void ClassShiftUpdate(ClassShiftObject obj)
        {
            new ClassShiftDao().Update(obj);
        }

        public void ClassShiftDelete(Guid id)
        {
            new ClassShiftDao().Delete(id);
        }
        #endregion
       

    }
}
