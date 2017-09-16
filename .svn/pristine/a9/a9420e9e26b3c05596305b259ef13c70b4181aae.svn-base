using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoCategoryDao : BaseModel<VideoCategoryObject>
    {
        public List<VideoCategoryObject> getForAdmin()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoCategory_GetForAdmin();

            List<VideoCategoryObject> lisRs = new List<VideoCategoryObject>();

            foreach (var item in lisGet)
            {
                VideoCategoryObject objCategory = new VideoCategoryObject();
                objCategory.VideoCategoryId = item.VideoCategoryId;
                objCategory.VideoCategoryName = item.VideoCategoryName + "";
                objCategory.VideoCategoryIcon = item.VideoCategoryIcon + "";
                objCategory.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objCategory.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objCategory.IsDeleted = item.IsDeleted.GetValueOrDefault();
                objCategory.VCCodeNumber = item.VCCodeNumber;
                AccountObject objAcc = new AccountObject();
                objAcc.Username = item.Username;
                objCategory.Account = objAcc;
                lisRs.Add(objCategory);
            }
            return lisRs;
        }

        public List<VideoCategoryObject> getForView()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoCategory_GetAll();

            List<VideoCategoryObject> lisRs = new List<VideoCategoryObject>();

            foreach (var item in lisGet)
            {
                VideoCategoryObject objCategory = new VideoCategoryObject();
                objCategory.VideoCategoryId = item.VideoCategoryId;
                objCategory.VideoCategoryName = item.VideoCategoryName + "";
                objCategory.VideoCategoryIcon = item.VideoCategoryIcon + "";
                objCategory.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objCategory.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objCategory.IsDeleted = item.IsDeleted.GetValueOrDefault();
                objCategory.VCCodeNumber = item.VCCodeNumber;
                AccountObject objAcc = new AccountObject();
                objAcc.Username = item.Username;
                objCategory.Account = objAcc;
                lisRs.Add(objCategory);
            }
            return lisRs;
        }

        public VideoCategoryObject getElementsByVCCodeNumber(int VCCodeNumber)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoCategory_GetByVCCodeNumber(VCCodeNumber).ToList();

            foreach (var item in lisGet)
            {
                VideoCategoryObject objCategory = new VideoCategoryObject();
                objCategory.VideoCategoryId = item.VideoCategoryId;
                objCategory.VideoCategoryName = item.VideoCategoryName + "";
                objCategory.VideoCategoryIcon = item.VideoCategoryIcon + "";
                objCategory.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objCategory.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objCategory.IsDeleted = item.IsDeleted.GetValueOrDefault();
                objCategory.VCCodeNumber = item.VCCodeNumber;
                AccountObject objAcc = new AccountObject();
                objAcc.Username = item.Username;
                objCategory.Account = objAcc;
                return objCategory;
            }
            return null;
        }

        public VideoCategoryObject getElementsById(Guid VideoCategoryId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoCategory_GetById(VideoCategoryId).ToList();

            foreach (var item in lisGet)
            {
                VideoCategoryObject objCategory = new VideoCategoryObject();
                objCategory.VideoCategoryId = item.VideoCategoryId;
                objCategory.VideoCategoryName = item.VideoCategoryName + "";
                objCategory.VideoCategoryIcon = item.VideoCategoryIcon + "";
                objCategory.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objCategory.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objCategory.IsDeleted = item.IsDeleted.GetValueOrDefault();
                objCategory.VCCodeNumber = item.VCCodeNumber;
                AccountObject objAcc = new AccountObject();
                objAcc.Username = item.Username;
                objCategory.Account = objAcc;
                return objCategory;
            }
            return null;
        }

        public List<VideoCategoryObject> getForDislay()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoCategory_GetForDisplay().ToList();

            List<VideoCategoryObject> lisRs = new List<VideoCategoryObject>();

            foreach (var item in lisGet)
            {
                VideoCategoryObject objCategory = new VideoCategoryObject();
                objCategory.VideoCategoryId = item.VideoCategoryId;
                objCategory.VideoCategoryName = item.VideoCategoryName + "";
                objCategory.VideoCategoryIcon = item.VideoCategoryIcon + "";
                objCategory.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objCategory.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objCategory.IsDeleted = item.IsDeleted.GetValueOrDefault();
                objCategory.VCCodeNumber = item.VCCodeNumber;
                AccountObject objAcc = new AccountObject();
                objAcc.Username = item.Username;
                objCategory.Account = objAcc;
                objCategory.TotalVideo = item.TotalVideo.GetValueOrDefault();
                lisRs.Add(objCategory);
            }
            return lisRs;
        }

        //Paging
        public List<VideoCategoryObject> getForDislay_Paging(int start, int length)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            var lisGet = m_objDb.WEB_IMIC_SP_VideoCategory_GetForDisplay_PAGING(start, length).ToList();

            List<VideoCategoryObject> lisRs = new List<VideoCategoryObject>();

            foreach (var item in lisGet)
            {
                VideoCategoryObject objCategory = new VideoCategoryObject();
                objCategory.VideoCategoryId = item.VideoCategoryId;
                objCategory.VideoCategoryName = item.VideoCategoryName + "";
                objCategory.VideoCategoryIcon = item.VideoCategoryIcon + "";
                objCategory.VCCodeNumber = item.VCCodeNumber;
                AccountObject objAcc = new AccountObject();
                objAcc.Username = item.Username;
                objCategory.Account = objAcc;
                lisRs.Add(objCategory);
            }
            return lisRs;
        }

        public bool Insert(VideoCategoryObject objCategory)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCategory_update(objCategory.VideoCategoryId, objCategory.VideoCategoryName, objCategory.VideoCategoryIcon,
                objCategory.ModifiedBy, objCategory.ModifiedTime, objCategory.IsDeleted, false);
            return true;
        }

        public bool Update(VideoCategoryObject objCategory)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCategory_update(objCategory.VideoCategoryId, objCategory.VideoCategoryName, objCategory.VideoCategoryIcon,
                objCategory.ModifiedBy, objCategory.ModifiedTime, objCategory.IsDeleted, true);
            return true;
        }

        public bool Delete(Guid VideoCategoryId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCategory_delete(VideoCategoryId);
            return true;
        }
    }
}
