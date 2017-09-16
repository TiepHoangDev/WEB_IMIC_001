using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class BoxBellowDao : BaseModel<BoxBelowObject>
    {
        /*
        * Nghiệp vụ về ô thông tin dưới mỗi khoá học
        * NgocNB - 10102016
        */

        //private static WebIMicEntities m_objDb = new WebIMicEntities();

        /*
         * Lấy all các ô thông tin
         * NgocNB - 10102016
        */
        public override List<BoxBelowObject> getAllElements()
        {
            List<BoxBelowObject> lisRs = new List<BoxBelowObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_BoxBelow_GetAll().ToList();
                
                foreach (var oBoxBellow in lisGet)
                {
                    lisRs.Add(new BoxBelowObject
                    {
                        BoxBelowId = oBoxBellow.BoxBelowId,
                        BoxDescription = oBoxBellow.BoxDescription,
                        BoxTitle = oBoxBellow.BoxTitle,
                        Boxlmage = oBoxBellow.Boxlmage,
                        BoxLinkTo = oBoxBellow.BoxLinkTo
                    });
                }
            }

            return lisRs;
        }
        /*
         * Lấy các BoxBelow dựa vào CourseId
         * MinhHA - 11102016
        */
        public List<BoxBelowObject> GetAllBoxBelowByCourseId(Guid courseId)
        {
            List<BoxBelowObject> lisBb = new List<BoxBelowObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_BoxBelow_getAllByCourseId(courseId);
                foreach (var item in lisTemp)
                {
                    BoxBelowObject objBb = new BoxBelowObject();

                    objBb.BoxBelowId = item.BoxBelowId;
                    objBb.BoxDescription = item.BoxDescription;
                    objBb.BoxLinkTo = item.BoxLinkTo;
                    objBb.Boxlmage = item.Boxlmage;
                    objBb.BoxTitle = item.BoxTitle;
                    objBb.IsDeleted = item.IsDeleted;
                    objBb.TrainingCategoryId = item.TrainingCategoryId;

                    lisBb.Add(objBb);
                }
                return lisBb;
            }
        }
        public BoxBelowObject GetBoxBelowByBBid(Guid BoxBelowId)
        {
            BoxBelowObject obj = new BoxBelowObject();
            using (var dbContext = new WebIMicEntities())
            {
                var item = dbContext.WEB_IMIC_SP_BoxBelow_GetById(BoxBelowId).FirstOrDefault();
                obj.BoxBelowId = item.BoxBelowId;
                obj.BoxDescription = item.BoxDescription;
                obj.BoxLinkTo = item.BoxLinkTo;
                obj.Boxlmage = item.Boxlmage;
                obj.BoxTitle = item.BoxTitle;
                obj.IsDeleted = item.IsDeleted;
                obj.TrainingCategoryId = item.TrainingCategoryId;
            }
            return obj;
        }

        public bool Insert(BoxBelowObject objBB)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_BoxBelow_Update(
                    Guid.NewGuid(),
                    null,
                    objBB.BoxTitle,
                    objBB.Boxlmage,
                    objBB.BoxDescription,
                    objBB.BoxLinkTo,
                    objBB.IsDeleted,
                    false);
            }
            return true;
        }
        public bool Update(BoxBelowObject objBB)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_BoxBelow_Update(
                    objBB.BoxBelowId,
                    null,
                    objBB.BoxTitle,
                    objBB.Boxlmage,
                    objBB.BoxDescription,
                    objBB.BoxLinkTo,
                    objBB.IsDeleted,
                    true);
            }
            return true;
        }
        public bool Delete(Guid id)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_BoxBelow_UpdateIsDeleted(
                    id,
                    true);
                db.WEB_IMIC_SP_BoxBelowDetail_DeleteByBoxBelowId(id);
            }
            return true;
        }

    }
}
