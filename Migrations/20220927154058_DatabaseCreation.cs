using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeProducts.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fridge_model",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fridge_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Default_quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fridge",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Owner_name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Model_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fridge", x => x.id);
                    table.ForeignKey(
                        name: "FK_fridge_fridge_model_Model_id",
                        column: x => x.Model_id,
                        principalTable: "fridge_model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fridge_products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fridge_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fridge_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_fridge_products_fridge_Fridge_id",
                        column: x => x.Fridge_id,
                        principalTable: "fridge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fridge_products_products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fridge_Model_id",
                table: "fridge",
                column: "Model_id");

            migrationBuilder.CreateIndex(
                name: "IX_fridge_products_Fridge_id",
                table: "fridge_products",
                column: "Fridge_id");

            migrationBuilder.CreateIndex(
                name: "IX_fridge_products_Product_id",
                table: "fridge_products",
                column: "Product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fridge_products");

            migrationBuilder.DropTable(
                name: "fridge");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "fridge_model");
        }
    }
}
