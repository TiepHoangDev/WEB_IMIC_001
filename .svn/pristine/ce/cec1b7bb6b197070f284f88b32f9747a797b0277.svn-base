using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class NewsBcl:BaseController<NewsObject>
    {
        public List<NewsObject> getElements()
        {
            return new NewsDao().getElements();
        }
        public List<NewsObject> ExecOfSearchNewsByTitle(string strSearchTitle)
        {

            return new NewsDao().SearchNewsByTitle(strSearchTitle);
        }
        public List<NewsObject> Search_NewsCategory(NewsCategoryObject objCate)
        {
            return new NewsDao().Search_NewsCategory(objCate);
        }
        public List<NewsCategoryObject> GetNewsCategoryAll()
        {
            return new NewsCategoryDao().getAllElements();
        }

        public List<TagNewsObject> GetTagNewsAll()
        {
            return new TagNewsDao().getAllElements();
        }

        public bool InsertNews(NewsObject objNews)
        {
            return new NewsDao().InsertNews(objNews);
        }

        public bool UpdateNews(NewsObject objNews)
        {
            return new NewsDao().UpdateNews(objNews);
        }
        public bool DeleteNews(Guid newsId)
        {
            return new NewsDao().DeleteNews(newsId);
        }

        public List<NewsObject> GetNewsByCategoryId(Guid? categoryId)
        {
            return new NewsDao().GetNewsByCategoryId(categoryId);
        }
        public List<NewsObject> execOfGetNewsByNCCodeNumber(int ncCodeNumber)
        {
            return new NewsDao().getNewsByNCCodeNumber(ncCodeNumber);
        }
        public List<NewsObject> getTopNews(int quantity)
        {
            return new NewsDao().getTopNews(quantity);
        }
        public override List<NewsObject> execOfGetElementsById(Guid id)
        {
            return new NewsDao().getElementsById(id);
        }
        public NewsObject getByCodeNumber(int number)
        {
            return new NewsDao().getByCodeNumber(number);
        }
        public List<TagNewsObject> getTagNewsByNewsId(Guid newsId)
        {
            return new TagNewsDao().getByNewsId(newsId);
        }
    }
}
