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
    
    public partial class WEB_IMIC_SP_Contact_GetAll_Result
    {
        public System.Guid ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string ContentContact { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<bool> IsSeen { get; set; }
        public bool IsDeleted { get; set; }
    }
}