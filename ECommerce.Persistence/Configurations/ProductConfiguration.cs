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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasIndex(x => x.PublicId, "IX_Product_PublicId")
                .IsUnique();

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder
                .Property(e => e.PublicId)
                .HasMaxLength(36)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsFixedLength();

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
