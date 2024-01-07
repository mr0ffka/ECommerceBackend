using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UUIDPublicIdTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Coupons",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "(uuid_generate_v4())::character(36)",
                oldClrType: typeof(string),
                oldType: "character(36)",
                oldFixedLength: true,
                oldMaxLength: 36,
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Categories",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "(uuid_generate_v4())::character(36)",
                oldClrType: typeof(string),
                oldType: "character(36)",
                oldFixedLength: true,
                oldMaxLength: 36,
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.UpdateData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreatedUtc", "DateModifiedUtc" },
                values: new object[] { new DateTime(2024, 1, 5, 1, 9, 17, 933, DateTimeKind.Utc).AddTicks(2404), new DateTime(2024, 1, 5, 1, 9, 17, 933, DateTimeKind.Utc).AddTicks(2409) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Coupons",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "character(36)",
                oldFixedLength: true,
                oldMaxLength: 36,
                oldDefaultValueSql: "(uuid_generate_v4())::character(36)");

            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Categories",
                type: "character(36)",
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "character(36)",
                oldFixedLength: true,
                oldMaxLength: 36,
                oldDefaultValueSql: "(uuid_generate_v4())::character(36)");

            migrationBuilder.UpdateData(
                table: "Examples",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreatedUtc", "DateModifiedUtc" },
                values: new object[] { new DateTime(2024, 1, 4, 23, 51, 54, 216, DateTimeKind.Utc).AddTicks(285), new DateTime(2024, 1, 4, 23, 51, 54, 216, DateTimeKind.Utc).AddTicks(290) });
        }
    }
}
