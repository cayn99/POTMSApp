using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingComplete",
                columns: table => new
                {
                    AccountingCompleteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Penalty = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingComplete", x => x.AccountingCompleteId);
                });

            migrationBuilder.CreateTable(
                name: "Coa",
                columns: table => new
                {
                    CoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCopy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InspectionReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coa", x => x.CoaId);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateInspected = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inspector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAccepted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.InspectionId);
                });

            migrationBuilder.CreateTable(
                name: "OrderReceived",
                columns: table => new
                {
                    OrderReceivedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDays = table.Column<int>(type: "int", nullable: false),
                    ExtensionLetter = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReceived", x => x.OrderReceivedId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RecordNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FundSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestNumber = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Particulars = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requestor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RecordNumber);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountingApprovals",
                columns: table => new
                {
                    AccountingApprovalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FirstPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThirdPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FourthPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AccountingCompleteId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingApprovals", x => x.AccountingApprovalId);
                    table.ForeignKey(
                        name: "FK_AccountingApprovals_AccountingComplete_AccountingCompleteId",
                        column: x => x.AccountingCompleteId,
                        principalTable: "AccountingComplete",
                        principalColumn: "AccountingCompleteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDeliveries",
                columns: table => new
                {
                    OrderDeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conforme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderReceivedId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDeliveries", x => x.OrderDeliveryId);
                    table.ForeignKey(
                        name: "FK_OrderDeliveries_OrderReceived_OrderReceivedId",
                        column: x => x.OrderReceivedId,
                        principalTable: "OrderReceived",
                        principalColumn: "OrderReceivedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    OrderDeliveryId = table.Column<int>(type: "int", nullable: false),
                    AccountingApprovalId = table.Column<int>(type: "int", nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    CoaId = table.Column<int>(type: "int", nullable: false),
                    AccountingApprovalId1 = table.Column<int>(type: "int", nullable: true),
                    AccountingCompleteId = table.Column<int>(type: "int", nullable: true),
                    CoaId1 = table.Column<int>(type: "int", nullable: true),
                    InspectionId1 = table.Column<int>(type: "int", nullable: true),
                    OrderDeliveryId1 = table.Column<int>(type: "int", nullable: true),
                    OrderReceivedId = table.Column<int>(type: "int", nullable: true),
                    RequestRecordNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_AccountingApprovals_AccountingApprovalId",
                        column: x => x.AccountingApprovalId,
                        principalTable: "AccountingApprovals",
                        principalColumn: "AccountingApprovalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_AccountingApprovals_AccountingApprovalId1",
                        column: x => x.AccountingApprovalId1,
                        principalTable: "AccountingApprovals",
                        principalColumn: "AccountingApprovalId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_AccountingComplete_AccountingCompleteId",
                        column: x => x.AccountingCompleteId,
                        principalTable: "AccountingComplete",
                        principalColumn: "AccountingCompleteId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Coa_CoaId",
                        column: x => x.CoaId,
                        principalTable: "Coa",
                        principalColumn: "CoaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Coa_CoaId1",
                        column: x => x.CoaId1,
                        principalTable: "Coa",
                        principalColumn: "CoaId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "InspectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Inspections_InspectionId1",
                        column: x => x.InspectionId1,
                        principalTable: "Inspections",
                        principalColumn: "InspectionId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_OrderDeliveries_OrderDeliveryId",
                        column: x => x.OrderDeliveryId,
                        principalTable: "OrderDeliveries",
                        principalColumn: "OrderDeliveryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_OrderDeliveries_OrderDeliveryId1",
                        column: x => x.OrderDeliveryId1,
                        principalTable: "OrderDeliveries",
                        principalColumn: "OrderDeliveryId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_OrderReceived_OrderReceivedId",
                        column: x => x.OrderReceivedId,
                        principalTable: "OrderReceived",
                        principalColumn: "OrderReceivedId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RecordNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Requests_RequestRecordNumber",
                        column: x => x.RequestRecordNumber,
                        principalTable: "Requests",
                        principalColumn: "RecordNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingApprovals_AccountingCompleteId",
                table: "AccountingApprovals",
                column: "AccountingCompleteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDeliveries_OrderReceivedId",
                table: "OrderDeliveries",
                column: "OrderReceivedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_AccountingApprovalId",
                table: "PurchaseOrders",
                column: "AccountingApprovalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_AccountingApprovalId1",
                table: "PurchaseOrders",
                column: "AccountingApprovalId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_AccountingCompleteId",
                table: "PurchaseOrders",
                column: "AccountingCompleteId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CoaId",
                table: "PurchaseOrders",
                column: "CoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CoaId1",
                table: "PurchaseOrders",
                column: "CoaId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_InspectionId",
                table: "PurchaseOrders",
                column: "InspectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_InspectionId1",
                table: "PurchaseOrders",
                column: "InspectionId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_OrderDeliveryId",
                table: "PurchaseOrders",
                column: "OrderDeliveryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_OrderDeliveryId1",
                table: "PurchaseOrders",
                column: "OrderDeliveryId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_OrderReceivedId",
                table: "PurchaseOrders",
                column: "OrderReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_RequestId",
                table: "PurchaseOrders",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_RequestRecordNumber",
                table: "PurchaseOrders",
                column: "RequestRecordNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AccountingApprovals");

            migrationBuilder.DropTable(
                name: "Coa");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "OrderDeliveries");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AccountingComplete");

            migrationBuilder.DropTable(
                name: "OrderReceived");
        }
    }
}
