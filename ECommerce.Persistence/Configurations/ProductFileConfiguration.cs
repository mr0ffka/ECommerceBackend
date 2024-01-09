using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class ProductFileConfiguration : IEntityTypeConfiguration<ProductFile>
    {
        public void Configure(EntityTypeBuilder<ProductFile> builder)
        {
            builder.ToTable("ProductFiles");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.ProductId)
                .IsRequired();

            builder.Property(q => q.FileId)
                .IsRequired();

            builder.HasOne(l => l.Product)
               .WithMany(c => c.Files)
               .HasForeignKey(c => c.ProductId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_ProductFile_ProductId");

            builder.HasOne(l => l.File)
               .WithMany(c => c.Products)
               .HasForeignKey(c => c.FileId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_ProductFile_FileId");
        }
    }
}
