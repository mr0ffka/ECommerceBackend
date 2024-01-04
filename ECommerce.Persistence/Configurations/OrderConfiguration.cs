using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasIndex(x => x.PublicId, "IX_Order_PublicId")
                .IsUnique();

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder
                .Property(e => e.PublicId)
                .HasMaxLength(36)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsFixedLength();

            builder.Property(q => q.TotalPrice)
                .IsRequired();

            builder.Property(q => q.Status)
                .IsRequired();

            builder.HasOne(l => l.Address)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.AddressId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Order_AddressId");

            builder.HasOne(l => l.Coupon)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.CouponId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Order_CouponId");

            builder.HasOne(x => x.Payment)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.PaymentId);

            builder.Navigation(b => b.Address)
                   .AutoInclude();

            builder.HasMany(e => e.OrderHistories)
               .WithOne(e => e.Order)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.OrderItems)
               .WithOne(e => e.Order)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
