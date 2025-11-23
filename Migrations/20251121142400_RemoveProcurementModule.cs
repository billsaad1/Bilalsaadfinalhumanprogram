using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanitarianProjectManagement.Migrations
{
    public partial class RemoveProcurementModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop tables
            migrationBuilder.DropTable(name: "Invoices");
            migrationBuilder.DropTable(name: "Payments");
            migrationBuilder.DropTable(name: "PurchaseOrderItems");
            migrationBuilder.DropTable(name: "PurchaseOrders");
            migrationBuilder.DropTable(name: "Purchases");
            migrationBuilder.DropTable(name: "StockItems");
            migrationBuilder.DropTable(name: "StockTransactions");
            migrationBuilder.DropTable(name: "Suppliers");
            migrationBuilder.DropTable(name: "GoodsReceiptItems");
            migrationBuilder.DropTable(name: "GoodsReceipts");
            migrationBuilder.DropTable(name: "PurchaseRequisitionItems");
            migrationBuilder.DropTable(name: "PurchaseRequisitions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Recreate tables
        }
    }
}
