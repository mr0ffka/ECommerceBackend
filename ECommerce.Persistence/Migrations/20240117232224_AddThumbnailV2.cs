using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddThumbnailV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ThumbnailId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ThumbnailId",
                table: "Products",
                column: "ThumbnailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Files_ThumbnailId",
                table: "Products",
                column: "ThumbnailId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Files_ThumbnailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ThumbnailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Products");
        }
    }
}
