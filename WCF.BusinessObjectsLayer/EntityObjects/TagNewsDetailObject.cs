using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class TagNewsDetailObject
    {
        public Guid NewsTagId { get; set; }
        public Guid NewsId { get; set; }
        public Guid TagNewsId { get; set; }
        public bool IsDeleted { get; set; }

        public NewsObject News { get; set; }
        public TagNewsObject TagNews { get; set; }
    }
}
