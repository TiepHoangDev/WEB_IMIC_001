using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class ArticleTagBcl
    {
        public List<ArticleTagObject> getElements()
        {
            return new ArticleTagDao().getElements();
        }
        public List<ArticleTagObject> getByID(Guid id)
        {
            return new ArticleTagDao().getByID(id);
        }
        public List<ArticleTagObject> getByName(String tagname)
        {
            return new ArticleTagDao().getByName(tagname);
        }
        public List<ArticleTagObject> getByArticle(Guid articleid)
        {
            return new ArticleTagDao().getByArticle(articleid);
        }
        public void addElement(ArticleTagObject objTag)
        {
            new ArticleTagDao().addElement(objTag);
        }
        public void updateElement(ArticleTagObject objTag)
        {
            new ArticleTagDao().updateElement(objTag);
        }
        public bool isNameExisted(String name)
        {
            return new ArticleTagDao().isNameExisted(name);
        }
    }
}
