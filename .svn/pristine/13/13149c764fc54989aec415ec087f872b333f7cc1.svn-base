using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Controllers
{
    public class NewsPageController : Controller
    {
        // GET: NewsPage
        public ActionResult Index(Guid? newsCategoryId)
        {
            ViewBag.newsCategoryId = newsCategoryId;
            return View();
        }
        

        public ActionResult Index_DropdownCategory()
        {
            return View(new NewsCategoryBcl().execOfGetElements().OrderBy(x => x.NCCode).ToList());
        }

        public ActionResult Index_MoreArticle(Guid? newsCategoryId, string strSearch, int pageSize = 24, int pageIndex = 0)
        {
            //if (string.IsNullOrEmpty(strSearch))
            //{
            //    var list = new NewsBcl().ExecOfSearchNewsByTitle(strSearch).OrderByDescending(n => n.ModifiedTime).Skip(pageIndex * pageSize).Take(pageSize);
            //    return View(list.ToList());
            //}
            if (newsCategoryId == null || newsCategoryId.Equals(Guid.Parse("4fc3b247-6633-40f0-8f98-40c97fc67458")))
            {
                var list =
                    new NewsBcl().getElements()
                        .OrderByDescending(n => n.ModifiedTime)
                        .Skip(pageIndex*pageSize)
                        .Take(pageSize);
                return View(list.ToList());
            }

        else
            {
                var list =
                    new NewsBcl().GetNewsByCategoryId(newsCategoryId)
                        .OrderByDescending(n => n.ModifiedTime)
                        .Skip(pageIndex*pageSize)
                        .Take(pageSize);
                return View(list.ToList());
            }
            
            
        }
        
        public ActionResult NewsDetail(int newsCodeNumber)
        {
            NewsObject objNew = new NewsBcl().getByCodeNumber(newsCodeNumber);
            List<TagNewsObject> lstTag = new NewsBcl().getTagNewsByNewsId(objNew.NewsId);
            ViewBag.ListTag = lstTag;
            return View(objNew);
        }

        //Cai nay hien tai dang la fake
        public ActionResult Index_UserPostedNews()
        {
            var list = new NewsBcl().getElements().OrderByDescending(n => n.TotalOfView).Take(6);
            return View(list.ToList());
        }

        public ActionResult Index_TopNews()
        {
            return View(new NewsBcl().getTopNews(4));
        }

        //public ActionResult getDropdownCategory()
        //{
        //    return PartialView("_Pr_NewsPage_DropdownCategory", new NewsCategoryBcl().execOfGetElements());
        //}
        //public ActionResult getMoreArticle(int pageSize = 8, int pageIndex = 0)
        //{
        //    var list = new NewsBcl().getElements().OrderByDescending(n => n.ModifiedTime).Skip(pageIndex * pageSize).Take(pageSize);
        //    return PartialView("_Pr_NewsPage_GetMoreArticle", list.ToList());
        //}
        //[HttpGet]
        //public ActionResult goToNewDetail(int NewsCodeNumber)
        //{
        //    return View("NewDetail", new NewsBcl().getByCodeNumber(NewsCodeNumber));
        //}
        ////Cai nay hien tai dang la fake
        //public ActionResult getUserPostedNews()
        //{
        //    var list = new NewsBcl().getElements().OrderByDescending(n => n.TotalOfView).Take(6);
        //    return PartialView("_Pr_NewsPage_UserPostedNews",list.ToList());
        //}
        //public ActionResult getTopNews()
        //{
        //   return PartialView("_Pr_NewsPage_TopNews",new NewsBcl().getTopNews(4));
        //}
    }
}