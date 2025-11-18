using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HumanitarianProjectManagement.Models; // Add this if PurchaseOrderItem is in this namespace

namespace HumanitarianProjectManagement.Models
{
    public class GoodsReceiptItem
    {
        [Key]
        public int GRItemID { get; set; }
        public int GRNID { get; set; }
        public int POItemID { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public string QualityStatus { get; set; }

        [ForeignKey("GRNID")]
        public virtual GoodsReceipt GoodsReceipt { get; set; }
        [ForeignKey("POItemID")]
        public virtual PurchaseOrderItem PurchaseOrderItem { get; set; }
    }
}
