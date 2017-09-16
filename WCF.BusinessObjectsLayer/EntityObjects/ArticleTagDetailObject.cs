using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class ArticleTagDetailObject
    {
        public Guid TagDetailId { get; set; }
        public Guid ArticleId { get; set; }
        public Guid ArticleTagId { get; set; }
        public bool isDeleted { get; set; }
        public TechArticleObject objArticle { get; set; }
        public ArticleTagObject objTag { get; set; }
    }
}
