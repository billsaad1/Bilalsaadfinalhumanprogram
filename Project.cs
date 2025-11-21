using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Removed: using HumanitarianProjectManagement;

namespace HumanitarianProjectManagement.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Project name is required.")]
        [StringLength(255)]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [StringLength(50)]
        [DisplayName("Project Code")]
        public string ProjectCode { get; set; } // Unique

        [DisplayName("Section ID")]
        public int? SectionID { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; } // NVARCHAR(MAX)

        [DisplayName("Overall Objective")]
        public string OverallObjective { get; set; } // NVARCHAR(MAX)

        [DisplayName("Manager User ID")]
        public int? ManagerUserID { get; set; }

        [StringLength(100)]
        public string Status { get; set; } // e.g., Planning, Active, Completed, On Hold

        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Total Budget")]
        public decimal? TotalBudget { get; set; }

        [StringLength(255)]
        public string Donor { get; set; }

        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Updated At")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("SectionID")]
        public virtual Section Section { get; set; }

        [ForeignKey("ManagerUserID")]
        public virtual User ManagerUser { get; set; }

        public virtual ICollection<BeneficiaryList> BeneficiaryLists { get; set; }
        public virtual ICollection<ProjectIndicator> ProjectIndicators { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        //public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ProjectReport> ProjectReports { get; set; }
        //public virtual ICollection<StockTransaction> StockTransactions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<FollowUpVisit> FollowUpVisits { get; set; }
        // Removed: public BindingList<BudgetSubCategory> BudgetSubCategories { get; set; }

        public virtual IList<Outcome> Outcomes { get; set; }
        public virtual ICollection<DetailedBudgetLine> DetailedBudgetLines { get; set; }


        public Project()
        {
            BeneficiaryLists = new HashSet<BeneficiaryList>();
            ProjectIndicators = new HashSet<ProjectIndicator>();
            Budgets = new HashSet<Budget>();
            //PurchaseOrders = new HashSet<PurchaseOrder>();
            ProjectReports = new HashSet<ProjectReport>();
            //StockTransactions = new HashSet<StockTransaction>();
            Feedbacks = new HashSet<Feedback>();
            FollowUpVisits = new HashSet<FollowUpVisit>();
            // Removed: BudgetSubCategories = new BindingList<BudgetSubCategory>();

            Outcomes = new List<Outcome>();
            DetailedBudgetLines = new HashSet<DetailedBudgetLine>();

            CreatedAt = DateTime.UtcNow;
        }
    }
}
