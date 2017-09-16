using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class LessonDao_Alt
    {
        public List<LessonCategoryObject> getAllCategory()
        {
            return new LessonCategoryDAO().getElements();
        }
        public List<LessonObject> getLessonByCat(Guid catid)
        {
            List<LessonObject> lstLesson = new List<LessonObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_Lesson_GETBYCATEGORY_CHIEN(catid))
            {
                LessonObject objLesson = new LessonObject();
                objLesson.LessonId = item.LessonId;
                objLesson.LessonCategoryId = (Guid)item.LessonCategoryId;
                objLesson.LessonCode = item.LessonCode;
                objLesson.LessonName = item.LessonName;
                objLesson.LessonSumary = item.LessonSumary;
                objLesson.objDetail = new LessonDetailDAO().getByCatIdAndRank(item.LessonId);
                objLesson.objAccount = new AccountDao().getAccountByID(item.ModifiedBy);
                objLesson.TotalOfView = (int)item.TotalOfView;
                objLesson.ModifiedTime = (DateTime) item.ModifiedTime;
                objLesson.SeoImage = item.SeoImage;
                objLesson.ImageFlag = (bool)item.ImageFlag;
                lstLesson.Add(objLesson);
            }
            return lstLesson;
        }
        public List<LessonObject> getElementsByCategory(Guid LessonCategoryId)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            List<LessonObject> lisRs = new List<LessonObject>();
            foreach (var item in m_objDb.WEB_IMIC_SP_LessonByCategory(LessonCategoryId))
            {
                LessonObject objLesson = new LessonObject();
                objLesson.LessonId = item.LessonId;
                objLesson.LessonCode = (long)item.LessonCode;
                objLesson.LessonName = item.LessonName;
                objLesson.LessonSumary = item.LessonSumary;
                objLesson.TotalOfView = (long)item.TotalOfView;
                objLesson.SeoImage = item.SeoImage;
                objLesson.ImageFlag = (bool)item.ImageFlag;
                lisRs.Add(objLesson);
            }
            return lisRs;
        }
        public List<LessonDetailObject> getPopular()
        {
            List<LessonDetailObject> lstDetail = new List<LessonDetailObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_LessonDetail_GETPOPULAR())
            {
                LessonDetailObject objDetail = new LessonDetailObject();
                objDetail.LessonDetailId = item.LessonDetailId;
                objDetail.LessonId = (Guid)item.LessonId;
                objDetail.DetailCode = item.DetailCode;
                objDetail.DetailName = item.DetailName;
                objDetail.DetailTitle = item.DetailTitle;
                objDetail.TotalOfView = (int)item.TotalOfView;
                lstDetail.Add(objDetail);
            }
            return lstDetail;
        }
        public List<LessonObject> getAllLesson_Paging(int start, int length)
        {

            List<LessonObject> lstLesson = new List<LessonObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_Lesson_GETALL_PAGING(start,length))
            {
                LessonObject objLesson = new LessonObject();
                objLesson.LessonId = item.LessonId;
                objLesson.LessonCode = item.LessonCode;
                objLesson.LessonName = item.LessonName;
             
                objLesson.TotalOfView = (int)item.TotalOfView;
                objLesson.TotalOfLike = (int)item.TotalOfLike;
                objLesson.ModifiedTime = (DateTime)item.ModifiedTime;
                
                lstLesson.Add(objLesson);
            }
            return lstLesson;
        }
        public List<LessonDetailObject> getLessonDetailByLesson(Guid lessonid)
        {
            List<LessonDetailObject> lstDetail = new List<LessonDetailObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_LessonDetail_GETBYLESSON_CHIEN(lessonid))
            {
                LessonDetailObject objDetail = new LessonDetailObject();
                objDetail.LessonDetailId = item.LessonDetailId;
                objDetail.LessonId = (Guid)item.LessonId;
                objDetail.DetailCode = item.DetailCode;
                objDetail.DetailName = item.DetailName;
                objDetail.TotalOfView = (int)item.TotalOfView;
                objDetail.DetailTitle = item.DetailTitle;
                
                lstDetail.Add(objDetail);
            }
            return lstDetail;
        }
        public List<LessonDetailObject> getLessonDetailByLesson_PAGING(Guid lessonid, int start, int length)
        {
            List<LessonDetailObject> lstDetail = new List<LessonDetailObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_LessonDetail_GETBYLESSON_PAGING(lessonid,start,length))
            {
                LessonDetailObject objDetail = new LessonDetailObject();
                objDetail.LessonDetailId = item.LessonDetailId;
                objDetail.LessonId = (Guid)item.LessonId;
                objDetail.DetailCode = item.DetailCode;
                objDetail.DetailName = item.DetailName;
                objDetail.TotalOfView = (int)item.TotalOfView;
                objDetail.ModifiedTime = (DateTime)item.ModifiedTime;
                objDetail.DetailTitle = item.DetailTitle;
                objDetail.Rank = (int)item.Rank;
                lstDetail.Add(objDetail);
            }
            return lstDetail;
        }
        public LessonDetailObject getByRank(byte rank)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_LessonDetail_GETBYRank(rank))
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
                objDetail.ModifiedTime = (DateTime)item.ModifiedTime;
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
                    LessonId = (Guid)item.LessonId
                };
                objDetail.objLesson.objCategory = new LessonCategoryObject()
                {
                    CategoryName = item.CategoryName,
                    CategoryImage = item.CategoryImage
                };
                return objDetail;
            }
            return null;
        }
        public LessonDetailObject getByCode(long code)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_LessonDetail_GETBYCODE(code))
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
                objDetail.ModifiedTime = (DateTime) item.ModifiedTime;
                objDetail.TotalOfComment = (long)item.TotalOfComment;
                objDetail.objAccount = new AccountObject(){
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
                    SeoImage = item.SeoImage,LessonCategoryId = item.LessonCategoryId
                   
                };
                objDetail.objLesson.objCategory = new LessonCategoryObject()
                {
                    CategoryName = item.CategoryName,
                    CategoryImage = item.CategoryImage
                };
                return objDetail;
            }
            return null;
        }

        public List<LessonDetailObject> SearchByTitle(string query, int start, int lenght)
        {
            List<LessonDetailObject> lstDetail = new List<LessonDetailObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_LessonDetail_SearchbyTitle_PAGING(query, start, lenght))
            {
                LessonDetailObject objDetail = new LessonDetailObject();
                objDetail.LessonDetailId = item.LessonDetailId;
                objDetail.LessonId = (Guid)item.LessonId;
                objDetail.DetailCode = item.DetailCode;
                objDetail.DetailName = item.DetailName;
                objDetail.DetailSummary = item.DetailSummary;
                objDetail.TotalOfView = (int)item.TotalOfView;
                objDetail.TotalOfLike = (int)item.TotalOfLike;
                objDetail.TotalOfComment = (int)item.TotalOfComment;
                objDetail.ModifiedTime = (DateTime)item.ModifiedTime;
                objDetail.DetailTitle = item.DetailTitle;
                //objDetail.Rank = (int)item.Rank;
                objDetail.objAccount = new AccountDao().getAccountByID(item.ModifiedBy);
                lstDetail.Add(objDetail);
            }
            return lstDetail;
        }

        public List<LessonDetailObject> SearchByTag(string query, int start, int lenght)
        {
            List<LessonDetailObject> lstDetail = new List<LessonDetailObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_LessonDetail_SearchbyTag_PAGING(query, start, lenght))
            {
                LessonDetailObject objDetail = new LessonDetailObject();
                objDetail.LessonDetailId = item.LessonDetailId;
                objDetail.LessonId = (Guid)item.LessonId;
                objDetail.DetailCode = item.DetailCode;
                objDetail.DetailName = item.DetailName;
                objDetail.DetailSummary = item.DetailSummary;
                objDetail.TotalOfView = (int)item.TotalOfView;
                objDetail.TotalOfLike = (int)item.TotalOfLike;
                objDetail.TotalOfComment = (int)item.TotalOfComment;
                objDetail.ModifiedTime = (DateTime)item.ModifiedTime;
                objDetail.DetailTitle = item.DetailTitle;
                objDetail.objAccount = new AccountDao().getAccountByID(item.ModifiedBy);
                //objDetail.Rank = (int)item.Rank;
                lstDetail.Add(objDetail);
            }
            return lstDetail;
        }
        public int[] getCount()
        {
            WebIMicEntities db = new WebIMicEntities();
            int[] s = new int[3];
            int i = 0;
            foreach (var item in db.WEB_IMIC_SP_Lesson_GETCOUNT())
            {
                s[i] = item.Value;
                i++;
            }
            return s;
        }

        public int GetCountTag(string tag)
        {
            WebIMicEntities db = new WebIMicEntities();
           int value =(int) db.WEB_IMIC_SP_LessonDetailByTag(tag).First();
            return value;
        }


        public int getcountTitle(string title)
        {
            WebIMicEntities db = new WebIMicEntities();
            int value = (int)db.WEB_IMIC_SP_LessonDetailByTite(title).First();
            return value;
        }
    }
}
