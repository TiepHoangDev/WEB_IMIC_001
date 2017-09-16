using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class BoxBelowObject
    {
        public Guid BoxBelowId { get; set; }
        public Guid? TrainingCategoryId { get; set; }
        public string BoxTitle { get; set; }
        public string Boxlmage { get; set; }
        public string BoxDescription { get; set; }
        public string BoxLinkTo { get; set; }
        public bool IsDeleted { get; set; }

        public TrainingCategoryObject TrainingCategory { get; set; }
        public List<BoxBelowDetailObject> ListBoxBelow { get; set; }
    }
}
