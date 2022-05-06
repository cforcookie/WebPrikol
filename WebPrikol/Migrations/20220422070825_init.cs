using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPrikol.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionForigenKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Positions_PositionForigenKey",
                        column: x => x.PositionForigenKey,
                        principalTable: "Positions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quanity = table.Column<int>(type: "int", nullable: true),
                    Sum = table.Column<int>(type: "int", nullable: true),
                    SupplierForigenKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierForigenKey",
                        column: x => x.SupplierForigenKey,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    PurchaseForigenKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Purchases_PurchaseForigenKey",
                        column: x => x.PurchaseForigenKey,
                        principalTable: "Purchases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseForigenKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Purchases_WarehouseForigenKey",
                        column: x => x.WarehouseForigenKey,
                        principalTable: "Purchases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quanity = table.Column<int>(type: "int", nullable: true),
                    Sum = table.Column<int>(type: "int", nullable: true),
                    BuyersForigenKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffsForigenKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductsForigenKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Buyers_BuyersForigenKey",
                        column: x => x.BuyersForigenKey,
                        principalTable: "Buyers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductsForigenKey",
                        column: x => x.ProductsForigenKey,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Staffs_StaffsForigenKey",
                        column: x => x.StaffsForigenKey,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyersForigenKey",
                table: "Orders",
                column: "BuyersForigenKey");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsForigenKey",
                table: "Orders",
                column: "ProductsForigenKey");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StaffsForigenKey",
                table: "Orders",
                column: "StaffsForigenKey");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseForigenKey",
                table: "Products",
                column: "PurchaseForigenKey");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierForigenKey",
                table: "Purchases",
                column: "SupplierForigenKey");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PositionForigenKey",
                table: "Staffs",
                column: "PositionForigenKey");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_WarehouseForigenKey",
                table: "Warehouses",
                column: "WarehouseForigenKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
