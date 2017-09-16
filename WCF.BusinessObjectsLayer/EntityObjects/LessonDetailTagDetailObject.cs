using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class LessonDetailTagDetailObject
    {
        public Guid LessonDetailTagDetailId { get; set; }
        public Guid LessonDetailId { get; set; }
        public Guid LessonDetailTagId { get; set; }
    }
}
