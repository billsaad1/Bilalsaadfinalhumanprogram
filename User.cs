using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password hash is required.")]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [StringLength(50)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

        [DisplayName("Last Login")]
        public DateTime? LastLogin { get; set; }

        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Or GETDATE() equivalent

        // Navigation properties
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Project> ManagedProjects { get; set; } // Projects where this user is a manager
        public virtual ICollection<Budget> ApprovedBudgets { get; set; } // Budgets approved by this user
        //public virtual ICollection<PurchaseOrder> CreatedPurchaseOrders { get; set; }
        //public virtual ICollection<PurchaseOrder> ApprovedPurchaseOrders { get; set; }
        public virtual ICollection<ProjectReport> SubmittedProjectReports { get; set; }
        //public virtual ICollection<StockTransaction> RecordedStockTransactions { get; set; }
        public virtual ICollection<Feedback> RecordedFeedback { get; set; }
        public virtual ICollection<FollowUpVisit> ConductedFollowUpVisits { get; set; }


        public User()
        {
            UserRoles = new HashSet<UserRole>();
            ManagedProjects = new HashSet<Project>();
            ApprovedBudgets = new HashSet<Budget>();
            //CreatedPurchaseOrders = new HashSet<PurchaseOrder>();
            //ApprovedPurchaseOrders = new HashSet<PurchaseOrder>();
            SubmittedProjectReports = new HashSet<ProjectReport>();
            //RecordedStockTransactions = new HashSet<StockTransaction>();
            RecordedFeedback = new HashSet<Feedback>();
            ConductedFollowUpVisits = new HashSet<FollowUpVisit>();
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
