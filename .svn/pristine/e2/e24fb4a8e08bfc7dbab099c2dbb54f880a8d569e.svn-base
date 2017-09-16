using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Controllers
{
    public class TechPageController : Controller
    {
        // GET: TechPage
        #region INDEX
        public ActionResult Index_old(Guid? catid)
        {
            List<TechArticleObject> lstAr = new List<TechArticleObject>();
            ViewBag.Title = "Công nghệ";
            if (catid == null)
            {
                lstAr = new TechArticleBcl().getElements();
            }
            else
            {
                TechCategoryObject objCat = new TechCategoryObject();
                objCat.TechCategoryId = catid.Value;
                lstAr = new TechArticleBcl().getByCategory(objCat);
                Console.WriteLine(catid);
            }

            ViewBag.Catid = catid;
            return View(lstAr);
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Công nghệ";
            ViewBag.CatList = new TechCategoryBcl().getElements();
            return View();
        }
        public ActionResult Index_MoreArticle(int? ccode, String query, int? page)
        {
            int length = 12;
            if (page == null) page = 0;
            List<TechArticleObject> lstAr = new TechArticleBcl().getElements_PAGING_Alt(ccode, query, page.Value * length, length);
            return View(lstAr);
        }
        public ActionResult Index_DropdownCategory()
        {
            TechCategoryBcl ctrCategory = new TechCategoryBcl();
            return PartialView("Index_DropdownCategory", ctrCategory.getElements());
        }
        public ActionResult Index_GetTopCategory()
        {
            TechCategoryBcl ctrCategory = new TechCategoryBcl();
            return PartialView("Index_GetTopCategory", ctrCategory.getElements().Take(4));
        }
        //[HttpGet]
        //public ActionResult Index_getArticleByCategory(Guid catid, int pageSize = 15, int pageIndex = 0)
        //{
        //    TechCategoryObject objCat = new TechCategoryObject()
        //    {
        //        TechCategoryId = catid
        //    };
        //    List<TechArticleObject> lstArt = new TechArticleBcl().getByCategory(objCat).Skip(pageSize * pageIndex).Take(pageSize).ToList();
        //    return View("Index_getMoreArticle", lstArt);
        //}
        public ActionResult Index_getMoreArticle(Guid? catid, int pageSize = 15, int pageIndex = 0)
        {
            List<TechArticleObject> lstArt = new List<TechArticleObject>();
            if (catid == null) lstArt = new TechArticleBcl().getElements_PAGING(pageIndex * pageSize, pageSize);
            else
            {
                TechCategoryObject objCat = new TechCategoryObject();
                objCat.TechCategoryId = catid.Value;
                lstArt = new TechArticleBcl().getByCategory_PAGING(catid.Value, pageIndex * pageSize, pageSize);

            }

            return PartialView("Index_getMoreArticle", lstArt);
        }
        public ActionResult TechLogo()
        {
            var lstLogo = new TechLogoBcl().GetAll();
            return PartialView(lstLogo);
        }

        public ActionResult TechLink()
        {
            var lstLink = new TechLinkBcl().GetAll();
            return PartialView(lstLink);
        }
        #endregion

        #region DETAIL
        public ActionResult TechDetail(int codeNumber)
        {
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];

            TechArticleObject objArticle = new TechArticleBcl().getByCodeNumer(codeNumber);
            if (objUser != null)
            {

                bool liked = new TechArticleLikeBcl().checkUserLike(objArticle.TechArticleId, objUser.AccountId);
                ViewBag.liked = liked;
                ViewBag.Ava = objUser.ImageAvatar;
            }
            if (objArticle == null)
                return RedirectToAction("Warning", "Home");
            ViewBag.Title = objArticle.ArticleTitle;
            List<ArticleTagObject> lstTag = new ArticleTagBcl().getByArticle(objArticle.TechArticleId);
            GenerateSeoViewBag(objArticle,lstTag);
            return View("TechDetail", objArticle);
        }
        public void GenerateSeoViewBag(TechArticleObject objTech, List<ArticleTagObject> lstTag)
        {
            ViewBag.type = "TechPage";
            ViewBag.title = objTech.ArticleTitle;
            ViewBag.image = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "Content/Galleries/Tech/Articles/" + objTech.ArticleImageLink;
            ViewBag.description = objTech.TechSummary;
            if (objTech.TechSummary != null)
            {
                if (objTech.TechSummary.Length > 155)
                {
                    ViewBag.description = objTech.TechSummary.Substring(0, 155);
                }
                else
                {
                    ViewBag.description = objTech.TechSummary;
                }
            }
           
            String strTag = "";
            foreach (var item in lstTag)
            {
                if (item == lstTag.Last())
                    strTag += item.TagName;
                else
                    strTag += item.TagName + ",";
            }

            ViewBag.keywords = strTag;
            ViewBag.news_keywords = strTag;
        }
        public ActionResult Detail_GetPopularLink()
        {
            return PartialView("Detail_GetPopularLink", new TechArticleBcl().getPopularArticle());
        }
        public ActionResult Detail_GetRelatedLink( Guid techId)
        {
            return PartialView("Detail_GetRelatedLink", new TechArticleBcl().getRelatedArticle( techId));
        }
        public ActionResult Detail_GetAllCategory()
        {
            return PartialView("Detail_GetAllCategory", new TechCategoryBcl().getElements());
        }
        public JsonResult Article_Like(Guid articleid, String status)
        {
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objUser != null)
            {
                TechArticleLikeObject objLike = new TechArticleLikeObject();
                objLike.ArticleID = articleid;
                objLike.CreateTime = DateTime.Now;
                objLike.LikeBy = objUser.AccountId;
                objLike.LikeID = Guid.NewGuid();
                if (status.Equals("on"))
                    new TechArticleLikeBcl().addElement(objLike);
                if (status.Equals("off"))
                    new TechArticleLikeBcl().deleteElement(objLike);
            }
            return null;
        }
        public ActionResult Detail_GetUserLike(Guid articleid)
        {
            return PartialView("Detail_GetUserLike", new TechArticleBcl().GetUserLikeArticle(articleid));
        }

       
        #endregion
        public ActionResult Detail_GetTag(Guid articleid)
        {
            return PartialView("Detail_GetTag", new ArticleTagBcl().getByArticle(articleid));
        }

        #region COMMENT



        public ActionResult Detail_GetMoreComment(Guid articleid, int pageIndex)
        {
            int pageSize = 10;
            AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objAccount == null)
                return View(new TechCommentBcl().getByArticle_PAGING(articleid, null, pageIndex * pageSize, pageSize));
            return View(new TechCommentBcl().getByArticle_PAGING(articleid, objAccount.AccountId, pageIndex * pageSize, pageSize));
        }
        [HttpPost]
        public JsonResult Detail_InsertComment(String content, Guid id)
        {

            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objUser != null)
            {
                TechCommentObject objComment = new TechCommentObject();
                objComment.TechCommentID = Guid.NewGuid();
                objComment.TechArticleID = id;
                objComment.MofifiedTime = DateTime.Now;
                objComment.TotalOfLikes = 0;
                objComment.TotalOfReplies = 0;
                objComment.isDeleted = false;
                objComment.ContentComment = content;
                objComment.CommentBy = objUser.AccountId;
                new TechCommentBcl().addElement(objComment);
                return Json(new { rs = objComment.TechCommentID });
            }
            return Json(new { rs = "fail" });
        }
        public ActionResult Detail_AllSubComment(Guid commentid)
        {
            return View(new TechCommentReplyBcl().getByComment(commentid));
        }
        public JsonResult Detail_InsertSubComment(String content, Guid uid, Guid cid)
        {
            AccountObject objUser = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
            if (objUser != null)
            {
                TechCommentReplyObject objReply = new TechCommentReplyObject();
                objReply.ContentReply = content;
                objReply.isDeleted = false;
                objReply.MofifiedTime = DateTime.Now;
                objReply.ReplyBy = uid;
                objReply.TechCommentID = cid;
                objReply.TechCommentReplyID = Guid.NewGuid();
                new TechCommentReplyBcl().addElement(objReply);
                return Json(new { rs = objReply.TechCommentReplyID });
            }
            return Json(new { rs = "fail" });
        }

        #endregion

        #region COMMENT_LIKE
        public JsonResult Detail_LikeComment(Guid commentid)
        {
            try
            {
                TechCommentLikeBcl likeBcl = new TechCommentLikeBcl();
                AccountObject objAccount = (AccountObject)Session[CommonConstants.SESSION_ACCOUNT];
                TechCommentLikeObject objLike = new TechCommentLikeObject()
                {
                    TechCommentLikeID = Guid.NewGuid(),
                    TechCommentID = commentid,
                    LikedBy = objAccount.AccountId
                };
                int like = new TechCommentBcl().getLikeCount(commentid);
                if (!likeBcl.CheckIsLiked(objLike))
                {
                    like = like + 1;
                    likeBcl.addElement(objLike);
                    return Json(new { rs = "like",like=like });
                }
                else
                {
                    like = like - 1;
                    likeBcl.deleteElement(objLike);
                    return Json(new { rs = "unlike", like = like });
                }

            }
            catch (Exception e)
            {
                return Json(new { rs = "fail" });
            }
        }
        
        #endregion

#region Banner

        public ActionResult Banner()
        {
            var lstBanner = new TechBannerBcl().BannerGetAll();
            return PartialView(lstBanner);
        }
#endregion

#region TechRight

        public ActionResult TechRight()
        {
            var lstTechRight = new TechRightBcl().GetAll().Where(x=>x.IsShowed ==true);
            return PartialView(lstTechRight);
        }
#endregion

    }
}