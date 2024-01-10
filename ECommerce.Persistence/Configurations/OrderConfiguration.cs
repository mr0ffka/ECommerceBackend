using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

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

            builder.HasMany(e => e.OrderHistory)
               .WithOne(e => e.Order)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.OrderItems)
               .WithOne(e => e.Order)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
