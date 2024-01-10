using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class UserUsedCouponConfiguration : IEntityTypeConfiguration<UserUsedCoupon>
    {
        public void Configure(EntityTypeBuilder<UserUsedCoupon> builder)
        {
            builder.ToTable("UserUsedCoupons");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.UserId)
                .IsRequired();

            builder.Property(q => q.CouponId)
                .IsRequired();

            builder.HasOne(l => l.Coupon)
               .WithMany(c => c.Users)
               .HasForeignKey(c => c.CouponId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_UserUsedCoupon_CouponId");
        }
    }
}
