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
    [Migration("20240109040836_AddThumbnail")]
    partial class AddThumbnail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

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

                    b.HasKey("Id");

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

                    b.Property<DateTime>("ValidFromUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidToUtc")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Code" }, "IX_Coupon_Code")
                        .IsUnique();

                    b.ToTable("Coupons", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.File", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("ContentType")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Files", (string)null);
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

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CouponId");

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

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

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

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

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

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<int>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.ProductFile", b =>
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

                    b.Property<long>("FileId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsThumbnail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductFiles", (string)null);
                });

            modelBuilder.Entity("ECommerce.Domain.UserUsedCoupon", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserUsedCoupons", (string)null);
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

            modelBuilder.Entity("ECommerce.Domain.ProductFile", b =>
                {
                    b.HasOne("ECommerce.Domain.File", "File")
                        .WithMany("Products")
                        .HasForeignKey("FileId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductFile_FileId");

                    b.HasOne("ECommerce.Domain.Product", "Product")
                        .WithMany("Files")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductFile_ProductId");

                    b.Navigation("File");

                    b.Navigation("Product");
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

            modelBuilder.Entity("ECommerce.Domain.File", b =>
                {
                    b.Navigation("Products");
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

                    b.Navigation("Files");

                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
