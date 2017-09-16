using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class ProposeDao
    {
       public List<ProposeObject> GetAll()
       {
           WebIMicEntities db = new WebIMicEntities();
           List<ProposeObject> lisObj =  new List<ProposeObject>();
           foreach (var item in db.WEB_IMIC_SP_Propose_GetAll())
           {
               ProposeObject obj = new ProposeObject();
               obj.ProposeId = item.ProposeId;
               obj.ProposeName = item.ProposeName;
               obj.CreateDate = item.CreateDate;
               
               obj.No = item.No;
               obj.RegisterBy = item.RegisterBy;
               obj.RegisterDate = item.RegisterDate;
               obj.IsRegister = item.IsRegister;
              
               lisObj.Add(obj);
           }
           return lisObj;
       }
     
       public ProposeObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
          
           foreach (var item in db.WEB_IMIC_SP_Propose_GetByID(id))
           {
               ProposeObject obj = new ProposeObject();
               obj.ProposeId = item.ProposeId;
               obj.ProposeName = item.ProposeName;
               obj.CreateDate = item.CreateDate;
               obj.No = item.No;
               obj.RegisterBy = item.RegisterBy;
               obj.RegisterDate = item.RegisterDate;
               obj.IsRegister = item.IsRegister;
           
               return obj;
           }
           return null;
       }

       public void Insert(ProposeObject obj )
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Propose_Insert(obj.ProposeId, obj.ProposeName, obj.CreateDate, obj.IsRegister);
       }

       public void Update(ProposeObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Propose_Update(obj.ProposeId, obj.ProposeName, obj.CreateDate, obj.IsRegister);
       }

       public void UpdateByUser(ProposeObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Propose_UpdateByUser(obj.ProposeId, obj.RegisterBy, obj.RegisterDate);
       }

       public void UnRegister(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Propose_UnRegister(id);
       }
       public void Delete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Propose_Delete(id);
       }
    }
}
