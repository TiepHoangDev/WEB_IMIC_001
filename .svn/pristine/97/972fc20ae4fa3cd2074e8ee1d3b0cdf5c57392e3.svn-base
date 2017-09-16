using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCF.BusinessControlLayer.Bcls;
using WCF.BusinessObjectsLayer.Commons;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Areas.AdminCP.Controllers
{
    public class NewsAdminController : BaseController
    {
        
        /*
         * Xử lý nghiệp vụ về tin tức
         * NgocNB- 11102016
         */

        /*
         * Trang index
         * NgocNB - 11102016
         */
        public ActionResult Index()
        {
            return View();
        }

        /*
         * Thêm tin mới
         * NgocNB - 11102016
         */
        public ActionResult NewsInsert()
        {
            ViewBag.Title = "Đăng khoá học mới";
            ViewBag.ListCategory = from x in new NewsBcl().GetNewsCategoryAll().OrderBy(x => x.NCCode)
                                   where x.NCCode != 0
                                   select x;
            ViewBag.ListTag = new NewsBcl().GetTagNewsAll();

            return View();
        }

        /*
         * Post thêm tin mới
         * NgocNB - 11102016
         */
        [HttpPost, ValidateInput(false)]
        public ActionResult NewsInsert(NewsObject objNews, HttpPostedFileBase fileAvatar, string[] lisTagNewsIdSelected)
        {
            //HttpContext.Server.ScriptTimeout = 900000; // Timeout tải file quá lâu

           
            
                // Lưu avatar vào host
                string fileName = Path.GetFileName(fileAvatar.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Galleries/News/NewsImage/"),
                    fileName);
                fileAvatar.SaveAs(path);

                // Đóng gói đối tượng objCourse
                objNews.NewsAvatar = fileName;
                if (lisTagNewsIdSelected != null)
                {
                    objNews.ListTagNewsDetail = new List<TagNewsDetailObject>();
                    foreach (var sTagNewsId in lisTagNewsIdSelected)
                    {
                        objNews.ListTagNewsDetail.Add(new TagNewsDetailObject()
                        {
                            TagNewsId = Guid.Parse(sTagNewsId)
                        });
                    }
                }

                // Gọi BCL insert news
                new NewsBcl().InsertNews(objNews);
            

            return RedirectToAction("ListNews");
        }
        public ActionResult NewsEdit(Guid newsId)
        {
            ViewBag.Title = "Sửa khóa học";
            ViewBag.ListCategory = from x in new NewsBcl().GetNewsCategoryAll().OrderBy(x => x.NCCode)
                                   where x.NCCode != 0
                                   select x;
            List<TagNewsObject> List = new NewsBcl().GetTagNewsAll().ToList();
            List<TagNewsObject> ListTagByNewsId = new NewsBcl().getTagNewsByNewsId(newsId).ToList();

            var ListTag = List.Where(p => !ListTagByNewsId.Any(x => x.TagNewsId == p.TagNewsId)).ToList();

            ViewBag.ListTag = ListTag;
            ViewBag.ListTagByNewsId = ListTagByNewsId;

            var listdata = new NewsBcl().execOfGetElementsById(newsId).FirstOrDefault();
            if (listdata == null)
            {
                return HttpNotFound();
            }
            return View(listdata);

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult NewsEdit(NewsObject objNews, HttpPostedFileBase fileAvatar, string[] lisTagNewsIdSelected)
        {
            
            try
            {
                HttpContext.Server.ScriptTimeout = 1000;
                
                if (ModelState.IsValid)
                {
                    if (fileAvatar != null)
                    {
                        string fileName = Path.GetFileName(fileAvatar.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/Galleries/News/NewsImage/"), fileName);
                        fileAvatar.SaveAs(path);
                        objNews.NewsAvatar = fileAvatar.FileName;
                        if (lisTagNewsIdSelected != null)
                        {
                            objNews.ListTagNewsDetail = new List<TagNewsDetailObject>();
                            foreach (var sTagNewsId in lisTagNewsIdSelected)
                            {
                                objNews.ListTagNewsDetail.Add(new TagNewsDetailObject()
                                {
                                    TagNewsId = Guid.Parse(sTagNewsId)
                                });
                            }
                        }
                        new NewsBcl().UpdateNews(objNews);

                    }
                    else
                    {
                        if (lisTagNewsIdSelected != null)
                        {
                            objNews.ListTagNewsDetail = new List<TagNewsDetailObject>();
                            foreach (var sTagNewsId in lisTagNewsIdSelected)
                            {
                                objNews.ListTagNewsDetail.Add(new TagNewsDetailObject()
                                {
                                    TagNewsId = Guid.Parse(sTagNewsId)
                                });
                            }
                        }
                        new NewsBcl().UpdateNews(objNews);
                    }
                    return RedirectToAction("ListNews");

                }
                return Json(new { Success = false, Message = "Dữ liệu không hợp lệ" });
            }

            catch (Exception)
            {
                return RedirectToAction("ListNews");

            }
        }

        [HttpPost]
        public ActionResult Delete(Guid newsId)
        {
            try
            {
                new NewsBcl().DeleteNews(newsId);
                return Json(new {Success = "True", Message = "Xóa dữ liệu thành công"});
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }
        }
        [HttpPost]
        public ActionResult DeleteCheckAll(string[] idArr)
        {
            try
            {
                foreach (string id in idArr)
                {
                    new NewsBcl().DeleteNews(Guid.Parse(id));
                }
                
                return Json(new { Success = "True", Message = "Xóa dữ liệu thành công" });
            }
            catch (Exception)
            {

                return Json(new { Success = "False", Message = "Xóa dữ liệu thất bại" });
            }
        }

        /*
         * List tin tức
         * NgocNB - 18102016
         */
        public ActionResult ListNews(Guid? categoryId)
        {
            ViewBag.Title = "Danh sách khoá học";
            var lisCategoryAll = from x in new NewsBcl().GetNewsCategoryAll().OrderBy(x => x.NCCode)
                where x.NCCode != 0
                select x;
                                 
            ViewBag.ListCategory = lisCategoryAll;

            if (categoryId == null)
            {
                //categoryId = lisCategoryAll.First().NewsCategoryId;
                return View(new NewsBcl().getElements().OrderByDescending(n => n.ModifiedTime));
            }

            return View(new NewsBcl().GetNewsByCategoryId(categoryId).OrderByDescending(n => n.ModifiedTime));
            
            
        }
    }
}