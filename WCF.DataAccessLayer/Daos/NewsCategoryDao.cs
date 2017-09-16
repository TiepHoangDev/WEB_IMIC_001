using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class NewsCategoryDao:BaseModel<NewsCategoryObject>
    {
        //private static WebIMicEntities m_objDb = new WebIMicEntities();

        public override List<NewsCategoryObject> getElementsById(Guid id)
        {
            List<NewsCategoryObject> lstobj = new List<NewsCategoryObject>();

            using (var dbContext = new WebIMicEntities())
            {
                foreach (var i in dbContext.WEB_IMIC_SP_NewsCategory_GetByID(id))
                {
                    NewsCategoryObject obj = new NewsCategoryObject();
                    obj.NewsCategoryId = i.NewsCategoryId;
                    obj.NewsCategoryName = i.NewsCategoryName;
                    obj.CategoryImage = i.CategoryImage;
                    obj.ModifiedBy = (Guid) i.ModifiedBy;
                    obj.ModifiedTime = "" + i.ModifiedTime;
                    obj.NCCode = i.NCCode;
                    lstobj.Add(obj);
                }
            }
            
            return lstobj;
        }


        /*
         * Lấy all danh mục tin
         * NgocNB - 12102016
         */
        public override List<NewsCategoryObject> getAllElements()
        {
            List<NewsCategoryObject> lisRs = new List<NewsCategoryObject>();

            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_NewsCategory_GetAll();

                foreach (var objCategory in lisGet)
                {
                    lisRs.Add(new NewsCategoryObject()
                    {
                        NewsCategoryId = objCategory.NewsCategoryId,
                        NewsCategoryName = objCategory.NewsCategoryName,
                        CategoryImage = objCategory.CategoryImage,
                        ModifiedBy = (Guid)objCategory.ModifiedBy,
                        ModifiedTime = "" + objCategory.ModifiedTime,
                        IsDeleted = objCategory.IsDeleted,
                        NCCode = objCategory.NCCode
                    });
                }
            }

            return lisRs;
        }
    }
}
