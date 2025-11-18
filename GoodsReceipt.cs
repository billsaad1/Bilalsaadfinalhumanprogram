using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    public class GoodsReceipt
    {
        [Key]
        public int GRNID { get; set; }
        public int POID { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int ReceivedByUserID { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("POID")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey("ReceivedByUserID")]
        public virtual User ReceivedByUser { get; set; }
        public virtual ICollection<GoodsReceiptItem> Items { get; set; }

        public GoodsReceipt()
        {
            Items = new HashSet<GoodsReceiptItem>();
        }
    }
}
