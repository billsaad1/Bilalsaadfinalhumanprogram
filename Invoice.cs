using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public int POID { get; set; }
        public int SupplierID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmountDue { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("POID")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public Invoice()
        {
            Payments = new HashSet<Payment>();
        }
    }
}
