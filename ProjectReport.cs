using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("ProjectReports")]
    public class ProjectReport
    {
        [Key]
        public int ReportID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Report title is required.")]
        [StringLength(255)]
        [DisplayName("Report Title")]
        public string ReportTitle { get; set; }

        [StringLength(100)]
        [DisplayName("Report Type")]
        public string ReportType { get; set; } // e.g., Progress, Financial, Final

        [DisplayName("Reporting Period Start Date")]
        public DateTime? ReportingPeriodStartDate { get; set; }

        [DisplayName("Reporting Period End Date")]
        public DateTime? ReportingPeriodEndDate { get; set; }

        [DisplayName("Submission Date")]
        public DateTime SubmissionDate { get; set; }

        [DisplayName("Submitted By User ID")]
        public int? SubmittedByUserID { get; set; }

        [DisplayName("Executive Summary")]
        public string ExecutiveSummary { get; set; } // NVARCHAR(MAX)

        [DisplayName("Achievements")]
        public string Achievements { get; set; } // NVARCHAR(MAX)

        [DisplayName("Challenges")]
        public string Challenges { get; set; } // NVARCHAR(MAX)

        [DisplayName("Lessons Learned")]
        public string LessonsLearned { get; set; } // NVARCHAR(MAX)

        [DisplayName("Financial Summary")]
        public string FinancialSummary { get; set; } // NVARCHAR(MAX)

        [StringLength(260)] // Max path length often an issue
        [DisplayName("File Path")]
        public string FilePath { get; set; } // NVARCHAR(MAX) in DB, but file paths have limits

        // Navigation properties
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("SubmittedByUserID")]
        public virtual User SubmittedByUser { get; set; }

        public ProjectReport()
        {
            SubmissionDate = DateTime.UtcNow;
        }
    }
}
