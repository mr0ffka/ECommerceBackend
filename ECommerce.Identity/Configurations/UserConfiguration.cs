using ECommerce.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ECommerce.Identity.Models;

namespace ECommerce.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            builder.HasData(
                new AppUser
                {
                    Id = "d3c78dce-d413-4345-b5e6-004667574c82",
                    Email = "admin@ecommerce.local",
                    NormalizedEmail = "ADMIN@ECOMMERCE.LOCAL",
                    FirstName = "System",
                    LastName = "Administrator",
                    UserName = "admin@ecommerce.local",
                    NormalizedUserName = "ADMIN@ECOMMERCE.LOCAL",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new AppUser
                {
                    Id = "421bba63-e34f-4308-b737-61c59c316b86",
                    Email = "user@ecommerce.local",
                    NormalizedEmail = "USER@ECOMMERCE.LOCAL",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@ecommerce.local",
                    NormalizedUserName = "USER@ECOMMERCE.LOCAL",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
