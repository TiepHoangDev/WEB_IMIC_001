using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class LessonDetailTagObject
    {
        public Guid LessonDetailTagId { get; set; }
        public string LessonDetailTagName { get; set; }
        public int TotalOfLessons { get; set; }
        public bool isShowed { get; set; }
    }
}
