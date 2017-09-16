using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class BoxBelowDetailObject
    {
        public Guid BoxBelowDetailId { get; set; }
        public Guid CourseId { get; set; }
        public Guid BoxBelowId { get; set; }
        public byte? RankToShow { get; set; }
        public List<CourseObject> ListCourse { get; set; }
        public List<BoxBelowObject> ListBoxBelow { get; set; }
    }
}
