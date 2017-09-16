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
    
    public partial class WEB_IMIC_SP_Video_GetByAccountID_Result
    {
        public System.Guid VideoId { get; set; }
        public Nullable<System.Guid> VideoCategoryId { get; set; }
        public string VideoCodeNumber { get; set; }
        public string VideoName { get; set; }
        public string VideoLink { get; set; }
        public string VideoThumbnail { get; set; }
        public string VideoDescription { get; set; }
        public Nullable<long> TotalOfViews { get; set; }
        public Nullable<long> TotalOfLikes { get; set; }
        public Nullable<long> TotalOfDislikes { get; set; }
        public long TotalOfComments { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<System.Guid> ApprovedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.Guid> AccountId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string ImageAvatar { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> VideoSubCategoryId { get; set; }
    }
}
