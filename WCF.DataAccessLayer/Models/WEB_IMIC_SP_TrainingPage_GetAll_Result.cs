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
    
    public partial class WEB_IMIC_SP_TrainingPage_GetAll_Result
    {
        public System.Guid TrainingPageId { get; set; }
        public string LearningTimeTitle { get; set; }
        public string SessionName1 { get; set; }
        public string SessionTime1 { get; set; }
        public string SessionName2 { get; set; }
        public string SessionTime2 { get; set; }
        public string SessionName3 { get; set; }
        public string SessionTime3 { get; set; }
        public string SessionName4 { get; set; }
        public string SessionTime4 { get; set; }
        public string CalendarTitle { get; set; }
        public string CalendarDescription { get; set; }
        public string CalendarLinkTo { get; set; }
        public string TeacherTitle { get; set; }
        public string TeacherDescription { get; set; }
        public string TeacherLinkTo { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
