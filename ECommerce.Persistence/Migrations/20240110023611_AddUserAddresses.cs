using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUsedCoupons_CouponId",
                table: "UserUsedCoupons",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AddressId",
                table: "UserAddresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUsedCoupon_CouponId",
                table: "UserUsedCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUsedCoupon_CouponId",
                table: "UserUsedCoupons");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_UserUsedCoupons_CouponId",
                table: "UserUsedCoupons");
        }
    }
}
