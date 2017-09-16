using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class NewsletterTagDetailDAO
    {
        public List<NewsletterTagDetailObject> getByNew(Guid newid)
        {
            List<NewsletterTagDetailObject> lstTag = new List<NewsletterTagDetailObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach(var item in db.WEB_IMIC_SP_NewsletterTagDetail_GETBYNEWS(newid))
            {
                NewsletterTagDetailObject objTag = new NewsletterTagDetailObject();
                objTag.NewsletterTagId = (Guid)item.NewsLetterTagId;
                objTag.objTag = new NewsletterTagObject()
                {
                    NewsletterTagName = item.NewsLetterTagName
                };
                lstTag.Add(objTag);
            }
            return lstTag;
        }
        public void addElement(NewsletterTagDetailObject objTag)
        {
            new WebIMicEntities().WEB_IMIC_SP_NewsletterTagDetail_INSERT(objTag.NewsletterTagDetailId, objTag.NewsletterId, objTag.NewsletterTagId);
        }
        public void deleteAll(Guid newid)
        {
            new WebIMicEntities().WEB_IMIC_SP_NewsletterTagDetail_DELETEALL(newid);
        }
    }
}
