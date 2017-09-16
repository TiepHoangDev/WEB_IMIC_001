using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.Web.App_Start;

namespace WCF.Web.Controllers
{
    public class LessonPageController : Controller
    {
        // GET: LessonPage

       
        public ActionResult Index()
        {
            ViewBag.Title = "Kiến thức";
            //return View();
            return RedirectToAction("Message");
        }

        public ActionResult Message()
        {
            return View();
        }
        public ActionResult GetBanner()
        {
            return PartialView(new BannerBcl().GetAll());
        }
        public ActionResult Index_new()
        {
            //return View(new LessonBCL_Alt().getAllCategory());
            return RedirectToAction("Message");
        }
      
        public ActionResult Search(string query , string tag , int? start)
        {
            int lenght = 10;
            if (start == null) start = 0;
            ViewBag.start = start;
            if (start >= 1)
            {
                start = start - 1;
            }
            if (string.IsNullOrEmpty(query))
            {
               var lstquery = new LessonBCL_Alt().SearchByTag( tag, start.Value*lenght, lenght);
               ViewBag.tag = tag;
               ViewBag.total = new LessonBCL_Alt().getCountByTag(tag);
               return View(lstquery);
            }
            ViewBag.query = query;
            ViewBag.total = new LessonBCL_Alt().getCountByTitle(query);
            return View(new LessonBCL_Alt().SearchByTitle(query, start.Value * lenght, lenght));
        }
        public ActionResult CommentByLesson(Guid id)
        {
           var lstCmt  =   new CommentBCL().GetCommentByArticle(id).OrderByDescending(x=>x.ModifiedTime);
           return PartialView(lstCmt);
        }

        public ActionResult PostComment( Guid LessId )
        {
            ViewBag.ArticleId = LessId;
            return PartialView();
        }

        [HttpPost]
        public ActionResult PostComment(CommentObject obj)
        {
            var objAcc = ((AccountObject)Session[CommonConstants.SESSION_ACCOUNT]);
            var objLess = new LessonDetailBCL().getElementById((Guid)obj.ArticleId);
            obj.CommentId = Guid.NewGuid();
            obj.CommentBy = objAcc.AccountId;
            obj.ModifiedTime = DateTime.Now;
            obj.TotalOfDislikes = 0;
            obj.IsDeleted = false;
            obj.TotalOfReplies = 0;
            new CommentBCL().CommentInsert(obj);
            return RedirectToAction("Lesson_Detail", "LessonPage", new {code = objLess.DetailCode,name= StringHelpers.GenerateURL(objLess.DetailTitle)});
            //return RedirectToAction("Lesson_Detail","LessonPage",new{code =obj. })
        }
        public ActionResult getLesson(Guid catid)
        {
            var lstLess = new LessonBCL_Alt().getLessonByCat(catid);
          
            return View(lstLess);
        }

        public ActionResult GetAllLesson(Guid id)
        {
            var lstLess = new LessonBCL_Alt().getLessonByCat(id);
            return PartialView(lstLess);
        }

        public ActionResult Sidebar_LessonCount()
        {
            return View(new LessonBCL_Alt().getCount());
        }



        public ActionResult Sidebar_getCategory()
        {
            return View(new LessonBCL_Alt().getAllCategory());
        }

        public ActionResult Sidebar_getLesson(Guid catid)
        {
            return View(new LessonBCL_Alt().getLessonByCat(catid));
        }

        public ActionResult Sidebar_getDetail(Guid lessonid)
        {
            return View(new LessonBCL_Alt().getLessonDetailByLesson(lessonid));
        }

        public ActionResult Lesson_GetMore(int? page)
        {
            int length = 10;
            if (page == null) page = 0;
            return View(new LessonBCL_Alt().getAllLesson_Paging(page.Value*length, length));
        }

        public ActionResult Lesson(Guid id)
        {
            LessonObject objLesson = new LessonBCL().getElementById(id);
            ViewBag.LessonName = objLesson.LessonName;
            return View(objLesson);
        }

        public ActionResult Lesson_MoreDetail(Guid lessonid, int? page)
        {
            int length = 6;
            if (page == null)
                page = 0;
            ViewBag.Start = page.Value * length;
            return View(new LessonBCL_Alt().getLessonDetailByLesson_PAGING(lessonid, page.Value*length, length));
        }

