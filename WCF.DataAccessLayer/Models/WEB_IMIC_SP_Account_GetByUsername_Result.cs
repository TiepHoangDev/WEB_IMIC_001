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
    
    public partial class WEB_IMIC_SP_Account_GetByUsername_Result
    {
        public System.Guid AccountId { get; set; }
        public byte RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageAvatar { get; set; }
        public string FullName { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public bool IsActived { get; set; }
        public Nullable<int> TotalOfArtice { get; set; }
        public Nullable<int> TotalOfBeLikedArtice { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> TotalOfVideo { get; set; }
        public string RoleName { get; set; }
    }
}
