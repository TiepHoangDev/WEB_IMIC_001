using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class NewsletterTagBCL
    {
        public List<NewsletterTagObject> getElements()
        {
            return new NewsletterTagDAO().getElements();
        }
        public NewsletterTagObject getElementByID(Guid id)
        {
            return new NewsletterTagDAO().getElementByID(id);
        }
        public void addElement(NewsletterTagObject objTag)
        {
            new NewsletterTagDAO().addElement(objTag);
        }
        public void updateElement(NewsletterTagObject objTag)
        {
            new NewsletterTagDAO().updateElement(objTag);

        }
        public bool CheckNameExisted(string name)
        {
            return new NewsletterTagDAO().CheckNameExisted(name);
        }
    }
}
