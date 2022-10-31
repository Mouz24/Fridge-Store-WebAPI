using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeProducts.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "id",
                keyValue: new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c052710-1703-47a2-bf65-742ed3762ca0", "695f3cee-60a6-4ab2-a041-d5a30c25b02e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4597b32-c4d0-45ac-9ede-bdab8604f1db", "ecb6066c-70b8-4f0c-81eb-ec9af34be75d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "id", "Fridge_id", "Product_id", "Quantity" },
                values: new object[] { new Guid("ae9042f1-379d-43eb-b7d3-57250f59c0a1"), new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"), new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c052710-1703-47a2-bf65-742ed3762ca0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4597b32-c4d0-45ac-9ede-bdab8604f1db");

            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "id",
                keyValue: new Guid("ae9042f1-379d-43eb-b7d3-57250f59c0a1"));

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "id", "Fridge_id", "Product_id", "Quantity" },
                values: new object[] { new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"), new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"), new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"), 1 });
        }
    }
}
