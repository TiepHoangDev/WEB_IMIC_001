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
    
    public partial class WEB_IMIC_SP_VideoCommentReply_GETBYID_Result
    {
        public System.Guid VideoCommentReplyId { get; set; }
        public Nullable<System.Guid> VideoCommentId { get; set; }
        public Nullable<System.Guid> ReplyBy { get; set; }
        public string ContentReply { get; set; }
        public Nullable<int> TotalOfLikes { get; set; }
        public Nullable<int> TotalOfDislikes { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
