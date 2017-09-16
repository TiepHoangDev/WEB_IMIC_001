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
    
    public partial class WEB_IMIC_SP_Course_GetAll_Result
    {
        public System.Guid CourseId { get; set; }
        public System.Guid TrainingCategoryId { get; set; }
        public int CourseCodeNumber { get; set; }
        public string CourseName { get; set; }
        public string CourseImage { get; set; }
        public Nullable<byte> IsOnline { get; set; }
        public Nullable<double> Rating { get; set; }
        public Nullable<long> TotalOfRating { get; set; }
        public Nullable<long> SumOfRating { get; set; }
        public string Price { get; set; }
        public Nullable<long> TotalOfViews { get; set; }
        public string CourseSummary { get; set; }
        public string ContentIntroduce { get; set; }
        public string ContentLearnByVideo { get; set; }
        public string ContentPreferentialPolicy { get; set; }
        public string ContentEvaluting { get; set; }
        public string ContentTemplateProject { get; set; }
        public string TitleIntroduceVideo { get; set; }
        public string ContentIntroduceVideo { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public bool IsApproved { get; set; }
        public Nullable<System.Guid> ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> RankVip { get; set; }
    }
}