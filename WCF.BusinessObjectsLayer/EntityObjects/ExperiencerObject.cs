using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class ExperiencerObject
    {
        public System.Guid ExperiencerId { get; set; }
        public byte? RankToShowIntroduce { get; set; }
        public string ExperiencerImage { get; set; }
        public string FullName { get; set; }
        public bool? Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ExperienceYear { get; set; }
        public string CompanyName { get; set; }
        public string PassageDescription { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string SummaryContent { get; set; }

        public AccountObject Account { get; set; }
        public List<CourseTeacherObject> ListCourseTeacher { get; set; }
    }
}
