using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class CourseTechnologyObject
    {
        public Guid CourseTechnologyId { get; set; }
        public string CourseTechnologyName { get; set; }
        public Guid? TrainingCategoryId { get; set; }
        public string CourseTechImage { get; set; }
        public string LinkTo { get; set; }
        public bool IsDeleted { get; set; }

        public TrainingCategoryObject TrainingCategory { get; set; }
        public List<CourseTechnologyDetailObject> ListCourseTechnologyDetail { get; set; }
    }
}
