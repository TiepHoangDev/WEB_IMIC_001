using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class JobObjectDao : BaseModel<JobObject>
    {
        public override List<JobObject> getAllElements()
        {
            List<JobObject> lisRs = new List<JobObject>();
            using (var db = new WebIMicEntities())
            {
                var lisGet = db.WEB_IMIC_SP_JobObject_GetAll();

                foreach (var objGet in lisGet)
                {
                    lisRs.Add(new JobObject()
                    {
                        JobObjectId = objGet.JobObjectId,
                        ApprovedBy = objGet.ApprovedBy,
                        IsApproved = objGet.IsApproved,
                        JobObjectName = objGet.JobObjectName,
                        ModifiedBy = objGet.ModifiedBy,
                        ModifiedTime = objGet.ModifiedTime
                    });
                }
            }
            return lisRs;
        }

        public JobObject GetById(Guid id)
        {
            return this.getAllElements().Where(q => q.JobObjectId == id).FirstOrDefault();
        }
    }
}
