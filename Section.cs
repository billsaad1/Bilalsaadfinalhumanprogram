using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Sections")]
    public class Section
    {
        [Key]
        public int SectionID { get; set; }

        [Required(ErrorMessage = "Section name is required.")]
        [StringLength(255)]
        [DisplayName("Section Name")]
        public string SectionName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; } // NVARCHAR(MAX) -> string

        // Navigation property for Projects
        public virtual ICollection<Project> Projects { get; set; }

        public Section()
        {
            Projects = new HashSet<Project>();
        }
    }
}
