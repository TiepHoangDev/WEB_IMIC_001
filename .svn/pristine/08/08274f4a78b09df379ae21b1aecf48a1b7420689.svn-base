using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoSubCategoryDao : BaseModel<VideoSubCategoryObject>
    {
        public List<VideoSubCategoryObject> getAll()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();

            var lisGet = m_objDb.WEB_IMIC_SP_VideoSubCategory_GetAll().ToList();

            List<VideoSubCategoryObject> lisRs = new List<VideoSubCategoryObject>();

            foreach (var item in lisGet)
            {
                VideoSubCategoryObject objSub = new VideoSubCategoryObject();
                objSub.VideoSubCategoryID = item.VideoSubCategoryId;
                objSub.VideoSubCategoryName = item.VideoSubCategoryName;
                objSub.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objSub.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objSub.TotalVideo = item.TotalVideo.GetValueOrDefault();
                objSub.IsDeleted = item.IsDeleted.GetValueOrDefault();
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.ModifiedBy.GetValueOrDefault();
                objAcc.Username = item.Username;
                objSub.Account = objAcc;

                lisRs.Add(objSub);
            }
            return lisRs;
        }

        public List<VideoSubCategoryObject> getByAccountID(Guid AccountID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();

            var lisGet = m_objDb.WEB_IMIC_SP_VideoSubCategory_GetByAccountID(AccountID).ToList();

            List<VideoSubCategoryObject> lisRs = new List<VideoSubCategoryObject>();

            foreach (var item in lisGet)
            {
                VideoSubCategoryObject objSub = new VideoSubCategoryObject();
                objSub.VideoSubCategoryID = item.VideoSubCategoryId;
                objSub.VideoSubCategoryName = item.VideoSubCategoryName;
                objSub.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objSub.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objSub.TotalVideo = item.TotalVideo.GetValueOrDefault();
                objSub.IsDeleted = item.IsDeleted.GetValueOrDefault();
                AccountObject objAcc = new AccountObject();
                objAcc.AccountId = item.ModifiedBy.GetValueOrDefault();
                objAcc.Username = item.Username;
                objSub.Account = objAcc;

                lisRs.Add(objSub);
            }

            return lisRs;
        }

        public VideoSubCategoryObject getByID(Guid SubCategoryId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();

            var lisGet = m_objDb.WEB_IMIC_SP_VideoSubCategory_GetByID(SubCategoryId);

            foreach (var item in lisGet)
            {
                VideoSubCategoryObject objSub = new VideoSubCategoryObject();
                objSub.VideoSubCategoryID = item.VideoSubCategoryId;
                objSub.VideoSubCategoryName = item.VideoSubCategoryName;
                objSub.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objSub.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objSub.TotalVideo = item.TotalVideo.GetValueOrDefault();
                objSub.IsDeleted = item.IsDeleted.GetValueOrDefault();

                return objSub;
            }

            return null;
        }

        public bool Insert(VideoSubCategoryObject objSubCategory)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoSubCategory_update(objSubCategory.VideoSubCategoryID, objSubCategory.VideoSubCategoryName,
                objSubCategory.ModifiedBy, objSubCategory.ModifiedTime, objSubCategory.TotalVideo, objSubCategory.IsDeleted, false);
            return true;
        }

        public bool Update(VideoSubCategoryObject objSubCategory)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoSubCategory_update(objSubCategory.VideoSubCategoryID, objSubCategory.VideoSubCategoryName,
                objSubCategory.ModifiedBy, objSubCategory.ModifiedTime, objSubCategory.TotalVideo, objSubCategory.IsDeleted, true);
            return true;
        }

        public bool Delete(Guid VideoSubCategoryId)
        {
            new WebIMicEntities().WEB_IMIC_SP_VideoSubCategory_Delete(VideoSubCategoryId);
            return true;
        }
    }
}
