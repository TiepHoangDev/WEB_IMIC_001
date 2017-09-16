using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class ArticleTagDetailBcl
    {
        public void addElement(ArticleTagDetailObject objDetail)
        {
            new ArticleTagDetailDao().addElement(objDetail);
        }
        public void deleteElement(Guid id)
        {
            new ArticleTagDetailDao().deleteElement(id);
        }
        public List<ArticleTagDetailObject> getByArticle(Guid articleid)
        {
            return new ArticleTagDetailDao().getByArticle(articleid);
        }
    }
}
