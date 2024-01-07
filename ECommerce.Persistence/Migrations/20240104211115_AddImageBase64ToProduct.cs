using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddImageBase64ToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBase64Value",
                table: "Products",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreatedUtc", "DateModifiedUtc" },
                values: new object[] { new DateTime(2024, 1, 4, 21, 11, 14, 376, DateTimeKind.Utc).AddTicks(8591), new DateTime(2024, 1, 4, 21, 11, 14, 376, DateTimeKind.Utc).AddTicks(8599) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64Value",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreatedUtc", "DateModifiedUtc" },
                values: new object[] { new DateTime(2024, 1, 4, 19, 41, 35, 516, DateTimeKind.Utc).AddTicks(6783), new DateTime(2024, 1, 4, 19, 41, 35, 516, DateTimeKind.Utc).AddTicks(6787) });
        }
    }
}
