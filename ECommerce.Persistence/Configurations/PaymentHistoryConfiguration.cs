using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class PaymentHistoryConfiguration : IEntityTypeConfiguration<PaymentHistory>
    {
        public void Configure(EntityTypeBuilder<PaymentHistory> builder)
        {
            builder.ToTable("PaymentHistory");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.Amount)
                .IsRequired()
                .HasDefaultValue(0m);

            builder.HasOne(l => l.Payment)
               .WithMany(c => c.PaymentHistory)
               .HasForeignKey(c => c.PaymentId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_PaymentHistory_PaymentId");
        }
    }
}
