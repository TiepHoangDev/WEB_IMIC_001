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
    
    public partial class WEB_IMIC_SP_RecruitmentCompany_GETALL_Result
    {
        public System.Guid CompanyId { get; set; }
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyLink { get; set; }
        public Nullable<byte> Rank { get; set; }
        public Nullable<int> TotalOfNewsletter { get; set; }
        public string CompanyFullName { get; set; }
        public Nullable<bool> IsApproved { get; set; }
    }
}
