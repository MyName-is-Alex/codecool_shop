using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Codecool.CodecoolShop.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "Department", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Hardware", "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display.", "Tablet" },
                    { 2, "Hardware", "A phone, commonly shortened to phone, is a thin, flat mobile computer with a touchscreen display.", "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Digital content and services", "Amazon" },
                    { 2, "Everything you think of", "EMag" },
                    { 3, "Computers", "Lenovo" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Currency", "DefaultPrice", "Description", "Name", "ProductCategoryId", "SupplierId" },
                values: new object[,]
                {
                    { 1, "USD", 49.9m, "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", "Amazon Fire", 1, 1 },
                    { 2, "USD", 479.0m, "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", "Lenovo IdeaPad Miix 700", 1, 3 },
                    { 3, "USD", 89.0m, "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", "Amazon Fire HD 8", 1, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");
        }
    }
}
