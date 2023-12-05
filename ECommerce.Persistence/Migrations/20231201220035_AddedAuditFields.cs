using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Examples",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Examples",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedBy", "DateCreatedUtc", "DateModifiedUtc", "ModifiedBy" },
                values: new object[] { null, new DateTime(2023, 12, 1, 22, 0, 35, 28, DateTimeKind.Utc).AddTicks(8374), new DateTime(2023, 12, 1, 22, 0, 35, 28, DateTimeKind.Utc).AddTicks(8384), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Examples");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Examples");

            migrationBuilder.UpdateData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreatedUtc", "DateModifiedUtc" },
                values: new object[] { new DateTime(2023, 12, 1, 17, 19, 24, 300, DateTimeKind.Utc).AddTicks(8070), new DateTime(2023, 12, 1, 17, 19, 24, 300, DateTimeKind.Utc).AddTicks(8076) });
        }
    }
}
