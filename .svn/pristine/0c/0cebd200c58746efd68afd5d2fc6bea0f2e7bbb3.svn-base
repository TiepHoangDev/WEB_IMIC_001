using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class LessonCategoryDAO
    {
        public List<LessonCategoryObject> getElements()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            List<LessonCategoryObject> lisRs = new List<LessonCategoryObject>();
            foreach (var item in m_objDb.WEB_IMIC_SP_LessonCategory_GETALL())
            {
                LessonCategoryObject objCategory = new LessonCategoryObject();
                objCategory.LessonCategoryId = item.LessonCategoryId;
                objCategory.CategoryCode = (long)item.CategoryCode;
                objCategory.CategoryName = item.CategoryName;
                objCategory.CategoryImage = item.CategoryImage;
                objCategory.Rank = (int)item.Rank;
                objCategory.ModifiedBy = (Guid)item.ModifiedBy;
                objCategory.ModifiedTime = (DateTime)item.ModifiedTime;
                objCategory.IsDeleted = (bool)item.IsDeleted;
                objCategory.CategorySumary = item.CategorySumary;
                AccountObject objAccount = new AccountObject();
                objAccount.AccountId = (Guid)item.ModifiedBy;
                objAccount.Username = item.Username;
                objAccount.ImageAvatar = item.ImageAvatar;
                objCategory.objAccount = objAccount;
                lisRs.Add(objCategory);
            }
            return lisRs;
        }

        public LessonCategoryObject getElementById(Guid LessonCategoryId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            foreach (var item in m_objDb.WEB_IMIC_SP_LessonCategory_GETBYID(LessonCategoryId))
            {
                LessonCategoryObject objCategory = new LessonCategoryObject();
                objCategory.LessonCategoryId = item.LessonCategoryId;
                objCategory.CategoryCode = (long)item.CategoryCode;
                objCategory.CategoryName = item.CategoryName;
                objCategory.CategoryImage = item.CategoryImage;
                objCategory.Rank = (int)item.Rank;
                objCategory.CategorySumary = item.CategorySumary;
                objCategory.ModifiedBy = (Guid)item.ModifiedBy;
                objCategory.ModifiedTime = (DateTime)item.ModifiedTime;
                objCategory.IsDeleted = (bool)item.IsDeleted;
                return objCategory;
            }
            return null;
        }

        public bool addElement(LessonCategoryObject objCategory)
        {
            //WebIMicEntities m_objDb = new WebIMicEntities();
            //m_objDb.WEB_IMIC_SP_LessonCategory_INSERT(objCategory.LessonCategoryId, objCategory.CategoryName,
            //    objCategory.CategoryImage, objCategory.Rank, 
            //    objCategory.ModifiedBy, objCategory.ModifiedTime, objCategory.IsDeleted,objCategory.CategorySumary);
            //return true;
            throw new Exception("Hàm này có lỗi, cần kiểm tra lại. Hoàng Phạm Tiệp.");
        }

        public bool updateElement(LessonCategoryObject objCategory)
        {
            //WebIMicEntities m_objDb = new WebIMicEntities();
            //m_objDb.WEB_IMIC_SP_LessonCategory_UPDATE(objCategory.LessonCategoryId, objCategory.CategoryName,
            //    objCategory.CategoryImage, objCategory.Rank, 
            //    objCategory.ModifiedBy, objCategory.ModifiedTime, objCategory.IsDeleted,objCategory.CategorySumary);
            //return true;
            throw new Exception("Hàm này có lỗi, cần kiểm tra lại. Hoàng Phạm Tiệp.");
        }

        public void deleteElement(Guid LessonCategoryId)
        {
            new WebIMicEntities().WEB_IMIC_SP_LessonCategory_DELETE(LessonCategoryId);
        }
    }
}
