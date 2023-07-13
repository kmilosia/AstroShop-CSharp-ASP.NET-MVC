using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroShop.Data.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartElement",
                columns: table => new
                {
                    IDCartElement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCartSession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDProduct = table.Column<int>(type: "int", nullable: false),
                    ProductIDProduct = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartElement", x => x.IDCartElement);
                    table.ForeignKey(
                        name: "FK_CartElement_Product_ProductIDProduct",
                        column: x => x.ProductIDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartElement_ProductIDProduct",
                table: "CartElement",
                column: "ProductIDProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartElement");
        }
    }
}
