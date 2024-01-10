using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeHistoryTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentHistories",
                table: "PaymentHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistories",
                table: "OrderHistories");

            migrationBuilder.RenameTable(
                name: "PaymentHistories",
                newName: "PaymentHistory");

            migrationBuilder.RenameTable(
                name: "OrderHistories",
                newName: "OrderHistory");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_PaymentId",
                table: "PaymentHistory",
                newName: "IX_PaymentHistory_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistories_OrderId",
                table: "OrderHistory",
                newName: "IX_OrderHistory_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentHistory",
                table: "PaymentHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistory",
                table: "OrderHistory",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentHistory",
                table: "PaymentHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistory",
                table: "OrderHistory");

            migrationBuilder.RenameTable(
                name: "PaymentHistory",
                newName: "PaymentHistories");

            migrationBuilder.RenameTable(
                name: "OrderHistory",
                newName: "OrderHistories");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistory_PaymentId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistory_OrderId",
                table: "OrderHistories",
                newName: "IX_OrderHistories_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentHistories",
                table: "PaymentHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistories",
                table: "OrderHistories",
                column: "Id");
        }
    }
}
