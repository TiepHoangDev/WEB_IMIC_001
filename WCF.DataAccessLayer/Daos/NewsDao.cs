using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class NewsDao:BaseModel<NewsObject>
    {
        private WebIMicEntities m_objDb = new WebIMicEntities();
        public override List<NewsObject> getElements()
        {
            List<NewsObject> lisObj = new List<NewsObject>();
            NewsCategoryDao model = new NewsCategoryDao();
            foreach(var i in m_objDb.WEB_IMIC_SP_News_GetAll())
            {
                NewsObject obj = new NewsObject();
                obj.NewsId = i.NewsId;
                obj.NewsCategoryId = i.NewsCategoryId.Value;
                obj.NewsCodeNumber = (int) i.NewsCodeNumber;
                obj.NewsAvatar = i.NewsAvatar;
                obj.NewsTitle = i.NewsTitle;
                obj.NewsSummary = i.NewsSummary;
                obj.NewsContent = i.NewsContent;
                obj.TotalOfLike = (long)i.TotalOfLike;
                obj.TotalOfComment = (long)i.TotalOfComment;
                obj.TotalOfShare = (long)i.TotalOfShare;
                obj.TotalOfView = (long)i.TotalOfView;
                obj.ModifiedBy = (Guid)i.ModifiedBy;
                obj.ModifiedTime = (DateTime)i.ModifiedTime;
                obj.IsApproved = (bool)i.IsApproved;
                obj.ApprovedBy = (Guid)i.ApprovedBy;
                obj.IsDeleted = (bool)i.IsDeleted;
                lisObj.Add(obj);
                
            }
            return lisObj;
        }

        /*
         * Thêm tin tức
         * NgocNB - 12102016
         */
        public bool InsertNews(NewsObject objNews)
        {
            using (var dbContext = new WebIMicEntities())
            {
                objNews.NewsId = Guid.NewGuid();
                
                // Insert tblNews
                dbContext.WEB_IMIC_SP_News_update(objNews.NewsId, objNews.NewsCategoryId, objNews.NewsAvatar,
                    objNews.NewsTitle, objNews.NewsSummary, objNews.NewsContent, objNews.TotalOfLike,
                    objNews.TotalOfComment, objNews.TotalOfShare, objNews.TotalOfView, objNews.IsVip, objNews.ModifiedBy,
                    (DateTime)objNews.ModifiedTime, null, null, false, false);

                // Insert tblTagNewsDetail
                if (objNews.ListTagNewsDetail != null)
                {
                    for (int i = 0; i < objNews.ListTagNewsDetail.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_TagNewsDetail_Update(Guid.NewGuid(), objNews.NewsId,
                            objNews.ListTagNewsDetail[i].TagNewsId, false);
                    }
                }
                
            }
            return true;
        }
        public bool UpdateNews(NewsObject objNews)
        {
            using (var dbContext = new WebIMicEntities())
            {
                

                // Update tblNews
                dbContext.WEB_IMIC_SP_News_update(objNews.NewsId, objNews.NewsCategoryId, objNews.NewsAvatar,
                    objNews.NewsTitle, objNews.NewsSummary, objNews.NewsContent, objNews.TotalOfLike,
                    objNews.TotalOfComment, objNews.TotalOfShare, objNews.TotalOfView, objNews.IsVip, objNews.ModifiedBy,
                    (DateTime)objNews.ModifiedTime, true, objNews.ApprovedBy, false, true);
                dbContext.WEB_IMIC_SP_TagNewsDetail_DeleteByNewsId(objNews.NewsId);
                // Update tblTagNewsDetail
                if (objNews.ListTagNewsDetail != null)
                {
                    for (int i = 0; i < objNews.ListTagNewsDetail.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_TagNewsDetail_Update(Guid.NewGuid(), objNews.NewsId,
                            objNews.ListTagNewsDetail[i].TagNewsId, false);
                    }
                }

            }
            return true;
        }
        public bool DeleteNews(Guid newsId)
        {
            using (var dbContext = new WebIMicEntities())
            {
                // Chuyển isdeleted của news = true
                dbContext.WEB_IMIC_SP_News_updateIsDeleted(newsId, true);

            }
            return true;
        }


        public List<NewsObject> GetNewsByCategoryId(Guid? categoryId)
        {
            List<NewsObject> lisRs = new List<NewsObject>();

            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_News_GetByCategoryId(categoryId);
                foreach (var item in lisGet)
                {
                    lisRs.Add(new NewsObject()
                    {
                        ApprovedBy = item.ApprovedBy == null ? Guid.Empty : (Guid)item.ApprovedBy,
                        IsApproved = item.IsApproved == null ? false : (bool)item.IsApproved,
                        IsVip = item.IsVip,
                        ModifiedBy = (Guid)item.ModifiedBy,
                        ModifiedTime =(DateTime)item.ModifiedTime,
                        NewsAvatar = item.NewsAvatar,
                        NewsCategoryId = (Guid)item.NewsCategoryId,
                        NewsCodeNumber = item.NewsCodeNumber,
                        NewsContent = item.NewsContent,
                        NewsId = item.NewsId,
                        NewsSummary = item.NewsSummary,
                        NewsTitle = item.NewsTitle,
                        TotalOfComment = item.TotalOfComment == null ? 0 : (int) item.TotalOfComment,
                        TotalOfLike = item.TotalOfLike == null ? 0 : (int)item.TotalOfLike,
                        TotalOfShare = item.TotalOfShare == null ? 0 : (int)item.TotalOfShare,
                        TotalOfView = item.TotalOfView == null ? 0 : (int)item.TotalOfView
                    });
                }
            }

            return lisRs;
        }
        public List<NewsObject> getNewsByNCCodeNumber(int ncCodeNumber)
        {
            List<NewsObject> lisRs = new List<NewsObject>();

            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_News_GetByCodeNumber(ncCodeNumber);
                foreach (var item in lisGet)
                {
                    lisRs.Add(new NewsObject()
                    {
                        ApprovedBy = item.ApprovedBy == null ? Guid.Empty : (Guid)item.ApprovedBy,
                        IsApproved = item.IsApproved == null ? false : (bool)item.IsApproved,
                        IsVip = item.IsVip,
                        ModifiedBy = (Guid)item.ModifiedBy,
                        ModifiedTime = (DateTime)item.ModifiedTime,
                        NewsAvatar = item.NewsAvatar,
                        NewsCategoryId = (Guid)item.NewsCategoryId,
                        NewsCodeNumber = item.NewsCodeNumber,
                        NewsContent = item.NewsContent,
                        NewsId = item.NewsId,
                        NewsSummary = item.NewsSummary,
                        NewsTitle = item.NewsTitle,
                        TotalOfComment = item.TotalOfComment == null ? 0 : (int)item.TotalOfComment,
                        TotalOfLike = item.TotalOfLike == null ? 0 : (int)item.TotalOfLike,
                        TotalOfShare = item.TotalOfShare == null ? 0 : (int)item.TotalOfShare,
                        TotalOfView = item.TotalOfView == null ? 0 : (int)item.TotalOfView
                    });
                }
            }

            return lisRs;
        }
        public List<NewsObject> SearchNewsByTitle(string sTimKiem)
        {
            var retList = new List<NewsObject>();
            WebIMicEntities db = new WebIMicEntities();
            var lstNew = db.WEB_IMIC_SP_News_SearchByTitle(sTimKiem);
            foreach (var item in lstNew)
            {
                NewsObject tmp = new NewsObject();
                tmp.NewsId = item.NewsId;
                tmp.NewsCategoryId =(Guid)item.NewsCategoryId;
                tmp.NewsAvatar = item.NewsAvatar;
                tmp.ModifiedTime = (DateTime)item.ModifiedTime;
                tmp.ModifiedBy =(Guid)item.ModifiedBy;
                tmp.IsVip = item.IsVip;
                tmp.NewsCodeNumber = item.NewsCodeNumber;
                tmp.NewsContent = item.NewsContent;
                tmp.NewsSummary = item.NewsSummary;
                tmp.TotalOfShare =(long)item.TotalOfShare;
                tmp.TotalOfLike = (long)item.TotalOfLike;
                tmp.TotalOfComment = (long)item.TotalOfComment;
                tmp.TotalOfView = (long)item.TotalOfView;
                tmp.IsDeleted = item.IsDeleted;
                tmp.IsApproved = item.IsApproved.Value;
                tmp.NewsTitle = item.NewsTitle;
                tmp.ApprovedBy = (Guid)item.ApprovedBy;
                retList.Add(tmp);
            }
            return retList;
        }
        public List<NewsObject> Search_NewsCategory(NewsCategoryObject objCate)
        {
            var retList = new List<NewsObject>();
            WebIMicEntities db = new WebIMicEntities();
            var lstNew = db.WEB_IMIC_SP_News_GetByCategoryId(objCate.NewsCategoryId);
            foreach (var item in lstNew)
            {
                NewsObject tmp = new NewsObject();
                tmp.NewsId = item.NewsId;
                tmp.NewsCategoryId = (Guid)item.NewsCategoryId;
                tmp.NewsAvatar = item.NewsAvatar;
                tmp.ModifiedTime = (DateTime)item.ModifiedTime;
                tmp.ModifiedBy = (Guid)item.ModifiedBy;
                tmp.IsVip = item.IsVip;
                tmp.NewsCodeNumber = item.NewsCodeNumber;
                tmp.NewsContent = item.NewsContent;
                tmp.NewsSummary = item.NewsSummary;
                tmp.TotalOfShare = (long)item.TotalOfShare;
                tmp.TotalOfLike = (long)item.TotalOfLike;
                tmp.TotalOfComment = (long)item.TotalOfComment;
                tmp.TotalOfView = (long)item.TotalOfView;
                tmp.IsDeleted = item.IsDeleted;
                tmp.IsApproved = item.IsApproved.Value;
                tmp.NewsTitle = item.NewsTitle;
                tmp.ApprovedBy = (Guid)item.ApprovedBy;
                retList.Add(tmp);
            }
            return retList;
        }
        public override List<NewsObject> getElementsById(Guid id)
        {
            var retList = new List<NewsObject>();
            WebIMicEntities db = new WebIMicEntities();
            var lstNew = db.WEB_IMIC_SP_News_GetByID(id);
            foreach (var item in lstNew)
            {
                NewsObject tmp = new NewsObject();
                tmp.NewsId = item.NewsId;
                tmp.NewsCategoryId = (Guid)item.NewsCategoryId;
                tmp.NewsAvatar = item.NewsAvatar;
                tmp.ModifiedTime = (DateTime)item.ModifiedTime;
                tmp.ModifiedBy = (Guid)item.ModifiedBy;
                tmp.IsVip = item.IsVip;
                tmp.NewsCodeNumber = item.NewsCodeNumber;
                tmp.NewsContent = item.NewsContent;
                tmp.NewsSummary = item.NewsSummary;
                tmp.TotalOfShare = (long)item.TotalOfShare;
                tmp.TotalOfLike = (long)item.TotalOfLike;
                tmp.TotalOfComment = (long)item.TotalOfComment;
                tmp.TotalOfView = (long)item.TotalOfView;
                tmp.IsDeleted = item.IsDeleted;
                tmp.IsApproved = item.IsApproved.Value;
                tmp.NewsTitle = item.NewsTitle;
                tmp.ApprovedBy = (Guid)item.ApprovedBy;
                retList.Add(tmp);
            }
            return retList;
        }
        public List<NewsObject> getTopNews(int quantity)
        {
            var retList = new List<NewsObject>();
            WebIMicEntities db = new WebIMicEntities();
            var lstNew = db.WEB_IMIC_SP_News_TopDetail(quantity);
            foreach (var item in lstNew)
            {
                NewsObject tmp = new NewsObject();
                tmp.NewsId = item.NewsId;
                tmp.NewsCategoryId = (Guid)item.NewsCategoryId;
                tmp.NewsAvatar = item.NewsAvatar;
                tmp.ModifiedTime = (DateTime)item.ModifiedTime;
                tmp.ModifiedBy = (Guid)item.ModifiedBy;
                tmp.IsVip = item.IsVip;
                tmp.NewsCodeNumber = item.NewsCodeNumber;
                tmp.NewsContent = item.NewsContent;
                tmp.NewsSummary = item.NewsSummary;
                tmp.TotalOfShare = (long)item.TotalOfShare;
                tmp.TotalOfLike = (long)item.TotalOfLike;
                tmp.TotalOfComment = (long)item.TotalOfComment;
                tmp.TotalOfView = (long)item.TotalOfView;
                tmp.IsDeleted = item.IsDeleted;
                tmp.IsApproved = item.IsApproved.Value;
                tmp.NewsTitle = item.NewsTitle;
                tmp.ApprovedBy = (Guid)item.ApprovedBy;
                retList.Add(tmp);
            }
            return retList;
        }
        public NewsObject getByCodeNumber(int number)
        {
            var retList = new List<NewsObject>();
            WebIMicEntities db = new WebIMicEntities();
            var lstNew = db.WEB_IMIC_SP_News_GetByCodeNumber(number);
            foreach (var item in lstNew)
            {
                NewsObject tmp = new NewsObject();
                tmp.NewsId = item.NewsId;
                tmp.NewsCategoryId = (Guid)item.NewsCategoryId;
                tmp.NewsAvatar = item.NewsAvatar;
                tmp.ModifiedTime = (DateTime)item.ModifiedTime;
                tmp.ModifiedBy = (Guid)item.ModifiedBy;
                tmp.IsVip = item.IsVip;
                tmp.NewsCodeNumber = item.NewsCodeNumber;
                tmp.NewsContent = item.NewsContent;
                tmp.NewsSummary = item.NewsSummary;
                tmp.TotalOfShare = (long)item.TotalOfShare;
                tmp.TotalOfLike = (long)item.TotalOfLike;
                tmp.TotalOfComment = (long)item.TotalOfComment;
                tmp.TotalOfView = (long)item.TotalOfView;
                tmp.IsDeleted = item.IsDeleted;
                tmp.IsApproved = item.IsApproved.Value;
                tmp.NewsTitle = item.NewsTitle;
                tmp.ApprovedBy = (Guid)item.ApprovedBy;
                retList.Add(tmp);
            }
            return retList.FirstOrDefault();
        }
       
    }
}
