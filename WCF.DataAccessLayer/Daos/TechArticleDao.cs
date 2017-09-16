using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class TechArticleDao
    {
        public List<TechArticleObject> getElements()
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetAll())
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;
                objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
                objArt.LastReplier = (Guid)item.LastReplier;
                objArt.ModifiedBy = (Guid)item.ModifiedBy;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;
                lstArticle.Add(objArt);
            }
            return lstArticle;
        }
        public List<TechArticleObject> getElements_PAGING(int start,int length)
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetAll_PAGING(start,length))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;
                objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
                objArt.LastReplier = (Guid)item.LastReplier;
                objArt.ModifiedBy = (Guid)item.ModifiedBy;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;
                lstArticle.Add(objArt);
            }
            return lstArticle;
        }
        public List<TechArticleObject> getElements_PAGING_Alt(int? ccode,string query,int start, int length)
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetByCategory_PAGING_ALT(ccode,query,start,length))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
             
                objArt.isDeleted = (bool)item.IsDeleted;
   
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;
                lstArticle.Add(objArt);
            }
            return lstArticle;
        }
        public List<TechArticleObject> getByCategory_PAGING(Guid category, int start, int length)
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            //foreach (var item in db.WEB_IMIC_SP_TechArticle_GetByCategory_PAGING(category,start, length))
            //{
            //    TechArticleObject objArt = new TechArticleObject();
            //    objArt.ApprovedBy = item.ApprovedBy;
            //    objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
            //    objArt.ArticleImageLink = item.ArticeAvatar;
            //    objArt.ArticleTitle = item.ArticeTitle;
            //    objArt.CreatedBy = (Guid)item.CreatedBy;
            //    objArt.CreatedTime = (DateTime)item.CreatedTime;
            //    objArt.isActive = (bool)item.IsActived;
            //    objArt.isDeleted = (bool)item.IsDeleted;
            //    objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
            //    objArt.LastReplier = (Guid)item.LastReplier;
            //    objArt.ModifiedBy = (Guid)item.ModifiedBy;
            //    objArt.ModifiedTime = (DateTime)item.ModifiedTime;
            //    objArt.RankOfPin = (int)(byte)item.RankOfPin;
            //    objArt.TechArticleId = (Guid)item.TechArticleId;
            //    objArt.TechCategoryId = (Guid)item.TechCategoryId;
            //    objArt.TotalOfLikes = (int)item.TotalOfLikes;
            //    objArt.TotalOfLinks = (int)item.TotalOfLinks;
            //    objArt.TotalOfReplies = (int)item.TotalOfReplies;
            //    objArt.TotalOfUsers = (int)item.TotalOfUsers;
            //    objArt.TotalOfViews = (int)item.TotalOfViews;
            //    objArt.objCreateBy = new AccountObject();
            //    objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
            //    objArt.objCreateBy.FullName = item.FullName;
            //    objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
            //    objArt.objTechCategory = new TechCategoryObject();
            //    objArt.objTechCategory.CategoryName = item.CategoryName;
            //    lstArticle.Add(objArt);
            //}
            return lstArticle;
        }

        public TechArticleObject GetByTitle(string title)
        {
            WebIMicEntities db = new WebIMicEntities();
            TechArticleObject obj = new TechArticleObject();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_getByTitle(title))
            {
                obj.TechArticleId = item.TechArticleId;
                obj.ArticleTitle = item.ArticeTitle;
                return obj;
            }
            return null;
        }
        public List<TechArticleObject> getUnapprovedArticle()
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetUnapproved())
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.ContentArticle = item.ContentArticle;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;
                //objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
                //objArt.LastReplier = (Guid)item.LastReplier;
                objArt.ModifiedBy = (Guid)item.ModifiedBy;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                //objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;
                objArt.objTS = new TechStatusObject()
                {
                    StatusID = (int)item.StatusID,
                    Message = item.Message
                   
                };
                lstArticle.Add(objArt);

            }
            return lstArticle;
        }
        public List<TechArticleObject> getByCategory(TechCategoryObject objCat)
        {

            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            if (objCat == null) return lstArticle;
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetByCategory(objCat.TechCategoryId))
            {
                TechArticleObject objArt = new TechArticleObject();

                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;

                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;

                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;
                lstArticle.Add(objArt);

            }
            return lstArticle;
        }
        public TechArticleObject getElementByID(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetByID(id))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;
                objArt.ContentArticle = item.ContentArticle;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;
                objArt.isApproved = (bool)item.IsApproved;
                objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
                objArt.LastReplier = (Guid)item.LastReplier;
                objArt.ModifiedBy = (Guid)item.ModifiedBy;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                return objArt;

            }
            return null;
        }
        public TechArticleObject getByCodeNumerUnapprove(int number)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetByCodeNumber_PORTAL(number))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.ContentArticle = item.ContentArticle;
                objArt.TechSummary = item.TechSummary;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;
                objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
                objArt.LastReplier = (Guid)item.LastReplier;
                objArt.ModifiedBy = (Guid)item.ModifiedBy;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;
                return objArt;

            }
            return null;
        }
        public TechArticleObject getByCodeNumer(int number)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetByCodeNumber(number))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;
                objArt.ContentArticle = item.ContentArticle;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;
                objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
                objArt.LastReplier = (Guid)item.LastReplier;
                objArt.ModifiedBy = (Guid)item.ModifiedBy;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objCreateBy.Username = item.Username;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;
                return objArt;

            }
            return null;
        }
        public List<TechArticleObject> getPopularArticle()
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetPopularArticle())
            {
                TechArticleObject objArt = new TechArticleObject();

                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;

                lstArticle.Add(objArt);
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.TotalOfViews = (int)item.TotalOfViews;

            }
            return lstArticle;
        }
        public List<TechArticleObject> getRelatedArticle(Guid techId)
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetRelatedArticle(techId))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                lstArticle.Add(objArt);

            }
            return lstArticle;
        }
        public List<TechArticleObject> getByAccount(Guid AccountID)
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetByAccountID(AccountID))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.isApproved = (bool)item.IsApproved;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;
                objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
                objArt.LastReplier = (Guid)item.LastReplier;
                objArt.ModifiedBy = (Guid)item.ModifiedBy;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;

                lstArticle.Add(objArt);

            }
            return lstArticle;
        }
        public List<TechArticleObject> getForViewerByAccount(Guid AccountID)
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetForViewerByAccountID(AccountID))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.ApprovedBy = item.ApprovedBy;
                objArt.isApproved = (bool)item.IsApproved;
                objArt.ArticleCodeNumber = (int)item.ArticeCodeNumber;
                objArt.ArticleImageLink = item.ArticeAvatar;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.TechSummary = item.TechSummary;
                objArt.CreatedBy = (Guid)item.CreatedBy;
                objArt.CreatedTime = (DateTime)item.CreatedTime;
                objArt.isActive = (bool)item.IsActived;
                objArt.isDeleted = (bool)item.IsDeleted;
                objArt.LastRepliedTime = (DateTime)item.LastRepliedTime;
                objArt.LastReplier = (Guid)item.LastReplier;
                objArt.ModifiedBy = (Guid)item.ModifiedBy;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.RankOfPin = (int)(byte)item.RankOfPin;
                objArt.TechArticleId = (Guid)item.TechArticleId;
                objArt.TechCategoryId = (Guid)item.TechCategoryId;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.TotalOfLinks = (int)item.TotalOfLinks;
                objArt.TotalOfReplies = (int)item.TotalOfReplies;
                objArt.TotalOfUsers = (int)item.TotalOfUsers;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.objCreateBy = new AccountObject();
                objArt.objCreateBy.AccountId = (Guid)item.CreatedBy;
                objArt.objCreateBy.FullName = item.FullName;
                objArt.objCreateBy.ImageAvatar = item.ImageAvatar;
                objArt.objTechCategory = new TechCategoryObject();
                objArt.objTechCategory.CategoryName = item.CategoryName;

                lstArticle.Add(objArt);

            }
            return lstArticle;
        }
        public void addElements(TechArticleObject objTech, bool isAdmin)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticle_INSERT(objTech.TechArticleId, objTech.TechCategoryId, objTech.ArticleCodeNumber, objTech.ArticleTitle,
               objTech.TechSummary,objTech.ArticleImageLink, objTech.ContentArticle, objTech.LastReplier, objTech.LastRepliedTime, objTech.TotalOfReplies,
               objTech.TotalOfViews, objTech.TotalOfLikes, objTech.TotalOfUsers, objTech.RankOfPin, objTech.CreatedBy, objTech.ModifiedBy,
               objTech.CreatedTime, objTech.ModifiedTime, (int)(byte)objTech.RankOfPin, objTech.isApproved, objTech.isActive, objTech.ModifiedBy
               , objTech.isDeleted, isAdmin);

        }
        public void updateElements(TechArticleObject objTech)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticle_EDIT(objTech.TechArticleId, objTech.TechCategoryId, objTech.ArticleCodeNumber, objTech.ArticleTitle,objTech.TechSummary,
               objTech.ArticleImageLink, objTech.ContentArticle, objTech.LastReplier, objTech.LastRepliedTime, objTech.TotalOfReplies,
               objTech.TotalOfViews, objTech.TotalOfLikes, objTech.TotalOfUsers, objTech.RankOfPin, objTech.CreatedBy, objTech.ModifiedBy,
               objTech.CreatedTime, objTech.ModifiedTime, (int)(byte)objTech.RankOfPin, objTech.isApproved, objTech.isActive, objTech.ModifiedBy
               , objTech.isDeleted);

        }
        public List<AccountObject> GetUserLikeArticle(Guid ArticleID)
        {
            WebIMicEntities db = new WebIMicEntities();
            List<AccountObject> lstUser = new List<AccountObject>();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetUsers_LikeArticle(ArticleID))
            {
                AccountObject objAccount = new AccountObject();
                objAccount.FullName = item.FullName;
                objAccount.Username = item.Username;
                objAccount.ImageAvatar = item.ImageAvatar;
                lstUser.Add(objAccount);
            }
            return lstUser;
        }
        public List<AccountObject> getEditorAccount()
        {
            WebIMicEntities db = new WebIMicEntities();
            List<AccountObject> lstUser = new List<AccountObject>();
            foreach (var item in db.WEB_IMIC_tbl_Account_getEditorAccount())
            {
                AccountObject objAccount = new AccountObject();
                objAccount.FullName = item.FullName;
                objAccount.AccountId = item.AccountId;
                lstUser.Add(objAccount);
            }
            return lstUser;
        }

        public void approveArticle(Guid articleID, Guid checkedBy, DateTime checkedTime)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticle_ApproveArticle(articleID, checkedBy, checkedTime);
        }
        public void unapproveArticle(Guid articleID, Guid checkedBy, DateTime checkedTime, String message)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticle_UnapproveArticle(articleID, 0, checkedBy, checkedTime, message);
        }
        //public void approveArticle(Guid articleID)
        //{
        //    WebIMicEntities db = new WebIMicEntities();
        //    //db.WEB_IMIC_SP_TechArticle_ApproveArticle(articleID);
        //}
        public void deleteElement(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticle_Delete(id);
        }
        public void updateStatus(Guid articleId, int Status)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechStatus_update(articleId, Status);
        }
        public List<TechArticleObject> getByUser(Guid userid, int? Status)
        {
            List<TechArticleObject> lstArticle = new List<TechArticleObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetByUser_PORTAL(userid, Status))
            {
                TechArticleObject objArt = new TechArticleObject();
                objArt.TechArticleId = item.TechArticleId;
                objArt.ArticleTitle = item.ArticeTitle;
                objArt.objTechCategory = new TechCategoryObject()
                {
                    CategoryName = item.CategoryName
                };
                objArt.ArticleCodeNumber = item.ArticeCodeNumber;
                objArt.TotalOfViews = (int)item.TotalOfViews;
                objArt.TotalOfLikes = (int)item.TotalOfLikes;
                objArt.ModifiedTime = (DateTime)item.ModifiedTime;
                objArt.isApproved = (bool)item.IsApproved;
                objArt.objTS = new TechStatusObject();
                objArt.objTS.ReviewCount = (int)item.ReviewCount;
                objArt.objTS.objStatus = new StatusObject()
                {
                    StatusName = item.StatusName,
                    StatusID = (int)item.StatusId
                };
                lstArticle.Add(objArt);
            }
            return lstArticle;
        }
        public TechStatusObject getApprovalInfo(Guid articleid)
        {
            TechStatusObject objTS = new TechStatusObject();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticle_GetApprovalInfo_PORTAL(articleid))
            {
                objTS.CheckedTime = DateTime.MinValue;
                objTS.objCheckBy = new AccountObject()
                {
                    FullName = "Không xác định"
                };
                if (item.CheckedBy != null)
                    objTS.objCheckBy.FullName = item.FullName;
                if (item.CheckedTime != null)
                    objTS.CheckedTime = (DateTime)item.CheckedTime;
                objTS.Message = item.Message;
                objTS.ReviewCount = (int)item.ReviewCount;
                return objTS;
            }
            return null;
        }
        public void approveGroup(String articlelist, Guid CheckBy, DateTime CheckTime)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticle_ApproveGroup(articlelist, CheckBy, CheckTime);
        }
    }
}
