
using System;
using System.Collections.Generic;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class RecruitmentLocationDao
    {

        public List<RecruitmentLocationObject> GetAll()
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_RecruitmentLocation_GetAll();
            List<RecruitmentLocationObject> lst = new List<RecruitmentLocationObject>();
            foreach (var item in list)
            {
                var obj = new RecruitmentLocationObject();

                obj.LocationName = item.LocationName;
                obj.RecLocationId = item.RecLocationId;
                lst.Add(obj);
            }
            return lst;
        }


        public RecruitmentLocationObject GetByRecLocationId(System.Int32 RecLocationId)
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_RecruitmentLocation_GetByRecLocationId(RecLocationId);
            foreach (var item in list)
            {
                var obj = new RecruitmentLocationObject();

                obj.LocationName = item.LocationName;
                obj.RecLocationId = item.RecLocationId;
                return obj;
            }
            return null;
        }


        public bool Insert(RecruitmentLocationObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecruitmentLocation_Insert(ob.LocationName) > 0;
        }


        public bool Delete(System.Int32 RecLocationId)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecruitmentLocation_Delete(RecLocationId) > 0;
        }


        public bool Update(RecruitmentLocationObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecruitmentLocation_Update(ob.LocationName, ob.RecLocationId) > 0;
        }

    }
}
