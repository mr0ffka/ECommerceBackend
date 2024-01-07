using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovePublicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_PublicId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PublicId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Order_PublicId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_PublicId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_PublicId",
                table: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX_Example_PublicId",
                table: "Examples");

            migrationBuilder.DropIndex(
                name: "IX_Coupon_PublicId",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Category_PublicId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_PublicId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_Address_PublicId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Examples");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Addresses");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Products",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Payments",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Orders",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "OrderItems",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "OrderHistories",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Examples",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Coupons",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "(uuid_generate_v4())::character(36)");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Categories",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "(uuid_generate_v4())::character(36)");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "CartItems",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Addresses",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.InsertData(
                table: "Examples",
                columns: new[] { "Id", "CreatedBy", "DateCreatedUtc", "DateModifiedUtc", "Description", "ModifiedBy", "Name", "PublicId" },
                values: new object[] { 1L, null, new DateTime(2024, 1, 5, 1, 9, 17, 933, DateTimeKind.Utc).AddTicks(2404), new DateTime(2024, 1, 5, 1, 9, 17, 933, DateTimeKind.Utc).AddTicks(2409), "Example description", null, "Example name", "da8e00f1-9504-4111-9701-eaa3eafa133d" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_PublicId",
                table: "Products",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PublicId",
                table: "Payments",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_PublicId",
                table: "Orders",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_PublicId",
                table: "OrderItems",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_PublicId",
                table: "OrderHistories",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Example_PublicId",
                table: "Examples",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_PublicId",
                table: "Coupons",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_PublicId",
                table: "Categories",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_PublicId",
                table: "CartItems",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_PublicId",
                table: "Addresses",
                column: "PublicId",
                unique: true);
        }
    }
}
