using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("StockTransactions")]
    public class StockTransaction
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        public int StockItemID { get; set; }

        [Required(ErrorMessage = "Transaction type is required.")]
        [StringLength(50)] // 'IN', 'OUT', 'ADJUSTMENT'
        [DisplayName("Transaction Type")]
        public string TransactionType { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [DisplayName("Project ID")]
        public int? ProjectID { get; set; } // Associated project

        [DisplayName("Purchase Order ID")]
        public int? PurchaseOrderID { get; set; } // If stock is incoming via a PO

        [DisplayName("Activity ID")]
        public int? ActivityID { get; set; } // If stock is used for a specific activity

        [DisplayName("Beneficiary ID")]
        public int? BeneficiaryID { get; set; } // If stock is distributed to a beneficiary

        [StringLength(255)]
        [DisplayName("Distributed To")]
        public string DistributedTo { get; set; } // Could be a beneficiary, another project, etc.

        [DisplayName("Reason")]
        public string Reason { get; set; } // NVARCHAR(MAX)

        [DisplayName("Recorded By User ID")]
        public int? RecordedByUserID { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; } // NVARCHAR(MAX)

        // Navigation properties
        [ForeignKey("StockItemID")]
        public virtual StockItem StockItem { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("PurchaseOrderID")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [ForeignKey("ActivityID")]
        public virtual Activity Activity { get; set; }

        [ForeignKey("BeneficiaryID")]
        public virtual Beneficiary Beneficiary { get; set; }

        [ForeignKey("RecordedByUserID")]
        public virtual User RecordedByUser { get; set; }

        public StockTransaction()
        {
            TransactionDate = DateTime.UtcNow;
        }
    }
}
