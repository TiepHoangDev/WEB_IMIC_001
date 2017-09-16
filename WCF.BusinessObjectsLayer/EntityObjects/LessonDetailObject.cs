using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class LessonDetailObject
    {
        public Guid LessonDetailId { get; set; }
        public Guid LessonId { get; set; }
        public long DetailCode { get; set; }
        public string DetailName { get; set; }
        public string DetailTitle { get; set; }
        public string DetailSummary { get; set; }
        public string DetailContent { get; set; }
        public long TotalOfLike { get; set; }
        public long TotalOfComment { get; set; }
        public long TotalOfShare { get; set; }
        public long TotalOfView { get; set; }
        public int Rank { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsApproved { get; set; }
        public Guid ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public AccountObject objAccount { get; set; }
        public LessonObject objLesson { get; set; }
    }
}
