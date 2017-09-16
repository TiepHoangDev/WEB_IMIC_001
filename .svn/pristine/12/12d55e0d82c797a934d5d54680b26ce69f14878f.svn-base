using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class ArticleTagDao
    {
        public List<ArticleTagObject> getElements()
        {
            List<ArticleTagObject> lstTag = new List<ArticleTagObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticeTags_getAll())
            {
                ArticleTagObject objTag = new ArticleTagObject();
                objTag.ArticleTagId = item.ArticeTagId;
                objTag.TagName = item.TagName;
                objTag.isDeleted = false;
                objTag.TotalOfArticle = (int)objTag.TotalOfArticle;
                lstTag.Add(objTag);
            }
            return lstTag;
        }
        public List<ArticleTagObject> getByName(String tagname)
        {
            List<ArticleTagObject> lstTag = new List<ArticleTagObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticeTags_getByName(tagname))
            {
                ArticleTagObject objTag = new ArticleTagObject();
                objTag.ArticleTagId = item.ArticeTagId;
                objTag.TagName = item.TagName;
                objTag.isDeleted = false;
                lstTag.Add(objTag);
            }
            return lstTag;
        }
        public List<ArticleTagObject> getByID(Guid id)
        {
            List<ArticleTagObject> lstTag = new List<ArticleTagObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticeTags_getByID(id))
            {
                ArticleTagObject objTag = new ArticleTagObject();
                objTag.ArticleTagId = item.ArticeTagId;
                objTag.TagName = item.TagName;
                objTag.isDeleted = false;
                lstTag.Add(objTag);
            }
            return lstTag;
        } 
        public List<ArticleTagObject> getByArticle(Guid articleid)
        {
            List<ArticleTagObject> lstTag = new List<ArticleTagObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_TechArticeTags_getByArticle(articleid))
            {
                ArticleTagObject objTag = new ArticleTagObject();
                objTag.ArticleTagId = item.ArticeTagId;
                objTag.TagName = item.TagName;
                objTag.isDeleted = false;
                lstTag.Add(objTag);
            }
            return lstTag;
        }
        public void addElement(ArticleTagObject objTag)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticeTags_Insert(objTag.ArticleTagId, objTag.TagName, false);
        }
        public void updateElement(ArticleTagObject objTag)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechArticeTags_Update(objTag.ArticleTagId, objTag.TagName, false);
        }
        public bool isNameExisted(String name)
        {
            WebIMicEntities db = new WebIMicEntities();
          
            if (db.WEB_IMIC_SP_TechArticeTags_CheckName(name).ToList()[0] > 0)
                return true;
            return false;
        }
    }
}
