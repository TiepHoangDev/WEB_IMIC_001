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
    
    public partial class WEB_IMIC_SP_TechComment_GetByArticle_Result
    {
        public System.Guid TechCommentId { get; set; }
        public Nullable<System.Guid> TechArticeId { get; set; }
        public Nullable<System.Guid> CommentBy { get; set; }
        public string ConTentComment { get; set; }
        public Nullable<int> TotalOfLikes { get; set; }
        public Nullable<int> TotalOfReplies { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageAvatar { get; set; }
        public string FullName { get; set; }
        public int isLiked { get; set; }
    }
}