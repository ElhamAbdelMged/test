using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTaskInvoice.Migrations
{
    public partial class createmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceHeader",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_NO = table.Column<string>(nullable: true),
                    StoreID = table.Column<int>(nullable: false),
                    IvoiceDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Taxes = table.Column<double>(nullable: false),
                    Net = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeader", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceHeaderID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    UnitID = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    quntity = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    Net = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_InvoiceHeader_InvoiceHeaderID",
                        column: x => x.InvoiceHeaderID,
                        principalTable: "InvoiceHeader",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "T_shirt" },
                    { 15, "blouse" },
                    { 14, "panties" },
                    { 13, "skirt" },
                    { 12, "heels" },
                    { 11, "dress" },
                    { 9, "pyjamas" },
                    { 10, "shoes" },
                    { 7, "shorts" },
                    { 6, "tracksuit" },
                    { 5, "jeans" },
                    { 4, "coat" },
                    { 3, "jacket" },
                    { 2, "sweater" },
                    { 8, "vest" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "MainStore" },
                    { 2, "SubStore" },
                    { 3, "NewStore" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Pound" },
                    { 2, "Dollar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceHeaderID",
                table: "InvoiceDetail",
                column: "InvoiceHeaderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "InvoiceHeader");
        }
    }
}
