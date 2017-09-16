using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class LessonDetailLikeObject
    {
        public Guid LessonDetailLikeId { get; set; }
        public Guid LessonDetailId { get; set; }
        public Guid LikedBy { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
