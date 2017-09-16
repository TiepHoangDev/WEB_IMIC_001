using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class NewsObject
    {
        public Guid NewsId { get; set; }
        public Guid NewsCategoryId { get; set; }
        public int NewsCodeNumber { get; set; }
        public string NewsAvatar { get; set; }
        public string NewsTitle { get; set; }
        public string NewsSummary { get; set; }
        public string NewsContent { get; set; }
        public long TotalOfLike { get; set; }
        public long TotalOfComment { get; set; }
        public long TotalOfShare { get; set; }
        public long TotalOfView { get; set; }
        public bool IsVip { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsApproved { get; set; }
        public Guid ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }

        public NewsCategoryObject NewsCategory { get; set; }
        public List<TagNewsDetailObject> ListTagNewsDetail { get; set; }
        public AccountObject ModifiedPerson { get; set; }
        public AccountObject ApprovedPerson { get; set; }
    }
}
