using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    public class PurchaseRequisition
    {
        [Key]
        public int PRID { get; set; }
        public DateTime RequestDate { get; set; }
        public int RequestedByUserID { get; set; }
        public string Department { get; set; }
        public string BudgetCode { get; set; }
        public string Status { get; set; }
        public int? ApprovalByUserID { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("RequestedByUserID")]
        public virtual User RequestedByUser { get; set; }
        [ForeignKey("ApprovalByUserID")]
        public virtual User ApprovalByUser { get; set; }
        public virtual ICollection<PurchaseRequisitionItem> Items { get; set; }

        public PurchaseRequisition()
        {
            Items = new HashSet<PurchaseRequisitionItem>();
        }
    }
}
