using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class VideoLikeObject
    {
        public Guid VideoLikeId { get; set; }
        public Guid VideoId { get; set; }
        public Guid LikeBy { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
