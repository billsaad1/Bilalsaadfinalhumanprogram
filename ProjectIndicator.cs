using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("ProjectIndicators")]
    public class ProjectIndicator
    {
        [Key]
        public int ProjectIndicatorID { get; set; } // Renamed from IndicatorID

        [Required]
        public int ProjectID { get; set; }

        public int? OutputID { get; set; } // Foreign Key to Output, nullable

        [Required(ErrorMessage = "Indicator name is required.")]
        [DisplayName("Indicator Name")]
        public string IndicatorName { get; set; } // NVARCHAR(MAX)

        [DisplayName("Description")]
        public string Description { get; set; } // NVARCHAR(MAX)

        [StringLength(255)]
        [DisplayName("Overall Target Value (Textual)")] // Clarified purpose if TargetTotal is used for numbers
        public string TargetValue { get; set; }

        // Demographic Targets
        [DisplayName("Target Men")]
        public int TargetMen { get; set; }

        [DisplayName("Target Women")]
        public int TargetWomen { get; set; }

        [DisplayName("Target Boys")]
        public int TargetBoys { get; set; }

        [DisplayName("Target Girls")]
        public int TargetGirls { get; set; }

        [DisplayName("Target Total (Calculated or User-Entered)")]
        public int TargetTotal { get; set; } // Consider calculation logic elsewhere or make it purely user-entered

        [StringLength(255)]
        [DisplayName("Actual Value")]
        public string ActualValue { get; set; }

        [StringLength(100)]
        [DisplayName("Unit of Measure")]
        public string UnitOfMeasure { get; set; }

        [StringLength(255)]
        [DisplayName("Baseline Value")]
        public string BaselineValue { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Is Key Indicator")]
        public bool IsKeyIndicator { get; set; } = false;

        [DisplayName("Means of Verification")] // New Property
        public string MeansOfVerification { get; set; }

        // Navigation properties
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("OutputID")]
        public virtual Output Output { get; set; } // Navigation to Output

        public virtual ICollection<VerificationMean> VerificationMeans { get; set; }

        public ProjectIndicator()
        {
            VerificationMeans = new HashSet<VerificationMean>();
            // Initialize demographic targets to 0
            TargetMen = 0;
            TargetWomen = 0;
            TargetBoys = 0;
            TargetGirls = 0;
            TargetTotal = 0;
            MeansOfVerification = string.Empty; // Initialize new property
        }
    }
}
