
using System;
using System.Collections.Generic;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class RecDipDao
    {

        public List<RecDipObject> GetAll()
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_RecDip_GetAll();
            List<RecDipObject> lst = new List<RecDipObject>();
            foreach (var item in list)
            {
                var obj = new RecDipObject();

                obj.RecDip = item.RecDip;
                obj.RecDipId = item.RecDipId;
                lst.Add(obj);
            }
            return lst;
        }


        public RecDipObject GetByRecDipId(byte RecDipId)
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_RecDip_GetByRecDipId(RecDipId);
            foreach (var item in list)
            {
                var obj = new RecDipObject();

                obj.RecDip = item.RecDip;
                obj.RecDipId = item.RecDipId;
                return obj;
            }
            return null;
        }


        public bool Insert(RecDipObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecDip_Insert(ob.RecDip) > 0;
        }


        public bool Delete(byte RecDipId)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecDip_Delete(RecDipId) > 0;
        }


        public bool Update(RecDipObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecDip_Update(ob.RecDip, ob.RecDipId) > 0;
        }

    }
}
