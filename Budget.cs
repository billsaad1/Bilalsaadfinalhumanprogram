using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Budgets")]
    public class Budget
    {
        [Key]
        public int BudgetID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Budget name is required.")]
        [StringLength(255)]
        [DisplayName("Budget Name")]
        public string BudgetName { get; set; } = "Main Budget";

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        [StringLength(10)]
        public string Currency { get; set; } = "USD";

        [DisplayName("Notes")]
        public string Notes { get; set; } // NVARCHAR(MAX)

        [DisplayName("Version Number")]
        public int VersionNumber { get; set; } = 1;

        [DisplayName("Is Approved")]
        public bool IsApproved { get; set; } = false;

        [DisplayName("Approved By User ID")]
        public int? ApprovedByUserID { get; set; }

        [DisplayName("Approval Date")]
        public DateTime? ApprovalDate { get; set; }

        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("ApprovedByUserID")]
        public virtual User ApprovedByUser { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

        public Budget()
        {
            Salaries = new HashSet<Salary>();
            Activities = new HashSet<Activity>();
            Purchases = new HashSet<Purchase>();
            CreatedAt = DateTime.UtcNow;
            BudgetName = "Main Budget";
            Currency = "USD";
            VersionNumber = 1;
            IsApproved = false;
        }
    }
}
