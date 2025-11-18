using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Purchases")]
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }

        [Required]
        public int BudgetID { get; set; }

        [Required(ErrorMessage = "Item name is required.")]
        [StringLength(255)]
        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        [DisplayName("Item Specification")]
        public string ItemSpecification { get; set; } // NVARCHAR(MAX)

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Unit Cost")]
        public decimal UnitCost { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "decimal(20, 2)")] // Adjusted precision for multiplication
        [DisplayName("Total Cost")]
        public decimal TotalCost { get; private set; } // Computed in DB

        [StringLength(255)]
        public string Supplier { get; set; }

        [DisplayName("Purchase Date")]
        public DateTime? PurchaseDate { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; } // NVARCHAR(MAX)

        // Navigation property
        [ForeignKey("BudgetID")]
        public virtual Budget Budget { get; set; }

        // Navigation property for PurchaseOrders that might be linked to this specific budget item
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        public Purchase()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }
    }
}
