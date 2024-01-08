using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.Name)
                .IsRequired();

            builder.Property(q => q.Description)
                .IsRequired();

            builder.Property(q => q.Price)
                .IsRequired()
                .HasDefaultValue(0m);

            builder.Property(q => q.Stock)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(l => l.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Product_CategoryId");

            builder.HasMany(e => e.CartItems)
               .WithOne(e => e.Product)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(e => e.OrderItems)
               .WithOne(e => e.Product)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
