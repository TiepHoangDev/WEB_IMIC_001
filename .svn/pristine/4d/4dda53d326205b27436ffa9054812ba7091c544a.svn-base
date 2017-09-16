using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class NewsletterTagDetailBCL
    {
        public List<NewsletterTagDetailObject> getByNew(Guid newid)
        {
           return new NewsletterTagDetailDAO().getByNew(newid);
        }
        public void addElement(NewsletterTagDetailObject objTag)
        {
            new NewsletterTagDetailDAO().addElement(objTag);
        }
        public void deleteAll(Guid newid)
        {
            new NewsletterTagDetailDAO().deleteAll(newid);
        }
    }
}
