using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class CourseTechnologyDao : BaseModel<CourseTechnologyObject>
    {
        /*
        * DAO công nghệ sử dụng trong khoá học
        * NgocNB - 11102016
        */

        //private static WebIMicEntities m_objDb = new WebIMicEntities();

        /*
         * Lấy tất cả
         * NgocNB - 11102016
        */
        public override List<CourseTechnologyObject> getAllElements()
        {
            List<CourseTechnologyObject> lisRs = new List<CourseTechnologyObject>();

            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_CourseTechnology_GetAll().ToList();

                foreach (var o in lisGet)
                {
                    lisRs.Add(new CourseTechnologyObject()
                    {
                        CourseTechnologyId = o.CourseTechnologyId,
                        CourseTechImage = o.CourseTechImage,
                        CourseTechnologyName = o.CourseTechnologyName,
                        LinkTo = o.LinkTo,
                        TrainingCategoryId = o.TrainingCategoryId
                    });
                }
            }
            
            return lisRs;
        }

        public List<CourseTechnologyObject> GetAllTechnologyByCourseId(Guid courseId)
        {
            List<CourseTechnologyObject> lisCT = new List<CourseTechnologyObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_CourseTechnology_getAllByCourseId(courseId).ToList();
                foreach (var item in lisTemp)
                {
                    CourseTechnologyObject objCT = new CourseTechnologyObject();

                    objCT.CourseTechnologyId = item.CourseTechnologyId;
                    objCT.CourseTechnologyName = item.CourseTechnologyName;
                    objCT.CourseTechImage = item.CourseTechImage;
                    objCT.LinkTo = item.LinkTo;
                    objCT.TrainingCategoryId = item.TrainingCategoryId;
                    objCT.IsDeleted = item.IsDeleted;
                    lisCT.Add(objCT);
                }
            }
            return lisCT;
        }

        public bool Insert(CourseTechnologyObject objCT)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_CourseTechnology_Update(
                    Guid.NewGuid(),
                    null,
                    objCT.CourseTechnologyName,
                    objCT.CourseTechImage,
                    objCT.LinkTo,
                    false,
                    false);
            }
            return true;
        }
    }
}
