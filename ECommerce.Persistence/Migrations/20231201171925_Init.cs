using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    PublicId = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    DateCreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateModifiedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Examples",
                columns: new[] { "Id", "DateCreatedUtc", "DateModifiedUtc", "Description", "Name", "PublicId" },
                values: new object[] { 1L, new DateTime(2023, 12, 1, 17, 19, 24, 300, DateTimeKind.Utc).AddTicks(8070), new DateTime(2023, 12, 1, 17, 19, 24, 300, DateTimeKind.Utc).AddTicks(8076), "Example description", "Example name", "da8e00f1-9504-4111-9701-eaa3eafa133d" });

            migrationBuilder.CreateIndex(
                name: "IX_Example_PublicId",
                table: "Examples",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examples");
        }
    }
}
