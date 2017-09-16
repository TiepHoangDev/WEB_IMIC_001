using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class RoleDao : BaseModel<RoleObject>
    {
        public List<RoleObject> getElement()
        {
            WebIMicEntities db = new WebIMicEntities();
            List<RoleObject> lstRole = new List<RoleObject>();
            foreach (var i in db.WEB_IMIC_SP_Role_GetAll())
            {
                RoleObject objRole = new RoleObject();
                objRole.RoleId = i.RoleId;
                objRole.RoleName = i.RoleName;
                objRole.RoleIcon = i.RoleIcon;
                lstRole.Add(objRole);
            }
            return lstRole;
        }

        public RoleObject GetByID(byte id)
        {
            WebIMicEntities db = new WebIMicEntities();
            var lstRole = db.WEB_IMIC_SP_Role_ByID(id);
            RoleObject objRole = new RoleObject();
            foreach (var item in lstRole)
            {
                objRole.RoleId = item.RoleId;
                objRole.RoleName = item.RoleName;
                objRole.RoleIcon = item.RoleIcon;
            }
            return objRole;
        }
    }
}
