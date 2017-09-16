using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class LocationDao
    {
        public List<LocationObject> getElement()
        {
            List<LocationObject> lstLocation = new List<LocationObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_Location_GetAll())
            {
                LocationObject objLocation = new LocationObject();
                objLocation.LocationID = item.LocationID;
                objLocation.LocationName = item.LocationName;
                lstLocation.Add(objLocation);
            }
            return lstLocation;
        }
    }
}
