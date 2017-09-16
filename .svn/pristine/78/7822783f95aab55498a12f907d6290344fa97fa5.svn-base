using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class TrainingCategoryDao :BaseModel<TrainingCategoryObject>
    {

        /*
         * Xử lý chuyên mục đào tạo
         * NgocNB - 05102016
         */

        private static WebIMicEntities m_objDb = new WebIMicEntities();

        /*
         * Lấy toàn bộ chuyên mục các khoá học
         * NgocNB - 05102016
         */
        public override List<TrainingCategoryObject> getAllElements()
        {
            var lisGet = m_objDb.WEB_IMIC_SP_TrainingCategory_GetAll().ToList();

            List<TrainingCategoryObject> lisRs = new List<TrainingCategoryObject>();

            foreach (var oCat in lisGet)
            {
                lisRs.Add(new TrainingCategoryObject
                {
                    TrainingCategoryId = oCat.TrainingCategoryId,
                    TrainingCategoryName = oCat.TrainingCategoryName,
                    TotalOfCourse = oCat.TotalOfCourse,
                    ModifiedBy = oCat.ModifiedBy,
                    ModifiedTime = oCat.ModifiedTime + "",
                    TCCodeNumber = oCat.TCCodeNumber
                });
            }

            return lisRs;
        }
    }
}
