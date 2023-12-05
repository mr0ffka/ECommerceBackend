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
    public class ExampleConfiguration : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.HasIndex(x => x.PublicId, "IX_Example_PublicId")
                .IsUnique();

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder
                .Property(e => e.PublicId)
                .HasMaxLength(36)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsFixedLength();

            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(q => q.Description)
                .HasMaxLength(2000);

            builder.HasData(
                new Example
                {
                    Id = 1,
                    PublicId = "da8e00f1-9504-4111-9701-eaa3eafa133d",
                    Name = "Example name",
                    Description = "Example description",
                    DateCreatedUtc = DateTime.UtcNow,
                    DateModifiedUtc = DateTime.UtcNow,
                }
            );
        }
    }
}
