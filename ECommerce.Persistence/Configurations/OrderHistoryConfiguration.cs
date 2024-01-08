using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.ToTable("OrderHistories");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.Status)
                .IsRequired();

            builder.HasOne(l => l.Order)
               .WithMany(c => c.OrderHistories)
               .HasForeignKey(c => c.OrderId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_OrderHistory_OrderId");
        }
    }
}
