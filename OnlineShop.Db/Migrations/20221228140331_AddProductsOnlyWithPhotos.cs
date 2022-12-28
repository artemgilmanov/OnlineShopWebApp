using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddProductsOnlyWithPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdDateTime",
                table: "Carts",
                newName: "CreatedDateTime");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("d9903536-8872-47e5-8915-14d25e1b8fe5"), 0m, null, "/images/product1.png", null },
                    { new Guid("df118537-7451-43d5-a2ec-82400b9bf2e2"), 0m, null, "/images/product2.png", null },
                    { new Guid("e55bb71b-17c9-4e60-92dc-d616e350d773"), 0m, null, "/images/product3.png", null },
                    { new Guid("b6e03337-352e-49c2-84a2-2ec616190248"), 0m, null, "/images/product4.png", null },
                    { new Guid("a83c8d84-f929-4119-a8ab-137dfec3654d"), 0m, null, "/images/product5.png", null },
                    { new Guid("b52b1c28-4b81-4f81-8839-fc4e017eda30"), 0m, null, "/images/product6.png", null },
                    { new Guid("4c4e9d04-f200-4ddc-9251-4bc4ecd3f86a"), 0m, null, "/images/product7.png", null },
                    { new Guid("38cbfabe-b5f4-43c5-ac34-f2d3f46a6962"), 0m, null, "/images/product8.png", null },
                    { new Guid("49a6e5f2-a388-4163-bec9-4ead3e829494"), 0m, null, "/images/product9.png", null },
                    { new Guid("7b62cd0d-1f08-4f33-bc06-559d9d0fb7e5"), 0m, null, "/images/product10.png", null },
                    { new Guid("6ab8bc80-a1c8-4916-ba91-b53f9f42c011"), 0m, null, "/images/product11.png", null },
                    { new Guid("aa263bfe-875d-422f-a3c9-539e2c863f68"), 0m, null, "/images/product12.png", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("38cbfabe-b5f4-43c5-ac34-f2d3f46a6962"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("49a6e5f2-a388-4163-bec9-4ead3e829494"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c4e9d04-f200-4ddc-9251-4bc4ecd3f86a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ab8bc80-a1c8-4916-ba91-b53f9f42c011"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b62cd0d-1f08-4f33-bc06-559d9d0fb7e5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a83c8d84-f929-4119-a8ab-137dfec3654d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa263bfe-875d-422f-a3c9-539e2c863f68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b52b1c28-4b81-4f81-8839-fc4e017eda30"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6e03337-352e-49c2-84a2-2ec616190248"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9903536-8872-47e5-8915-14d25e1b8fe5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df118537-7451-43d5-a2ec-82400b9bf2e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e55bb71b-17c9-4e60-92dc-d616e350d773"));

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "Carts",
                newName: "createdDateTime");
        }
    }
}