        public ActionResult GettopClass()
        {
            var lstTrain = new OpenClassBcl().execOfGetAllElements().Take(4);
            return PartialView(lstTrain);
        }
        public ActionResult GetAll_Tag()
        {
            var lstTag = new LessonDetailTagBCL().getElements().Where(x=>x.isShowed ==true);
            return PartialView(lstTag);
        }
        public ActionResult Detail_GetRelated(Guid id)
        {

            return PartialView(new LessonDetailBCL().getElementsByLessonId(id).OrderBy(x=>x.Rank ));
        }
        public ActionResult Lesson_related(Guid catId, Guid lessId)
        {
            return PartialView(new LessonBCL().getElements().Where(x=>x.LessonCategoryId==catId && x.LessonId != lessId));
        }

        public ActionResult Lesson_Detail(long code)
        {
            //var lstDetail =  new LessonDetailBCL().GetByPrev_Next(code);
            //int i = lstDetail.Count;

            // if (i == 1)
            //{
            //    LessonDetailObject objDetail = lstDetail.First();
            //    ViewBag.Code = code;
            //    if (!string.IsNullOrEmpty(objDetail.objLesson.SeoImage))
            //    {
            //        if (objDetail.objLesson.ImageFlag == true)
            //        {
            //            ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath +
            //                            "Content/Galleries/Lesson/Lesson/" + objDetail.objLesson.SeoImage;
            //        }
            //        else
            //        {
            //            ViewBag.image = objDetail.objLesson.SeoImage;
            //        }
            //    }
            //    else
            //    {
            //        ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath +
            //                           "Content/Galleries/Lesson/Categories/" + objDetail.objLesson.objCategory.CategoryImage;
            //    }

            //    ViewBag.CategoryImage = objDetail.objLesson.objCategory.CategoryImage;
            //    ViewBag.CategoryName = objDetail.objLesson.objCategory.CategoryName;
            //    ViewBag.Title = objDetail.DetailTitle;
            //    ViewBag.DetailSummary = objDetail.DetailSummary;
            //    List<LessonDetailTagObject> lstTag = new LessonDetailTagBCL().getByLessonDetail(objDetail.LessonDetailId);
            //    GenerateSeoViewBag(objDetail, lstTag);
            //    return View(objDetail);
            //}
            //else if (i == 2)
            //{
            //    LessonDetailObject objDetail = lstDetail.ElementAt(0);
            //    LessonDetailObject objDetail1 = lstDetail.ElementAt(1);
            //    if (objDetail.Rank > objDetail1.Rank)
            //    {
            //        ViewBag.Prev = objDetail1;
            //    }
            //    else
            //    {
            //        ViewBag.Next = objDetail1;
            //    }
            //    ViewBag.Code = code;
            //    if (!string.IsNullOrEmpty(objDetail.objLesson.SeoImage))
            //    {
            //        if (objDetail.objLesson.ImageFlag == true)
            //        {
            //            ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath +
            //                            "Content/Galleries/Lesson/Lesson/" + objDetail.objLesson.SeoImage;
            //        }
            //        else
            //        {
            //            ViewBag.image = objDetail.objLesson.SeoImage;
            //        }
            //    }
            //    else
            //    {
            //        ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath +
            //                        "Content/Galleries/Lesson/Categories/" +
            //                        objDetail.objLesson.objCategory.CategoryImage;
            //    }

            //    ViewBag.CategoryImage = objDetail.objLesson.objCategory.CategoryImage;
            //    ViewBag.CategoryName = objDetail.objLesson.objCategory.CategoryName;
            //    ViewBag.Title = objDetail.DetailTitle;
            //    ViewBag.DetailSummary = objDetail.DetailSummary;
            //    List<LessonDetailTagObject> lstTag = new LessonDetailTagBCL().getByLessonDetail(objDetail.LessonDetailId);
            //    GenerateSeoViewBag(objDetail, lstTag);
            //    return View(objDetail);
            //}
            //else
            //{
            //    LessonDetailObject objDetail1 = lstDetail.ElementAt(0);
            //    LessonDetailObject objDetail = lstDetail.ElementAt(1);
            //    LessonDetailObject objDetail2 = lstDetail.ElementAt(2);
            //    ViewBag.Prev = objDetail1;
            //    ViewBag.Next = objDetail2;
            //    ViewBag.Code = code;
            //    if (!string.IsNullOrEmpty(objDetail.objLesson.SeoImage))
            //    {
            //        if (objDetail.objLesson.ImageFlag == true)
            //        {
            //            ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath +
            //                            "Content/Galleries/Lesson/Lesson/" + objDetail.objLesson.SeoImage;
            //        }
            //        else
            //        {
            //            ViewBag.image = objDetail.objLesson.SeoImage;
            //        }
            //    }
            //    else
            //    {
            //        ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath +
            //                        "Content/Galleries/Lesson/Categories/" +
            //                        objDetail.objLesson.objCategory.CategoryImage;
            //    }

            //    ViewBag.CategoryImage = objDetail.objLesson.objCategory.CategoryImage;
            //    ViewBag.CategoryName = objDetail.objLesson.objCategory.CategoryName;
            //    ViewBag.Title = objDetail.DetailTitle;
            //    ViewBag.DetailSummary = objDetail.DetailSummary;
            //    List<LessonDetailTagObject> lstTag = new LessonDetailTagBCL().getByLessonDetail(objDetail.LessonDetailId);
            //    GenerateSeoViewBag(objDetail, lstTag);
            //    return View(objDetail);

            //}

            //LessonDetailObject objDetail1 = lstDetail.ElementAt(1);
            //LessonDetailObject objDetai2 = lstDetail.ElementAt(3);

            //LessonDetailObject objDetail = lstDetail.ElementAt(2);

            return RedirectToAction("Message");

        }
        public ActionResult Detail(long code)
        {
            //LessonDetailObject objDetail = new LessonBCL_Alt().getByCode(code);

            //ViewBag.Code = code;
            //if (!string.IsNullOrEmpty(objDetail.objLesson.SeoImage))
            //{
            //    if (objDetail.objLesson.ImageFlag == true)
            //    {
            //        ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath +
            //                        "Content/Galleries/Lesson/Lesson/" + objDetail.objLesson.SeoImage;
            //    }
            //    else
            //    {
            //        ViewBag.image = objDetail.objLesson.SeoImage;
            //    }
            //}
            //else
            //{
            //    ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath +
            //                       "Content/Galleries/Lesson/Categories/" + objDetail.objLesson.objCategory.CategoryImage;
            //}
            
            //ViewBag.CategoryImage = objDetail.objLesson.objCategory.CategoryImage;
            //ViewBag.CategoryName = objDetail.objLesson.objCategory.CategoryName;
            //ViewBag.Title = objDetail.DetailTitle;
            //ViewBag.DetailSummary = objDetail.DetailSummary;
            //List<LessonDetailTagObject> lstTag = new LessonDetailTagBCL().getByLessonDetail(objDetail.LessonDetailId);
            //GenerateSeoViewBag(objDetail,lstTag);
            //return View(objDetail); 
            return RedirectToAction("Message");
        }
        public void GenerateSeoViewBag(LessonDetailObject objLesson, List<LessonDetailTagObject> lstTag)
        {
            ViewBag.type = "news";
            ViewBag.title = objLesson.DetailTitle;
            //ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "Content/Galleries/Tech/Articles/" + objTech.ArticleImageLink;
            ViewBag.description = objLesson.DetailSummary;
            if (objLesson.DetailSummary != null)
            {
                if (objLesson.DetailSummary.Length > 155)
                {
                    ViewBag.description = objLesson.DetailSummary.Substring(0, 155);
                }
                else
                {
                    ViewBag.description = objLesson.DetailSummary;
                }
            }

            String strTag = "";
            foreach (var item in lstTag)
            {
                if (item == lstTag.Last())
                    strTag += item.LessonDetailTagName;
                else
                    strTag += item.LessonDetailTagName + ",";
            }

            ViewBag.keywords = strTag;
            ViewBag.news_keywords = strTag;
        }
        public ActionResult Detail_Popular()
        {
            return View(new LessonBCL_Alt().getPopular());
        }

        public ActionResult Detail_GetTag(Guid LessonDetailId)
        {
            return PartialView("Detail_GetTag", new LessonDetailTagBCL().getByLessonDetail(LessonDetailId));
        }

        public ActionResult Detail_SearchTag(Guid LessonDetailID)
        {
            return PartialView("Detail_SearchTag", new LessonDetailTagBCL().getByLessonDetail(LessonDetailID));
        }
        public ActionResult Detail_GetRelatedLink(Guid LessonId , Guid LessonDetailId)
        {
            return PartialView("Detail_GetRelatedLink", new LessonDetailBCL().getElementsByLessonId(LessonId).Where(x=>x.LessonDetailId != LessonDetailId).OrderBy(x=>x.Rank));
        }
    }
}
