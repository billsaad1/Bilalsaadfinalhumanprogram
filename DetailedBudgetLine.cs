using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    public class DetailedBudgetLine
    {
        [Key]
        public Guid DetailedBudgetLineID { get; set; }

        [Required]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [Required]
        public BudgetCategoriesEnum Category { get; set; }

        public string Code { get; set; }

        [StringLength(255)]
        public string ItemName { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Duration { get; set; }
        public decimal PercentageChargedToCBPF { get; set; }
        public decimal TotalCost { get; set; }

        // Self-referencing parent-child relationship
        public Guid? ParentDetailedBudgetLineID { get; set; }
        [ForeignKey("ParentDetailedBudgetLineID")]
        public virtual DetailedBudgetLine ParentDetailedBudgetLine { get; set; }
        public virtual ICollection<DetailedBudgetLine> ChildDetailedBudgetLines { get; set; }

        // Itemized details (if needed)
        public virtual ICollection<ItemizedBudgetDetail> ItemizedDetails { get; set; }

        public DetailedBudgetLine()
        {
            DetailedBudgetLineID = Guid.NewGuid();
            Code = string.Empty;
            ItemName = string.Empty;
            Description = string.Empty;
            Unit = string.Empty;
            Quantity = 0;
            UnitCost = 0;
            Duration = 1;
            PercentageChargedToCBPF = 100;
            TotalCost = 0;
            ItemizedDetails = new HashSet<ItemizedBudgetDetail>();
            ChildDetailedBudgetLines = new HashSet<DetailedBudgetLine>();
        }
    }
}
