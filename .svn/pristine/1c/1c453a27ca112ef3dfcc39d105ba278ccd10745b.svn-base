using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class LessonDetailDAO
    {
        public List<LessonDetailObject> getElements()
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            List<LessonDetailObject> lisRs = new List<LessonDetailObject>();
            foreach (var item in m_objDb.WEB_IMIC_SP_LessonDetail_GETALL())
            {
                LessonDetailObject objLessonDetail = new LessonDetailObject();
                objLessonDetail.LessonDetailId = item.LessonDetailId;
                objLessonDetail.LessonId = (Guid)item.LessonId;
                objLessonDetail.DetailCode = (long)item.DetailCode;
                objLessonDetail.DetailName = item.DetailName;
                objLessonDetail.DetailTitle = item.DetailTitle;
                objLessonDetail.DetailSummary = item.DetailSummary;
                objLessonDetail.DetailContent = item.DetailContent;
                objLessonDetail.TotalOfLike = (long)item.TotalOfLike;
                objLessonDetail.TotalOfComment = (long)item.TotalOfComment;
                objLessonDetail.TotalOfShare = (long)item.TotalOfShare;
                objLessonDetail.TotalOfView = (long)item.TotalOfView;
                objLessonDetail.Rank = (int)item.Rank;
                objLessonDetail.ModifiedBy = (Guid)item.ModifiedBy;
                objLessonDetail.ModifiedTime = (DateTime)item.ModifiedTime;
                objLessonDetail.IsApproved = (bool)item.IsApproved;
                objLessonDetail.ApprovedBy = (Guid)item.ApprovedBy;
                objLessonDetail.IsDeleted = (bool)item.IsDeleted;
                AccountObject objAccount = new AccountObject();
                objAccount.AccountId = (Guid)item.ModifiedBy;
                objAccount.Username = item.Username;
                objLessonDetail.objAccount = objAccount;
                lisRs.Add(objLessonDetail);
            }
            return lisRs;
        }

        public List<LessonDetailObject> GetByPrev_Next(long code)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            List<LessonDetailObject> lisRs = new List<LessonDetailObject>();
            foreach (var item in m_objDb.WEB_IMIC_SP_LessonDetail_GETBYCODE_PrevNext(code))
            {
                LessonDetailObject objDetail = new LessonDetailObject();
                objDetail.LessonDetailId = item.LessonDetailId;
                objDetail.LessonId = (Guid)item.LessonId;
                objDetail.DetailCode = item.DetailCode;
                objDetail.DetailName = item.DetailName;
                objDetail.TotalOfView = (int)item.TotalOfView;
                objDetail.DetailTitle = item.DetailTitle;
                objDetail.DetailSummary = item.DetailSummary;
                objDetail.DetailContent = item.DetailContent;
                objDetail.TotalOfLike = (int)item.TotalOfLike;
                objDetail.Rank = (byte) item.Rank;
                objDetail.ModifiedTime = (DateTime)item.ModifiedTime;
                objDetail.TotalOfComment = (long)item.TotalOfComment;
                objDetail.objAccount = new AccountObject()
                {
                    AccountId = (Guid)item.ModifiedBy,
                    FullName = item.FullName,
                    Username = item.Username,
                    ImageAvatar = item.ImageAvatar
                };
                objDetail.objLesson = new LessonObject()
                {

                    LessonName = item.LessonName,
                    LessonId = (Guid)item.LessonId,
                    ImageFlag = (bool)item.ImageFlag,
                    SeoImage = item.SeoImage,
                    LessonCategoryId = item.LessonCategoryId

                };
                objDetail.objLesson.objCategory = new LessonCategoryObject()
                {
                    CategoryName = item.CategoryName,
                    CategoryImage = item.CategoryImage
                };
              
                lisRs.Add(objDetail);
            }
            return lisRs;
        }
        public List<LessonDetailObject> getElementsByLessonId(Guid LessonId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            List<LessonDetailObject> lisRs = new List<LessonDetailObject>();
            foreach (var item in m_objDb.WEB_IMIC_SP_LessonDetail_GETBYLESSONID(LessonId))
            {
                LessonDetailObject objLessonDetail = new LessonDetailObject();
                objLessonDetail.LessonDetailId = item.LessonDetailId;
                objLessonDetail.LessonId = (Guid)item.LessonId;
                objLessonDetail.DetailCode = (long)item.DetailCode;
                objLessonDetail.DetailName = item.DetailName;
                objLessonDetail.DetailTitle = item.DetailTitle;
                objLessonDetail.DetailSummary = item.DetailSummary;
                objLessonDetail.DetailContent = item.DetailContent;
                objLessonDetail.TotalOfLike = (long)item.TotalOfLike;
                objLessonDetail.TotalOfComment = (long)item.TotalOfComment;
                objLessonDetail.TotalOfShare = (long)item.TotalOfShare;
                objLessonDetail.TotalOfView = (long)item.TotalOfView;
                objLessonDetail.Rank = (int)item.Rank;
                objLessonDetail.ModifiedBy = (Guid)item.ModifiedBy;
                objLessonDetail.ModifiedTime = (DateTime)item.ModifiedTime;
                objLessonDetail.IsApproved = (bool)item.IsApproved;
                objLessonDetail.ApprovedBy = (Guid)item.ApprovedBy;
                objLessonDetail.IsDeleted = (bool)item.IsDeleted;
                AccountObject objAccount = new AccountObject();
                objAccount.AccountId = (Guid)item.ModifiedBy;
                objAccount.Username = item.Username;
                objLessonDetail.objAccount = objAccount;
                lisRs.Add(objLessonDetail);
            }
            return lisRs;
        }

        public List<LessonDetailObject> getElementsByLessonId_PAGING(Guid? LessonId, int pageIndex, int pageSize)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            List<LessonDetailObject> lisRs = new List<LessonDetailObject>();
            foreach (var item in m_objDb.WEB_IMIC_SP_LessonDetail_GETBYLESSON_PAGING_TRUNG(LessonId, pageIndex, pageSize))
            {
                LessonDetailObject objLessonDetail = new LessonDetailObject();
                objLessonDetail.LessonDetailId = item.LessonDetailId;
                objLessonDetail.LessonId = (Guid)item.LessonId;
                objLessonDetail.DetailCode = (long)item.DetailCode;
                objLessonDetail.DetailName = item.DetailName;
                objLessonDetail.DetailTitle = item.DetailTitle;
                objLessonDetail.TotalOfLike = (long)item.TotalOfLike;
                objLessonDetail.TotalOfComment = (long)item.TotalOfComment;
                objLessonDetail.TotalOfView = (long)item.TotalOfView;
                objLessonDetail.ModifiedTime = (DateTime)item.ModifiedTime;
                lisRs.Add(objLessonDetail);
            }
            return lisRs;
        }

        public LessonDetailObject getByCatIdAndRank (Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            LessonDetailObject obj = new LessonDetailObject();
            foreach (var item in db.WEB_IMIC_SP_LessonDetailLessonAndRank(id))
            {
                obj.LessonDetailId = item.LessonDetailId;
                obj.DetailCode = item.DetailCode;
                obj.DetailTitle = item.DetailTitle;
               
            }

            return obj;
        }

        public LessonDetailObject getElementById(Guid LessonDetailId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            foreach (var item in m_objDb.WEB_IMIC_SP_LessonDetail_GETBYID(LessonDetailId))
            {
                LessonDetailObject objLessonDetail = new LessonDetailObject();
                objLessonDetail.LessonDetailId = item.LessonDetailId;
                objLessonDetail.LessonId = (Guid)item.LessonId;
                objLessonDetail.DetailCode = (long)item.DetailCode;
                objLessonDetail.DetailName = item.DetailName;
                objLessonDetail.DetailTitle = item.DetailTitle;
                objLessonDetail.DetailSummary = item.DetailSummary;
                objLessonDetail.DetailContent = item.DetailContent;
                objLessonDetail.TotalOfLike = (long)item.TotalOfLike;
                objLessonDetail.TotalOfComment = (long)item.TotalOfComment;
                objLessonDetail.TotalOfShare = (long)item.TotalOfShare;
                objLessonDetail.TotalOfView = (long)item.TotalOfView;
                objLessonDetail.Rank = (int)item.Rank;
                objLessonDetail.ModifiedBy = (Guid)item.ModifiedBy;
                objLessonDetail.ModifiedTime = (DateTime)item.ModifiedTime;
                objLessonDetail.IsApproved = (bool)item.IsApproved;
                objLessonDetail.ApprovedBy = (Guid)item.ApprovedBy;
                objLessonDetail.IsDeleted = (bool)item.IsDeleted;
                return objLessonDetail;
            }
            return null;
        }

        public int getCount(Guid? LessonId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            int value = (int)m_objDb.WEB_IMIC_SP_LessonDetail_GETCOUNT(LessonId).First();
            return value;
        }

        public bool addElement(LessonDetailObject objLessonDetail)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_LessonDetail_INSERT(objLessonDetail.LessonDetailId, objLessonDetail.LessonId,
                objLessonDetail.DetailName, objLessonDetail.DetailTitle, objLessonDetail.DetailSummary, objLessonDetail.DetailContent,
                objLessonDetail.TotalOfLike, objLessonDetail.TotalOfComment, objLessonDetail.TotalOfShare, objLessonDetail.TotalOfView,
                (byte)objLessonDetail.Rank, objLessonDetail.ModifiedBy, objLessonDetail.ModifiedTime, objLessonDetail.IsApproved,
                objLessonDetail.ApprovedBy, objLessonDetail.IsDeleted);
            return true;
        }

        public bool updateElement(LessonDetailObject objLessonDetail)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_LessonDetail_UPDATE(objLessonDetail.LessonDetailId, objLessonDetail.LessonId,
                objLessonDetail.DetailName, objLessonDetail.DetailTitle, objLessonDetail.DetailSummary, objLessonDetail.DetailContent,
                objLessonDetail.TotalOfLike, objLessonDetail.TotalOfComment, objLessonDetail.TotalOfShare, objLessonDetail.TotalOfView,
                (byte)objLessonDetail.Rank, objLessonDetail.ModifiedBy, objLessonDetail.ModifiedTime, objLessonDetail.IsApproved,
                objLessonDetail.ApprovedBy, objLessonDetail.IsDeleted);
            return true;
        }

        public void deleteElement(Guid LessonDetailId)
        {
            new WebIMicEntities().WEB_IMIC_SP_LessonDetail_DELETE(LessonDetailId);
        }
    }
}
