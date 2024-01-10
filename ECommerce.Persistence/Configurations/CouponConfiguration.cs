using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("Coupons");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.Code)
                .IsRequired();

            builder.HasIndex(x => x.Code, "IX_Coupon_Code")
                .IsUnique();

            builder.Property(q => q.ValidFromUtc)
                .IsRequired();

            builder.Property(q => q.ValidToUtc)
                .IsRequired();

            builder.Property(q => q.Percentage)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasMany(e => e.Orders)
               .WithOne(e => e.Coupon)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Users)
               .WithOne(e => e.Coupon)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
