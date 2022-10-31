using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeProducts.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fridge_fridge_model_Model_id",
                table: "fridge");

            migrationBuilder.DropForeignKey(
                name: "FK_fridge_products_fridge_Fridge_id",
                table: "fridge_products");

            migrationBuilder.DropForeignKey(
                name: "FK_fridge_products_products_Product_id",
                table: "fridge_products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c052710-1703-47a2-bf65-742ed3762ca0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4597b32-c4d0-45ac-9ede-bdab8604f1db");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "Default_quantity",
                table: "products",
                newName: "DefaultQuantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "fridge_products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "fridge_products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Fridge_id",
                table: "fridge_products",
                newName: "FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_fridge_products_Product_id",
                table: "fridge_products",
                newName: "IX_fridge_products_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_fridge_products_Fridge_id",
                table: "fridge_products",
                newName: "IX_fridge_products_FridgeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "fridge_model",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "fridge_model",
                newName: "NameOfModel");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "fridge",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Owner_name",
                table: "fridge",
                newName: "OwnerName");

            migrationBuilder.RenameColumn(
                name: "Model_id",
                table: "fridge",
                newName: "ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_fridge_Model_id",
                table: "fridge",
                newName: "IX_fridge_ModelId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1cca9f40-bfb0-4240-b2ba-61ae67baaa3a", "fa3eac49-6ae7-4b34-8e34-c4f44276403d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c23155b-9144-42f5-8336-3d458d8aa72d", "3f61e815-2ba8-4cd5-a14e-be3888e46fc7", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_fridge_fridge_model_ModelId",
                table: "fridge",
                column: "ModelId",
                principalTable: "fridge_model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fridge_products_fridge_FridgeId",
                table: "fridge_products",
                column: "FridgeId",
                principalTable: "fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fridge_products_products_ProductId",
                table: "fridge_products",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fridge_fridge_model_ModelId",
                table: "fridge");

            migrationBuilder.DropForeignKey(
                name: "FK_fridge_products_fridge_FridgeId",
                table: "fridge_products");

            migrationBuilder.DropForeignKey(
                name: "FK_fridge_products_products_ProductId",
                table: "fridge_products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cca9f40-bfb0-4240-b2ba-61ae67baaa3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c23155b-9144-42f5-8336-3d458d8aa72d");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Product",
                table: "products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DefaultQuantity",
                table: "products",
                newName: "Default_quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fridge_products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "fridge_products",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "FridgeId",
                table: "fridge_products",
                newName: "Fridge_id");

            migrationBuilder.RenameIndex(
                name: "IX_fridge_products_ProductId",
                table: "fridge_products",
                newName: "IX_fridge_products_Product_id");

            migrationBuilder.RenameIndex(
                name: "IX_fridge_products_FridgeId",
                table: "fridge_products",
                newName: "IX_fridge_products_Fridge_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fridge_model",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NameOfModel",
                table: "fridge_model",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fridge",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OwnerName",
                table: "fridge",
                newName: "Owner_name");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "fridge",
                newName: "Model_id");

            migrationBuilder.RenameIndex(
                name: "IX_fridge_ModelId",
                table: "fridge",
                newName: "IX_fridge_Model_id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c052710-1703-47a2-bf65-742ed3762ca0", "695f3cee-60a6-4ab2-a041-d5a30c25b02e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4597b32-c4d0-45ac-9ede-bdab8604f1db", "ecb6066c-70b8-4f0c-81eb-ec9af34be75d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_fridge_fridge_model_Model_id",
                table: "fridge",
                column: "Model_id",
                principalTable: "fridge_model",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fridge_products_fridge_Fridge_id",
                table: "fridge_products",
                column: "Fridge_id",
                principalTable: "fridge",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fridge_products_products_Product_id",
                table: "fridge_products",
                column: "Product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
