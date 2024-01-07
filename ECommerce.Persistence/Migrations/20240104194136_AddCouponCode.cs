using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCouponCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Coupons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreatedUtc", "DateModifiedUtc" },
                values: new object[] { new DateTime(2024, 1, 4, 19, 41, 35, 516, DateTimeKind.Utc).AddTicks(6783), new DateTime(2024, 1, 4, 19, 41, 35, 516, DateTimeKind.Utc).AddTicks(6787) });

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_Code",
                table: "Coupons",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Coupon_Code",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Coupons");

            migrationBuilder.UpdateData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreatedUtc", "DateModifiedUtc" },
                values: new object[] { new DateTime(2024, 1, 4, 0, 9, 4, 499, DateTimeKind.Utc).AddTicks(797), new DateTime(2024, 1, 4, 0, 9, 4, 499, DateTimeKind.Utc).AddTicks(803) });
        }
    }
}
