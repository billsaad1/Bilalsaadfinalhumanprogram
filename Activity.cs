using System.Collections.Generic; // Added for completeness, though not strictly needed by current Activity props
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Activities")]
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }

        [Required]
        public int OutputID { get; set; }

        [Required]
        public string ActivityDescription { get; set; }

        // Could be a JSON string or CSV for storing ticked months, e.g., "Jan/23,Mar/23"
        public string PlannedMonths { get; set; }

        // Constructor can be added if any collections need initialization in the future
        // public Activity()
        // {
        // }

        // Navigation property to Output
        [ForeignKey("OutputID")]
        public virtual Output Output { get; set; }
    }
}
