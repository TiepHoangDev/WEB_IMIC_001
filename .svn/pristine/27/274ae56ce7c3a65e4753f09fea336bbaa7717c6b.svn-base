using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class ArticleTagDetailDao
    {
        public void addElement(ArticleTagDetailObject objDetail)
        {
            new WebIMicEntities().WEB_IMIC_SP_TechTagsDetail_Insert(objDetail.TagDetailId, objDetail.ArticleId, objDetail.ArticleTagId, false);
        }
        public void deleteElement(Guid id)
        {
            new WebIMicEntities().WEB_IMIC_SP_TechTagsDetail_Delete(id);
        }
        public List<ArticleTagDetailObject> getByArticle(Guid articleid)
        {
            List<ArticleTagDetailObject> lstDetail = new List<ArticleTagDetailObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach(var item in db.WEB_IMIC_SP_TechTagsDetail_getByArticle(articleid))
            {
                ArticleTagDetailObject objDetail = new ArticleTagDetailObject();
                objDetail.ArticleId = articleid;
                objDetail.TagDetailId = item.TagDetailId;
                objDetail.ArticleTagId = (Guid)item.ArticleTagId;
                lstDetail.Add(objDetail);
            }
            return lstDetail;
        }
    }
}
