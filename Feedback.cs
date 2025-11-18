using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        [DisplayName("Project ID")]
        public int? ProjectID { get; set; }

        [DisplayName("Beneficiary ID")]
        public int? BeneficiaryID { get; set; }

        [Required]
        [DisplayName("Feedback Date")]
        public DateTime FeedbackDate { get; set; }

        [StringLength(255)]
        [DisplayName("Feedback Source")]
        public string FeedbackSource { get; set; } // e.g., Hotline, Field Visit, Suggestion Box

        [StringLength(100)]
        [DisplayName("Feedback Type")]
        public string FeedbackType { get; set; } // e.g., Complaint, Suggestion, Appreciation

        [Required(ErrorMessage = "Feedback details are required.")]
        [DisplayName("Details")]
        public string Details { get; set; } // NVARCHAR(MAX)

        [StringLength(255)]
        [DisplayName("Submitted By")]
        public string SubmittedBy { get; set; } // Name of person submitting

        [StringLength(255)]
        [DisplayName("Contact Info")]
        public string ContactInfo { get; set; } // Phone/email of submitter

        [StringLength(100)]
        public string Status { get; set; } = "Received"; // e.g., Received, Under Review, Addressed, Closed

        [StringLength(50)]
        public string Priority { get; set; } // e.g., High, Medium, Low

        [DisplayName("Recorded By User ID")]
        public int? RecordedByUserID { get; set; }

        [DisplayName("Resolution Details")]
        public string ResolutionDetails { get; set; } // NVARCHAR(MAX)

        [DisplayName("Resolution Date")]
        public DateTime? ResolutionDate { get; set; }

        // Navigation properties
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("BeneficiaryID")]
        public virtual Beneficiary Beneficiary { get; set; }

        [ForeignKey("RecordedByUserID")]
        public virtual User RecordedByUser { get; set; }

        public Feedback()
        {
            FeedbackDate = DateTime.UtcNow;
            Status = "Received";
        }
    }
}
