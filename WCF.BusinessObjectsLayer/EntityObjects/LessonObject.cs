using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class LessonObject
    {
        public Guid LessonId { get; set; }
        public Guid LessonCategoryId { get; set; }
        public long LessonCode { get; set; }
        public string LessonName { get; set; }
        public bool ImageFlag { get; set; }
        public string SeoImage { get; set; }
        public long TotalOfView { get; set; }
        public long TotalOfLike { get; set; }
        public int TotalRank { get; set; }
        public int Rank { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string LessonSumary { get; set; }
        public AccountObject objAccount { get; set; }
        public LessonCategoryObject objCategory { get; set; }
        public LessonDetailObject objDetail { get; set; }

       
    }
}
