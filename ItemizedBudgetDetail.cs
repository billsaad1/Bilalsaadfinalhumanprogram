using System;

namespace HumanitarianProjectManagement.Models
{
    public class ItemizedBudgetDetail
    {
        public Guid ItemizedBudgetDetailID { get; set; }
        public Guid ParentBudgetLineID { get; set; } // Links to DetailedBudgetLine
        public virtual DetailedBudgetLine ParentBudgetLine { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalCost { get; private set; }

        public ItemizedBudgetDetail()
        {
            ItemizedBudgetDetailID = Guid.NewGuid();
            // Initialize other properties as needed, or leave to defaults
            Description = string.Empty;
        }

        public void UpdateTotalCost()
        {
            TotalCost = Quantity * UnitPrice;
        }
    }
}
