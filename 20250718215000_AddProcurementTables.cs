using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanitarianProjectManagement.Migrations
{
    public partial class AddProcurementTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    PaymentTerms = table.Column<string>(maxLength: 100, nullable: true),
                    Category = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Unit = table.Column<string>(maxLength: 50, nullable: true),
                    DefaultPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SKU = table.Column<string>(maxLength: 100, nullable: true),
                    Category = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequisitions",
                columns: table => new
                {
                    PRID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    RequestedByUserID = table.Column<int>(nullable: false),
                    Department = table.Column<string>(maxLength: 255, nullable: true),
                    BudgetCode = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    ApprovalByUserID = table.Column<int>(nullable: true),
                    ApprovalDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequisitions", x => x.PRID);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitions_Users_RequestedByUserID",
                        column: x => x.RequestedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitions_Users_ApprovalByUserID",
                        column: x => x.ApprovalByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequisitionItems",
                columns: table => new
                {
                    PRItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequisitionItems", x => x.PRItemID);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionItems_PurchaseRequisitions_PRID",
                        column: x => x.PRID,
                        principalTable: "PurchaseRequisitions",
                        principalColumn: "PRID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    POID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRID = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    SupplierID = table.Column<int>(nullable: false),
                    IssuedByUserID = table.Column<int>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    ShippingAddress = table.Column<string>(maxLength: 500, nullable: true),
                    BillingAddress = table.Column<string>(maxLength: 500, nullable: true),
                    PaymentTerms = table.Column<string>(maxLength: 100, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.POID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_PurchaseRequisitions_PRID",
                        column: x => x.PRID,
                        principalTable: "PurchaseRequisitions",
                        principalColumn: "PRID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_IssuedByUserID",
                        column: x => x.IssuedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    POItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.POItemID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_POID",
                        column: x => x.POID,
                        principalTable: "PurchaseOrders",
                        principalColumn: "POID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POID = table.Column<int>(nullable: false),
                    SupplierID = table.Column<int>(nullable: false),
                    InvoiceNumber = table.Column<string>(maxLength: 100, nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalAmountDue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_PurchaseOrders_POID",
                        column: x => x.POID,
                        principalTable: "PurchaseOrders",
                        principalColumn: "POID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceID = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PaymentMethod = table.Column<string>(maxLength: 100, nullable: true),
                    ReferenceNumber = table.Column<string>(maxLength: 255, nullable: true),
                    PaidByUserID = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_PaidByUserID",
                        column: x => x.PaidByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceipts",
                columns: table => new
                {
                    GRNID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POID = table.Column<int>(nullable: false),
                    ReceiptDate = table.Column<DateTime>(nullable: false),
                    ReceivedByUserID = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceipts", x => x.GRNID);
                    table.ForeignKey(
                        name: "FK_GoodsReceipts_PurchaseOrders_POID",
                        column: x => x.POID,
                        principalTable: "PurchaseOrders",
                        principalColumn: "POID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceipts_Users_ReceivedByUserID",
                        column: x => x.ReceivedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceiptItems",
                columns: table => new
                {
                    GRItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRNID = table.Column<int>(nullable: false),
                    POItemID = table.Column<int>(nullable: false),
                    ReceivedQuantity = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    QualityStatus = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiptItems", x => x.GRItemID);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptItems_GoodsReceipts_GRNID",
                        column: x => x.GRNID,
                        principalTable: "GoodsReceipts",
                        principalColumn: "GRNID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptItems_PurchaseOrderItems_POItemID",
                        column: x => x.POItemID,
                        principalTable: "PurchaseOrderItems",
                        principalColumn: "POItemID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptItems_GRNID",
                table: "GoodsReceiptItems",
                column: "GRNID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptItems_POItemID",
                table: "GoodsReceiptItems",
                column: "POItemID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipts_POID",
                table: "GoodsReceipts",
                column: "POID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipts_ReceivedByUserID",
                table: "GoodsReceipts",
                column: "ReceivedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_POID",
                table: "Invoices",
                column: "POID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierID",
                table: "Invoices",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceID",
                table: "Payments",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaidByUserID",
                table: "Payments",
                column: "PaidByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_POID",
                table: "PurchaseOrderItems",
                column: "POID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_ProductID",
                table: "PurchaseOrderItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_IssuedByUserID",
                table: "PurchaseOrders",
                column: "IssuedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PRID",
                table: "PurchaseOrders",
                column: "PRID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierID",
                table: "PurchaseOrders",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionItems_PRID",
                table: "PurchaseRequisitionItems",
                column: "PRID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionItems_ProductID",
                table: "PurchaseRequisitionItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitions_ApprovalByUserID",
                table: "PurchaseRequisitions",
                column: "ApprovalByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitions_RequestedByUserID",
                table: "PurchaseRequisitions",
                column: "RequestedByUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceiptItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "PurchaseRequisitionItems");

            migrationBuilder.DropTable(
                name: "GoodsReceipts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "PurchaseRequisitions");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
