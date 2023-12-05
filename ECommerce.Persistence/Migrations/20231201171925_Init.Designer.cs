﻿// <auto-generated />
using System;
using ECommerce.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    [Migration("20231201171925_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Domain.Example", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PublicId" }, "IX_Example_PublicId")
                        .IsUnique();

                    b.ToTable("Examples");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateCreatedUtc = new DateTime(2023, 12, 1, 17, 19, 24, 300, DateTimeKind.Utc).AddTicks(8070),
                            DateModifiedUtc = new DateTime(2023, 12, 1, 17, 19, 24, 300, DateTimeKind.Utc).AddTicks(8076),
                            Description = "Example description",
                            Name = "Example name",
                            PublicId = "da8e00f1-9504-4111-9701-eaa3eafa133d"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
