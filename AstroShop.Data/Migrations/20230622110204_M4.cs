using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroShop.Data.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishlistElement",
                columns: table => new
                {
                    IDWishlistElement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDWishlistSession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDProduct = table.Column<int>(type: "int", nullable: false),
                    ProductIDProduct = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistElement", x => x.IDWishlistElement);
                    table.ForeignKey(
                        name: "FK_WishlistElement_Product_ProductIDProduct",
                        column: x => x.ProductIDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishlistElement_ProductIDProduct",
                table: "WishlistElement",
                column: "ProductIDProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishlistElement");
        }
    }
}
