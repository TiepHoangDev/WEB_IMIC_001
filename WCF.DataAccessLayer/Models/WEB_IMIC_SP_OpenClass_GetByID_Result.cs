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
    
    public partial class WEB_IMIC_SP_OpenClass_GetByID_Result
    {
        public System.Guid ClassId { get; set; }
        public Nullable<System.Guid> CourseId { get; set; }
        public string ClassName { get; set; }
        public string ClassAvatar { get; set; }
        public string ClassTime { get; set; }
        public string Month { get; set; }
        public string DayOfMonth { get; set; }
        public string ContentPopup { get; set; }
        public string DayOfWeek { get; set; }
        public Nullable<byte> TotalOfRegisters { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<System.Guid> ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<byte> MaxTotalOfStudents { get; set; }
        public string LocationID { get; set; }
    }
}
