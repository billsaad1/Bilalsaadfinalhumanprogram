using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Outcomes")]
    public class Outcome
    {
        [Key]
        public int OutcomeID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public string OutcomeDescription { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        public virtual IList<Output> Outputs { get; set; } // Changed from ICollection to IList

        public Outcome()
        {
            Outputs = new List<Output>(); // Changed from HashSet to List
        }
    }
}
