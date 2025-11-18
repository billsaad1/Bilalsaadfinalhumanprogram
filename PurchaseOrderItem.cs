using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [DisplayName("Purchase ID (Budget Item)")]
        public int? PurchaseID { get; set; } // Link to a specific budgeted purchase item

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(255)]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }

        [Required]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Expected Delivery Date")]
        public DateTime? ExpectedDeliveryDate { get; set; }

        [DisplayName("Actual Delivery Date")]
        public DateTime? ActualDeliveryDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }

        [StringLength(100)]
        public string Status { get; set; } // e.g., Pending, Approved, Shipped, Delivered, Cancelled

        [DisplayName("Shipping Address")]
        public string ShippingAddress { get; set; } // NVARCHAR(MAX)

        [DisplayName("Billing Address")]
        public string BillingAddress { get; set; } // NVARCHAR(MAX)

        [DisplayName("Notes")]
        public string Notes { get; set; } // NVARCHAR(MAX)

        [DisplayName("Created By User ID")]
        public int? CreatedByUserID { get; set; }

        [DisplayName("Approved By User ID")]
        public int? ApprovedByUserID { get; set; }

        // Navigation properties
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("PurchaseID")]
        public virtual Purchase BudgetItemPurchase { get; set; } // Link to the specific Purchase item in Budgets table

        [ForeignKey("CreatedByUserID")]
        public virtual User CreatedByUser { get; set; }

        [ForeignKey("ApprovedByUserID")]
        public virtual User ApprovedByUser { get; set; }

        public virtual ICollection<StockTransaction> StockTransactions { get; set; }


        public PurchaseOrder()
        {
            StockTransactions = new HashSet<StockTransaction>();
            OrderDate = DateTime.UtcNow;
        }
    }
}
