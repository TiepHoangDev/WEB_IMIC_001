using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class TechArticleObject
    {
        public Guid TechArticleId { get; set; }
        public Guid TechCategoryId { get; set; }
        public int ArticleCodeNumber { get; set; }
        public String ArticleTitle { get; set; }
        public String TechSummary { get; set; }
        public String ArticleImageLink { get; set; }
        public String ContentArticle { get; set; }
        public Guid? LastReplier { get; set; }
        public DateTime LastRepliedTime { get; set; }
        public int TotalOfReplies { get; set; }
        public int TotalOfViews { get; set; }
        public int TotalOfLikes { get; set; }
        public int TotalOfUsers { get; set; }
        public int TotalOfLinks { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int RankOfPin { get; set; }
        public bool isActive { get; set; }
        public Guid? ApprovedBy { get; set; }
        public bool isApproved { get; set; }
        public bool isDeleted { get; set; }
        public TechStatusObject objTS { get; set; }
        public TechArticleObject()
        {
            TotalOfReplies = 0;
            TotalOfViews = 0;
            TotalOfLikes = 0;
            TotalOfUsers = 0;
            TotalOfLinks = 0;
        }
        public AccountObject objCreateBy { get; set; }
        public TechCategoryObject objTechCategory { get; set; }
    }
}
