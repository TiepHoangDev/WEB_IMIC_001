using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class TrainingCategoryObject
    {
        public Guid TrainingCategoryId { get; set; }
        public string TrainingCategoryName { get; set; }
        public byte? TotalOfCourse { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string ModifiedTime { get; set; }
        public int TCCodeNumber { get; set; }

        public AccountObject ModifiedPersion{ get; set; }
    }
}
