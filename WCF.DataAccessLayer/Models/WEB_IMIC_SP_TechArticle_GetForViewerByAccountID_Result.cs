//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF.DataAccessLayer.Models
{
    using System;
    
    public partial class WEB_IMIC_SP_TechArticle_GetForViewerByAccountID_Result
    {
        public System.Guid TechArticleId { get; set; }
        public Nullable<System.Guid> TechCategoryId { get; set; }
        public int ArticeCodeNumber { get; set; }
        public string ArticeTitle { get; set; }
        public string TechSummary { get; set; }
        public string ArticeAvatar { get; set; }
        public string ContentArticle { get; set; }
        public Nullable<System.Guid> LastReplier { get; set; }
        public Nullable<System.DateTime> LastRepliedTime { get; set; }
        public Nullable<int> TotalOfReplies { get; set; }
        public Nullable<int> TotalOfViews { get; set; }
        public Nullable<int> TotalOfLikes { get; set; }
        public Nullable<int> TotalOfUsers { get; set; }
        public Nullable<int> TotalOfLinks { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<int> RankOfPin { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public Nullable<System.Guid> ApprovedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string FullName { get; set; }
        public string ImageAvatar { get; set; }
        public string CategoryName { get; set; }
    }
}
