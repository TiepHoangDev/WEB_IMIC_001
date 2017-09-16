using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class VideoTagDetailObject
    {
        public Guid VideoTagDetailId { get; set; }
        public Guid VideoId { get; set; }
        public Guid VideoTagId { get; set; }
    }
}
