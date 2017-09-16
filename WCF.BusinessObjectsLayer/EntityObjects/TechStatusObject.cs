using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class TechStatusObject
    {
        public Guid TSID { get; set; }
        public Guid TechArticleID { get; set; }
        public int StatusID { get; set; }
        public Guid CheckedBy { get; set; }
        public DateTime CheckedTime { get; set; }
        public String Message { get; set; }
        public int ReviewCount { get; set; }
        public TechArticleObject objArticle { get; set; }
        public AccountObject objCheckBy { get; set; }
        public StatusObject objStatus { get; set; }
    }
}
