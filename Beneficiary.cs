using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Beneficiaries")]
    public class Beneficiary
    {
        [Key]
        public int BeneficiaryID { get; set; }

        [Required]
        public int BeneficiaryListID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(255)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(255)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string Gender { get; set; } // e.g., Male, Female, Other

        [StringLength(100)]
        [DisplayName("National ID")]
        public string NationalID { get; set; } // Unique

        [DisplayName("Address")]
        public string Address { get; set; } // NVARCHAR(MAX)

        [StringLength(50)]
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [DisplayName("Household Size")]
        public int? HouseholdSize { get; set; }

        [DisplayName("Vulnerability Criteria")]
        public string VulnerabilityCriteria { get; set; } // NVARCHAR(MAX)

        [DisplayName("Registration Date")]
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
        [ForeignKey("BeneficiaryListID")]
        public virtual BeneficiaryList BeneficiaryList { get; set; }
        //public virtual ICollection<StockTransaction> StockTransactions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<FollowUpVisit> FollowUpVisits { get; set; }


        public Beneficiary()
        {
            //StockTransactions = new HashSet<StockTransaction>();
            Feedbacks = new HashSet<Feedback>();
            FollowUpVisits = new HashSet<FollowUpVisit>();
            RegistrationDate = DateTime.UtcNow;
        }
    }
}
