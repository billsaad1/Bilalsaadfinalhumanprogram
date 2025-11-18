using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HumanitarianProjectManagement.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PaymentTerms { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }

        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            Invoices = new HashSet<Invoice>();
        }
    }
}
