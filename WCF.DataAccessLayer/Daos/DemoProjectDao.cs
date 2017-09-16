using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class DemoProjectDao : BaseModel<DemoProjectObject>
    {
        /*
         * DAO demo project
         * NgocNB - 10102016
         */

        //private static WebIMicEntities m_objDb = new WebIMicEntities();

        /*
         * Lấy all demoproject
         * NgocNB - 10102016
        */
        public override List<DemoProjectObject> getAllElements()
        {
            List<DemoProjectObject> lisRs = new List<DemoProjectObject>();

            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_DemoProject_GetAll().ToList();

                foreach (var o in lisGet)
                {
                    lisRs.Add(new DemoProjectObject
                    {
                        DemoProjectId = o.DemoProjectId,
                        DemoLink = o.DemoLink,
                        DemoType = o.DemoType,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedTime = o.ModifiedTime,
                        ProjectName = o.ProjectName,
                        TabType = o.TabType,
                        Thumbnail = o.Thumbnail,
                        TrainingCategoryId = o.TrainingCategoryId
                    });
                }
            }
            return lisRs;
        }

        public List<DemoProjectObject> GetAllDemoProjectByCourseId(Guid courseId)
        {
            List<DemoProjectObject> lisDP = new List<DemoProjectObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_DemoProject_getAllByCourseId(courseId).ToList();
                foreach (var item in lisTemp)
                {
                    DemoProjectObject objDP = new DemoProjectObject();
 
                    objDP.DemoProjectId = item.DemoProjectId;
                    objDP.DemoLink = item.DemoLink;
                    objDP.DemoType = item.DemoType;
                    objDP.TabType = item.TabType;
                    objDP.ModifiedBy = item.ModifiedBy;
                    objDP.IsDeleted = item.IsDeleted;
                    objDP.ModifiedTime = item.ModifiedTime;
                    objDP.ProjectName = item.ProjectName;
                    objDP.Thumbnail = item.Thumbnail;
                    objDP.TrainingCategoryId = item.TrainingCategoryId;

                    lisDP.Add(objDP);
                }
            }
            return lisDP;
        }

        public bool Insert(DemoProjectObject objDP)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_DemoProject_update(
                    Guid.NewGuid(),
                    null,
                    objDP.ProjectName,
                    objDP.Thumbnail,
                    objDP.DemoLink,
                    objDP.TabType,
                    objDP.DemoType,
                    objDP.ModifiedBy,
                    DateTime.Now,
                    false);
            }
            return true;
        }
    }
}
