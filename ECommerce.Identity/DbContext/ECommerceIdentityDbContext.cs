using ECommerce.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.DbContext
{
    public class ECommerceIdentityDbContext : IdentityDbContext<AppUser>
    {
        public ECommerceIdentityDbContext(DbContextOptions<ECommerceIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ECommerceIdentityDbContext).Assembly);
            
            base.OnModelCreating(builder);
        }
    }
}
