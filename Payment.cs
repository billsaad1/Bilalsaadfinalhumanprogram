using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }
        public int? PaidByUserID { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("InvoiceID")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey("PaidByUserID")]
        public virtual User PaidByUser { get; set; }
    }
}
