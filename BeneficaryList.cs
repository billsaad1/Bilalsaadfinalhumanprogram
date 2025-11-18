using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("BeneficiaryLists")]
    public class BeneficiaryList
    {
        [Key]
        public int BeneficiaryListID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "List name is required.")]
        [StringLength(255)]
        [DisplayName("List Name")]
        public string ListName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; } // NVARCHAR(MAX)

        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }

        // Navigation properties
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }

        public BeneficiaryList()
        {
            Beneficiaries = new HashSet<Beneficiary>();
            CreationDate = DateTime.UtcNow;
        }
    }
}
