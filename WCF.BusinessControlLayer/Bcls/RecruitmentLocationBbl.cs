
using WCF.DataAccessLayer.Daos;
using WCF.BusinessObjectsLayer.EntityObjects;
using System;
using System.Collections.Generic;
namespace WCF.BusinessControlLayer.Bcls
{
    public class RecruitmentLocationBbl
    {

        public List<RecruitmentLocationObject> GetAll()
        {
            return new RecruitmentLocationDao().GetAll();
        }


        public RecruitmentLocationObject GetByRecLocationId(System.Int32 RecLocationId)
        {
            return new RecruitmentLocationDao().GetByRecLocationId(RecLocationId);
        }


        public bool Insert(RecruitmentLocationObject ob)
        {
            return new RecruitmentLocationDao().Insert(ob);
        }


        public bool Delete(System.Int32 RecLocationId)
        {
            return new RecruitmentLocationDao().Delete(RecLocationId);
        }


        public bool Update(RecruitmentLocationObject ob)
        {
            return new RecruitmentLocationDao().Update(ob);
        }

    }
}
