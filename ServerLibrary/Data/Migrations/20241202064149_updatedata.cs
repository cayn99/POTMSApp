using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FirstPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThirdPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FourthPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingApprovals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conforme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDeliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Particulars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requestor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokenInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokenInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AllAccountingComplete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Penalty = table.Column<bool>(type: "bit", nullable: false),
                    AccountingApprovalId = table.Column<int>(type: "int", nullable: false),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllAccountingComplete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllAccountingComplete_AccountingApprovals_AccountingApprovalId",
                        column: x => x.AccountingApprovalId,
                        principalTable: "AccountingApprovals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllAccountingComplete_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllCoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCopy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InspectionReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllCoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllCoa_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateInspected = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inspector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAccepted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersReceived",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDays = table.Column<int>(type: "int", nullable: false),
                    ExtensionLetterFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ExtensionLetterFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDeliveryId = table.Column<int>(type: "int", nullable: false),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersReceived", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersReceived_OrderDeliveries_OrderDeliveryId",
                        column: x => x.OrderDeliveryId,
                        principalTable: "OrderDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersReceived_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Procurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDays = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllAccountingComplete_AccountingApprovalId",
                table: "AllAccountingComplete",
                column: "AccountingApprovalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllAccountingComplete_PurchaseRequestId",
                table: "AllAccountingComplete",
                column: "PurchaseRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllCoa_PurchaseRequestId",
                table: "AllCoa",
                column: "PurchaseRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_PurchaseRequestId",
                table: "Inspections",
                column: "PurchaseRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersReceived_OrderDeliveryId",
                table: "OrdersReceived",
                column: "OrderDeliveryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersReceived_PurchaseRequestId",
                table: "OrdersReceived",
                column: "PurchaseRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseRequestId",
                table: "PurchaseOrders",
                column: "PurchaseRequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllAccountingComplete");

            migrationBuilder.DropTable(
                name: "AllCoa");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "OrdersReceived");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "RefreshTokenInfos");

            migrationBuilder.DropTable(
                name: "SystemRoles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AccountingApprovals");

            migrationBuilder.DropTable(
                name: "OrderDeliveries");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");
        }
    }
}
