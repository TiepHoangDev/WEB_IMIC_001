using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class ClassDetailDao
    {
       public List<ClassDetailObject> GetAll()
       {
           List<ClassDetailObject> lisDetail = new List<ClassDetailObject>();
           WebIMicEntities db = new WebIMicEntities();
           foreach (var item in db.WEB_IMIC_SP_ClassDetail_GetAll())
           {
               ClassDetailObject obj = new ClassDetailObject();
               obj.ClassDetailId = item.ClassDetailId;
               obj.ClassId = item.ClassId;
               obj.ClassRole = item.ClassRole;
               obj.DetailUser = item.DetailUser;
               obj.Description = item.Description;
               obj.objAcc = new AccountObject
               {
                   AccountId = (Guid)item.DetailUser,
                   FullName = item.FullName
               };
               obj.objClass = new ClassObject
               {
                   ClassId = item.ClassId,
                   ClassName = item.ClassName
               };

               lisDetail.Add(obj);
           }
           return lisDetail;
       }

       public ClassDetailObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           ClassDetailObject obj = new ClassDetailObject();
           foreach (var item in db.WEB_IMIC_SP_ClassDetail_GetByID(id))
           {
               obj.ClassDetailId = item.ClassDetailId;
               obj.ClassId = item.ClassId;
               obj.ClassRole = item.ClassRole;
               obj.DetailUser = item.DetailUser;
               obj.Description = item.Description;
               return obj;
           }
           return null;
       }

       public void Insert(ClassDetailObject obj)
       {
          WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassDetail_Insert(obj.ClassDetailId, obj.DetailUser, obj.ClassId, obj.ClassRole,
               obj.Description);
       }

       public void Update(ClassDetailObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassDetail_Update(obj.ClassDetailId, obj.DetailUser, obj.ClassId, obj.ClassRole,
               obj.Description);
       }

       public void Delete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_ClassDetail_Delete(id);
       }
    }
}
