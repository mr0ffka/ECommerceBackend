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
    [Migration("20240104194136_AddCouponCode")]
    partial class AddCouponCode
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

            modelBuilder.Entity("ECommerce.Domain.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PublicId" }, "IX_Address_PublicId")
                        .IsUnique();

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex(new[] { "PublicId" }, "IX_CartItem_PublicId")
                        .IsUnique();

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PublicId" }, "IX_Category_PublicId")
                        .IsUnique();

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.Coupon", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<int>("Percentage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.Property<DateTime>("ValidFromUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidToUtc")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Code" }, "IX_Coupon_Code")
                        .IsUnique();

                    b.HasIndex(new[] { "PublicId" }, "IX_Coupon_PublicId")
                        .IsUnique();

                    b.ToTable("Coupons", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.Example", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

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
                            DateCreatedUtc = new DateTime(2024, 1, 4, 19, 41, 35, 516, DateTimeKind.Utc).AddTicks(6783),
                            DateModifiedUtc = new DateTime(2024, 1, 4, 19, 41, 35, 516, DateTimeKind.Utc).AddTicks(6787),
                            Description = "Example description",
                            Name = "Example name",
                            PublicId = "da8e00f1-9504-4111-9701-eaa3eafa133d"
                        });
                });

            modelBuilder.Entity("ECommerce.Domain.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<long>("CouponId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("PaymentId")
                        .HasColumnType("bigint");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CouponId");

                    b.HasIndex(new[] { "PublicId" }, "IX_Order_PublicId")
                        .IsUnique();

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.OrderHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex(new[] { "PublicId" }, "IX_OrderHistory_PublicId")
                        .IsUnique();

                    b.ToTable("OrderHistories", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex(new[] { "PublicId" }, "IX_OrderItem_PublicId")
                        .IsUnique();

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex(new[] { "PublicId" }, "IX_Payment_PublicId")
                        .IsUnique();

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateModifiedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("character(36)")
                        .HasDefaultValueSql("uuid_generate_v4()")
                        .IsFixedLength();

                    b.Property<int>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "PublicId" }, "IX_Product_PublicId")
                        .IsUnique();

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.CartItem", b =>
                {
                    b.HasOne("ECommerce.Domain.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_CartItem_ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Domain.Order", b =>
                {
                    b.HasOne("ECommerce.Domain.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK_Order_AddressId");

                    b.HasOne("ECommerce.Domain.Coupon", "Coupon")
                        .WithMany("Orders")
                        .HasForeignKey("CouponId")
                        .IsRequired()
                        .HasConstraintName("FK_Order_CouponId");

                    b.Navigation("Address");

                    b.Navigation("Coupon");
                });

            modelBuilder.Entity("ECommerce.Domain.OrderHistory", b =>
                {
                    b.HasOne("ECommerce.Domain.Order", "Order")
                        .WithMany("OrderHistories")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderHistory_OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ECommerce.Domain.OrderItem", b =>
                {
                    b.HasOne("ECommerce.Domain.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderItem_OrderId");

                    b.HasOne("ECommerce.Domain.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderItem_ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Domain.Payment", b =>
                {
                    b.HasOne("ECommerce.Domain.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("ECommerce.Domain.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ECommerce.Domain.Product", b =>
                {
                    b.HasOne("ECommerce.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ECommerce.Domain.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ECommerce.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerce.Domain.Coupon", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ECommerce.Domain.Order", b =>
                {
                    b.Navigation("OrderHistories");

                    b.Navigation("OrderItems");

                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Domain.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
