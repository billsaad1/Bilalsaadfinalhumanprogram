using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    public class PurchaseRequisitionItem
    {
        [Key]
        public int PRItemID { get; set; }
        public int PRID { get; set; }
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; }

        [ForeignKey("PRID")]
        public virtual PurchaseRequisition PurchaseRequisition { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
