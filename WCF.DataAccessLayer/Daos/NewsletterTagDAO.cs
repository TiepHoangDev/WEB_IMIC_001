using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class NewsletterTagDAO
    {
        public List<NewsletterTagObject> getElements()
        {
            List<NewsletterTagObject> lstTag = new List<NewsletterTagObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_NewsletterTag_GETALL())
            {
                NewsletterTagObject objTag = new NewsletterTagObject();
                objTag.NewsletterTagId = item.NewsLetterTagId;
                objTag.NewsletterTagName = item.NewsLetterTagName;
                objTag.TotalOfNewsletter = (int)item.TotalOfNewsletter;
                lstTag.Add(objTag);
            }
            return lstTag;
        }
        public bool CheckNameExisted(string name)
        {
            if (new WebIMicEntities().WEB_IMIC_SP_NewsletterTag_CHECKNAME(name).ToList()[0].Value > 0)
                return true;
            return false;
        }
        public NewsletterTagObject getElementByID(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_NewsletterTag_GETBYID(id))
            {
                NewsletterTagObject objTag = new NewsletterTagObject();
                objTag.NewsletterTagId = item.NewsLetterTagId;
                objTag.NewsletterTagName = item.NewsLetterTagName;
                objTag.TotalOfNewsletter = (int)item.TotalOfNewsletter;
                return objTag;
            }
            return null;
        }
        public void addElement(NewsletterTagObject objTag)
        {
            new WebIMicEntities().WEB_IMIC_SP_NewsletterTag_INSERT(objTag.NewsletterTagId, objTag.NewsletterTagName, objTag.TotalOfNewsletter);
        }
        public void updateElement(NewsletterTagObject objTag)
        {
            new WebIMicEntities().WEB_IMIC_SP_NewsletterTag_UPDATE(objTag.NewsletterTagId, objTag.NewsletterTagName, objTag.TotalOfNewsletter);

        }
    }
}
