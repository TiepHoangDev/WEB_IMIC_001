using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class DemoProjectObject
    {
        public Guid DemoProjectId { get; set; }
        public Guid? TrainingCategoryId { get; set; }
        public string ProjectName { get; set; }
        public string Thumbnail { get; set; }
        public string DemoLink { get; set; }
        public bool?TabType { get; set; }
        public bool? DemoType { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }

        public AccountObject ModifiedPerson { get; set; }
        public TrainingCategoryObject TrainingCategory { get; set; }
        public List<DemoProjectDetailObject> ListDemoProjectDetail { get; set; }


    }
}
