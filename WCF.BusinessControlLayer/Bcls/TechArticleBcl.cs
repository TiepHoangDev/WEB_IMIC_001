using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class TechArticleBcl
    {
        public List<TechArticleObject> getElements_PAGING_Alt(int? ccode, string query, int start, int length)
        {
            return new TechArticleDao().getElements_PAGING_Alt(ccode, query, start, length);
        }
        public List<TechArticleObject> getElements()
        {
            return new TechArticleDao().getElements();
        }
        public List<TechArticleObject> getElements_PAGING(int start, int length)
        {
            return new TechArticleDao().getElements_PAGING(start, length);
        }
        public List<TechArticleObject> getByCategory(TechCategoryObject objCat)
        {
            return new TechArticleDao().getByCategory(objCat);
        }
        public List<TechArticleObject> getByCategory_PAGING(Guid category, int start, int length)
        {
            return new TechArticleDao().getByCategory_PAGING(category, start, length);
        }
        public void addElements(TechArticleObject objTech, bool isAdmin)
        {
            new TechArticleDao().addElements(objTech, isAdmin);
        }
        public void updateElements(TechArticleObject objTech)
        {
            new TechArticleDao().updateElements(objTech);
        }
        public void approveGroup(String articlelist, Guid CheckBy, DateTime CheckTime)
        {
            new TechArticleDao().approveGroup(articlelist, CheckBy, CheckTime);
        }
        public TechArticleObject getByCodeNumer(int number)
        {
            return new TechArticleDao().getByCodeNumer(number);
        }
        public TechArticleObject getByCodeNumerBTV(int number)
        {
            return new TechArticleDao().getByCodeNumerUnapprove(number);
        }
        public List<TechArticleObject> getPopularArticle()
        {
            return new TechArticleDao().getPopularArticle();
        }
        public List<TechArticleObject> getRelatedArticle(Guid techId)
        {
            return new TechArticleDao().getRelatedArticle( techId);
        }
        public List<TechArticleObject> getUnapprovedArticle()
        {
            return new TechArticleDao().getUnapprovedArticle();
        }
        //public void approveArticle(Guid articleID)
        //{
        //    new TechArticleDao().approveArticle(articleID);
        //}
        public void approveArticle(Guid articleID, Guid checkedBy, DateTime checkedTime)
        {
            new TechArticleDao().approveArticle(articleID, checkedBy, checkedTime);
        }
        public void unapproveArticle(Guid articleID, Guid checkedBy, DateTime checkedTime, String message)
        {
            new TechArticleDao().unapproveArticle(articleID, checkedBy, checkedTime, message);
        }
        public TechStatusObject getApprovalInfo(Guid articleid)
        {
            return new TechArticleDao().getApprovalInfo(articleid);
        }
        public void updateStatus(Guid articleId, int Status)
        {
            new TechArticleDao().updateStatus(articleId, Status);
        }
        public List<TechArticleObject> getByUser(Guid userid, int? status)
        {
            return new TechArticleDao().getByUser(userid, status);
        }
        public TechArticleObject getElementByID(Guid id)
        {
            return new TechArticleDao().getElementByID(id);
        }
        public TechArticleObject getByTitle(string title)
        {
            return new TechArticleDao().GetByTitle(title);
        }
        public void deleteElement(Guid id)
        {
            new TechArticleDao().deleteElement(id);
        }
        public List<AccountObject> GetUserLikeArticle(Guid ArticleID)
        {
            return new TechArticleDao().GetUserLikeArticle(ArticleID);
        }
        public List<AccountObject> getEditorAccount()
        {
            return new TechArticleDao().getEditorAccount();
        }
        public List<TechArticleObject> getByAccount(Guid AccountID)
        {
            return new TechArticleDao().getByAccount(AccountID);
        }
        public List<TechArticleObject> getForViewerByAccount(Guid AccountID)
        {
            return new TechArticleDao().getForViewerByAccount(AccountID);
        }
    }
}
