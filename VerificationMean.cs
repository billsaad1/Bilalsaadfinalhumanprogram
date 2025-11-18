using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("VerificationMeans")]
    public class VerificationMean
    {
        [Key]
        public int VerificationMeanID { get; set; }

        [Required]
        public int IndicatorID { get; set; }

        [Required(ErrorMessage = "Mean description is required.")]
        [DisplayName("Mean Description")]
        public string MeanDescription { get; set; } // NVARCHAR(MAX)

        [StringLength(100)]
        public string Frequency { get; set; } // How often verification is done

        [StringLength(255)]
        [DisplayName("Responsible Party")]
        public string ResponsibleParty { get; set; }

        // Navigation property
        [ForeignKey("IndicatorID")]
        public virtual ProjectIndicator ProjectIndicator { get; set; }
    }
}
