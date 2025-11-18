using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Salaries")]
    public class Salary
    {
        [Key]
        public int SalaryID { get; set; }

        [Required]
        public int BudgetID { get; set; }

        [Required(ErrorMessage = "Position title is required.")]
        [StringLength(255)]
        [DisplayName("Position Title")]
        public string PositionTitle { get; set; }

        [StringLength(255)]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; } // Optional

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Monthly Salary")]
        public decimal MonthlySalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [DisplayName("Number of Months")]
        public decimal NumberOfMonths { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "decimal(20, 4)")] // Adjusted precision to accommodate multiplication
        [DisplayName("Total Salary Amount")]
        public decimal TotalSalaryAmount { get; private set; } // Computed in DB

        [DisplayName("Notes")]
        public string Notes { get; set; } // NVARCHAR(MAX)

        // Navigation property
        [ForeignKey("BudgetID")]
        public virtual Budget Budget { get; set; }
    }
}
