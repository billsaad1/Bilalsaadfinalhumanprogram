using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Outputs")]
    public class Output
    {
        [Key]
        public int OutputID { get; set; }

        [Required]
        public int OutcomeID { get; set; }

        [Required]
        public string OutputDescription { get; set; }

        [ForeignKey("OutcomeID")]
        public virtual Outcome Outcome { get; set; }

        public virtual IList<ProjectIndicator> ProjectIndicators { get; set; } // Changed from ICollection to IList
        public virtual IList<Activity> Activities { get; set; } // Changed from ICollection to IList

        public Output()
        {
            ProjectIndicators = new List<ProjectIndicator>(); // Changed from HashSet to List
            Activities = new List<Activity>(); // Changed from HashSet to List
        }
    }
}
