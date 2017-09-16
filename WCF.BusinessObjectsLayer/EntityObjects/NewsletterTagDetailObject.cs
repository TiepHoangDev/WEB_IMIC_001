using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class NewsletterTagDetailObject
    {
        public Guid NewsletterTagDetailId { get; set; }
        public Guid NewsletterTagId { get; set; }
        public Guid NewsletterId { get; set; }
        public NewsletterTagObject objTag { get; set; }
    }
}
