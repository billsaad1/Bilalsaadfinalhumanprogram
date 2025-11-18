using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("FollowUpVisits")]
    public class FollowUpVisit
    {
        [Key]
        public int VisitID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [DisplayName("Beneficiary ID")]
        public int? BeneficiaryID { get; set; } // Optional

        [Required]
        [DisplayName("Visit Date")]
        public DateTime VisitDate { get; set; }

        [DisplayName("Visited By User ID")]
        public int? VisitedByUserID { get; set; } // User who conducted the visit

        [DisplayName("Visit Purpose")]
        public string VisitPurpose { get; set; } // NVARCHAR(MAX)

        [DisplayName("Observations")]
        public string Observations { get; set; } // NVARCHAR(MAX)

        [DisplayName("Action Items")]
        public string ActionItems { get; set; } // NVARCHAR(MAX)

        [DisplayName("Next Follow-Up Date")]
        public DateTime? NextFollowUpDate { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; } // NVARCHAR(MAX)

        // Navigation properties
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("BeneficiaryID")]
        public virtual Beneficiary Beneficiary { get; set; }

        [ForeignKey("VisitedByUserID")]
        public virtual User VisitedByUser { get; set; }

        public FollowUpVisit()
        {
            VisitDate = DateTime.UtcNow;
        }
    }
}
