using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class TrainingPageObject
    {
        public Guid TrainingPageId { get; set; }
        public string LearningTimeTitle { get; set; }
        public string SessionName1 { get; set; }
        public string SessionTime1 { get; set; }
        public string SessionName2 { get; set; }
        public string SessionTime2 { get; set; }
        public string SessionName3 { get; set; }
        public string SessionTime3 { get; set; }
        public string SessionName4 { get; set; }
        public string SessionTime4 { get; set; }
        public string CalendarTitle { get; set; }
        public string CalendarDescription { get; set; }
        public string CalendarLinkTo { get; set; }
        public string TeacherTitle { get; set; }
        public string TeacherDescription { get; set; }
        public string TeacherLinkTo { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string ModifiedTime { get; set; }
        public bool IsDeleted { get; set; } 

        public AccountObject ModifiedPerson { get; set; }
    }
}
