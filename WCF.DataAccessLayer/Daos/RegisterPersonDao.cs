using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class RegisterPersonDao : BaseModel<RegisterPersonObject>
    {
        public bool Insert(RegisterPersonObject obj)
        {
            if (!string.IsNullOrEmpty(obj.Email))
            {
                string EmailTemp = new SecurityHelper().EncryptInfo(obj.Email);
                obj.Email = EmailTemp;
            }
            if (!string.IsNullOrEmpty(obj.Phone))
            {
                string PhoneTemp = new SecurityHelper().EncryptInfo(obj.Phone);
                obj.Phone = PhoneTemp;
            }
            
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_RegisterPerson_Update(obj.RegisterPersonId, obj.FullName, obj.Email, obj.Phone,
                    obj.Address, obj.JobObjectId, false);
            }
            return true;
        }

        public RegisterPersonObject GetById(Guid id)
        {
            RegisterPersonObject oRs = null;
            using (var db = new WebIMicEntities())
            {
                var oGet = db.WEB_IMIC_SP_RegisterPerson_GetById(id).FirstOrDefault();
                oRs = new RegisterPersonObject();
                if (!string.IsNullOrEmpty(oGet.Address))
                {
                    oRs.Address = oGet.Address;
                }
                
                if (!string.IsNullOrEmpty(oGet.Email))
                {
                    oRs.Email = new SecurityHelper().DecryptInfo(oGet.Email);
                }
                
                oRs.FullName = oGet.FullName;
                oRs.IsDeleted = oGet.IsDeleted;
                oRs.JobObj = null;
                oRs.JobObjectId = oGet.JobObjectId;
                if (!string.IsNullOrEmpty(oGet.Phone))
                {
                    oRs.Phone = new SecurityHelper().DecryptInfo(oGet.Phone);
                }
                
                oRs.RegisterDetail = null;
                oRs.RegisterPersonId = oGet.RegisterPersonId;

            }

            return oRs;
        }
    }
}
