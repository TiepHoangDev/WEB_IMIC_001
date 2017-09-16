
using System;
using System.Collections.Generic;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class RecExperienceDao
    {

        public List<RecExperienceObject> GetAll()
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_RecExperience_GetAll();
            List<RecExperienceObject> lst = new List<RecExperienceObject>();
            foreach (var item in list)
            {
                var obj = new RecExperienceObject();

                obj.RecExperienceId = item.RecExperienceId;
                obj.RecExperienceName = item.RecExperienceName;
                lst.Add(obj);
            }
            return lst;
        }


        public RecExperienceObject GetByRecExperienceId(byte RecExperienceId)
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_RecExperience_GetByRecExperienceId(RecExperienceId);
            foreach (var item in list)
            {
                var obj = new RecExperienceObject();

                obj.RecExperienceId = item.RecExperienceId;
                obj.RecExperienceName = item.RecExperienceName;
                return obj;
            }
            return null;
        }


        public bool Insert(RecExperienceObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecExperience_Insert(ob.RecExperienceName) > 0;
        }


        public bool Delete(byte RecExperienceId)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecExperience_Delete(RecExperienceId) > 0;
        }


        public bool Update(RecExperienceObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecExperience_Update(ob.RecExperienceId, ob.RecExperienceName) > 0;
        }

    }
}
