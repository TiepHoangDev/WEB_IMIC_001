using System;
using System.ComponentModel.DataAnnotations;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class AccountObject
    {
        public System.Guid AccountId { get; set; }
        public byte RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string newPassword { get; set; }
        public string ImageAvatar { get; set; }
        public string FullName { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public bool IsActived { get; set; }
        public Nullable<int> TotalOfVideo { get; set; }
        public Nullable<int> TotalOfArtice { get; set; }
        public Nullable<int> TotalOfBeLikedArtice { get; set; }
        public string LastLoginTime { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public string ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public AccountObject ModifiedPerson { get; set; }
        public string RoleName { get; set; }
        public RoleObject objRole { get; set; }
        public bool RememberMe { get; set; }
    }
}
