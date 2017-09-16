using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class TechCategoryDao
    {
        
        public List<TechCategoryObject> getElements()
        {
            WebIMicEntities db = new WebIMicEntities();
            List<TechCategoryObject> lstCategory = new List<TechCategoryObject>();
            foreach (var item in db.WEB_IMIC_SP_TechCategory_GetAll())
            {
                TechCategoryObject objTech = new TechCategoryObject();
                objTech.TechCategoryId = item.TechCategoryId;
                objTech.RankingOfSortingOnTop = (int)(byte)item.RankOfSortingOnTop;
                objTech.ModifiedTime = (DateTime)item.ModifiedTime;
                objTech.CategoryName = item.CategoryName;
                objTech.CategoryAvatar = item.CategoryAvatar;
                objTech.ModifiedBy = (Guid)item.ModifiedBy;
                objTech.TechCodeNumber = item.TechCodeNumber;
                objTech.isDeleted = false;
                lstCategory.Add(objTech);
            }
            return lstCategory;
        }
        public void addElement(TechCategoryObject objCat)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechCategory_update(objCat.TechCategoryId, (byte)objCat.RankingOfSortingOnTop, objCat.CategoryName, objCat.CategoryAvatar,
                objCat.ModifiedBy, objCat.ModifiedTime, false, false);
            db.SaveChanges();
        }
        public void updateElement(TechCategoryObject objCat)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechCategory_update(objCat.TechCategoryId, (byte)objCat.RankingOfSortingOnTop, objCat.CategoryName, objCat.CategoryAvatar,
                objCat.ModifiedBy, objCat.ModifiedTime, false, true);
            db.SaveChanges();
        }
        public TechCategoryObject getElementById(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechCategory_GetByID(id))
            {
                TechCategoryObject objTech = new TechCategoryObject();
                objTech.TechCategoryId = item.TechCategoryId;
                objTech.RankingOfSortingOnTop = (int)(byte)item.RankOfSortingOnTop;
                objTech.ModifiedTime = (DateTime)item.ModifiedTime;
                objTech.CategoryName = item.CategoryName;
                objTech.CategoryAvatar = item.CategoryAvatar;
                objTech.ModifiedBy = (Guid)item.ModifiedBy;
                objTech.isDeleted = false;
                return objTech;
            }
            return null;
        }
        public void deleteElement(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechCategory_Delete(id);
        }
    }
}
