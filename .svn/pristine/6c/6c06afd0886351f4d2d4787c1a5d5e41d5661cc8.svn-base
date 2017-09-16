using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Controllers
{
    public class RecruitPageController : Controller
    {
        // GET: RecruitPage
        public ActionResult Index(int? code, string query)
        {
            ViewBag.code = code;
            ViewBag.query = query;
            var obj = new RecruitmentTitleBcl().GetAll();
            return View(obj);
        }
        public ActionResult Index_Upperbox()
        {
            return View();
        }
        public ActionResult Index_Belowbox()
        {
            return View();
        }
        public ActionResult Index_Newsletter(int? code, string query, int? start)
        {
            int length = 10;
            if (start == null) start = 0;
            return View(new RecruitmentNewsletterBCL().getForPaging(code, query, start.Value * length, length));
        }
        public ActionResult Index_Company()
        {
            return View(new RecruitmentCompanyBCL().Get().Where(x=>x.IsApproved==true).OrderBy(x=>x.Rank).Take(5).ToList());
        }
        public ActionResult Index_PopularNews()
        {
            return View(new RecruitmentNewsletterBCL().getPopular());
        }
        public ActionResult Index_Tag()
        {
            return View(new NewsletterTagBCL().getElements());
        }
        public ActionResult Detail_ComRelated(Guid id)
        {
            return View(new RecruitmentNewsletterBCL().getRelated_Category(id));
        }
        public ActionResult Detail(long code)
        {
            RecruitmentNewsletterObject objNews = new RecruitmentNewsletterBCL().getByCode(code);
            List<NewsletterTagDetailObject> lstTag = new NewsletterTagDetailBCL().getByNew(objNews.NewsletterId);
            ViewBag.TagList = lstTag;
         
            GenerateSeoViewBag(objNews, lstTag);
            ViewBag.Title = objNews.Title;
            return View(objNews);
        }
        public void GenerateSeoViewBag(RecruitmentNewsletterObject objNew, List<NewsletterTagDetailObject> lstTag)
        {
            ViewBag.type = "news";
            ViewBag.title = objNew.Title;
            ViewBag.image = objNew.ImageLink;
            if (objNew.ImageServerFlag == true)
            {
                ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "Content/Galleries/Recruit/" + objNew.ImageLink;
            }
            ViewBag.description = objNew.Description;
            if (objNew.Description != null)
            {
                if (objNew.Description.Length > 155)
                {
                    ViewBag.description = objNew.Description.Substring(0, 155);
                }
                else
                {
                    ViewBag.description = objNew.Description;
                }
            }
            String strTag = "";
            foreach (var item in lstTag)
            {
                if (item == lstTag.Last())
                    strTag += item.objTag.NewsletterTagName;
                else
                    strTag += item.objTag.NewsletterTagName + ",";
            }

            ViewBag.keywords = strTag;
            ViewBag.news_keyword = strTag;
            ViewBag.news_keywords = strTag;
        }
        public ActionResult Detail_Related(Guid rid)
        {
            return View(new RecruitmentNewsletterBCL().getRelated(rid));
        }
    }
}