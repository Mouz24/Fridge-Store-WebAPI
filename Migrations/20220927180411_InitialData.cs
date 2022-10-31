using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeProducts.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "fridge_model",
                columns: new[] { "id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca"), "ХМ 4209-000", 2020 },
                    { new Guid("87d708f9-dcf0-4191-986a-04f01a94eefd"), "ХМ-6024-031", 2021 }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "Default_quantity", "Name" },
                values: new object[,]
                {
                    { new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"), 3, "Cucumber" },
                    { new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"), 2, "Cheese" },
                    { new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"), 2, "Beef" },
                    { new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"), 10, "Egg" },
                    { new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"), 7, "Sausage" },
                    { new Guid("e52efc08-e592-4f81-a0b5-b570a7604b09"), 4, "Tomatoe" }
                });

            migrationBuilder.InsertData(
                table: "fridge",
                columns: new[] { "id", "Model_id", "Name", "Owner_name" },
                values: new object[] { new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"), new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca"), "Atlant", "Alexandr" });

            migrationBuilder.InsertData(
                table: "fridge",
                columns: new[] { "id", "Model_id", "Name", "Owner_name" },
                values: new object[] { new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"), new Guid("87d708f9-dcf0-4191-986a-04f01a94eefd"), "Atlant", "Maxim" });

            migrationBuilder.InsertData(
                table: "fridge_products",
                columns: new[] { "id", "Fridge_id", "Product_id", "Quantity" },
                values: new object[,]
                {
                    { new Guid("1117aee8-cfc5-4a7d-85bd-3b869b334a21"), new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"), new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"), 6 },
                    { new Guid("1e0c50ea-8503-4b85-b86a-92077130249c"), new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"), new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"), 7 },
                    { new Guid("36e8b9dd-cbfa-4ac3-9273-b20ebeb226b5"), new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"), new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"), 4 },
                    { new Guid("a7b6eaf4-7a70-482a-8a0a-1240ef0c3a63"), new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"), new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"), 0 },
                    { new Guid("d99726a5-b08a-4ace-adfc-eec6c2c60f8d"), new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"), new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"), 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "id",
                keyValue: new Guid("1117aee8-cfc5-4a7d-85bd-3b869b334a21"));

            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "id",
                keyValue: new Guid("1e0c50ea-8503-4b85-b86a-92077130249c"));

            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "id",
                keyValue: new Guid("36e8b9dd-cbfa-4ac3-9273-b20ebeb226b5"));

            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "id",
                keyValue: new Guid("a7b6eaf4-7a70-482a-8a0a-1240ef0c3a63"));

            migrationBuilder.DeleteData(
                table: "fridge_products",
                keyColumn: "id",
                keyValue: new Guid("d99726a5-b08a-4ace-adfc-eec6c2c60f8d"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e52efc08-e592-4f81-a0b5-b570a7604b09"));

            migrationBuilder.DeleteData(
                table: "fridge",
                keyColumn: "id",
                keyValue: new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"));

            migrationBuilder.DeleteData(
                table: "fridge",
                keyColumn: "id",
                keyValue: new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"));

            migrationBuilder.DeleteData(
                table: "fridge_model",
                keyColumn: "id",
                keyValue: new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca"));

            migrationBuilder.DeleteData(
                table: "fridge_model",
                keyColumn: "id",
                keyValue: new Guid("87d708f9-dcf0-4191-986a-04f01a94eefd"));
        }
    }
}
