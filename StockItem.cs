using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("StockItems")]
    public class StockItem
    {
        [Key]
        public int StockItemID { get; set; }

        [Required(ErrorMessage = "Item name is required.")]
        [StringLength(255)]
        [DisplayName("Item Name")]
        public string ItemName { get; set; } // Unique

        [DisplayName("Description")]
        public string Description { get; set; } // NVARCHAR(MAX)

        [StringLength(100)]
        [DisplayName("Unit of Measure")]
        public string UnitOfMeasure { get; set; }

        [Required]
        [DisplayName("Current Quantity")]
        public int CurrentQuantity { get; set; } = 0;

        [DisplayName("Min Stock Level")]
        public int MinStockLevel { get; set; } = 0;

        [DisplayName("Max Stock Level")]
        public int? MaxStockLevel { get; set; }

        [DisplayName("Last Stock Update")]
        public DateTime LastStockUpdate { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; } // NVARCHAR(MAX)

        // Navigation property
        public virtual ICollection<StockTransaction> StockTransactions { get; set; }

        public StockItem()
        {
            StockTransactions = new HashSet<StockTransaction>();
            LastStockUpdate = DateTime.UtcNow;
        }
    }
}
