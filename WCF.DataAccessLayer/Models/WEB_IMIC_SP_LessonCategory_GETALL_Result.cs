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
    
    public partial class WEB_IMIC_SP_LessonCategory_GETALL_Result
    {
        public System.Guid LessonCategoryId { get; set; }
        public long CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string Username { get; set; }
        public Nullable<int> Rank { get; set; }
        public string CategorySumary { get; set; }
        public string ImageAvatar { get; set; }
    }
}
