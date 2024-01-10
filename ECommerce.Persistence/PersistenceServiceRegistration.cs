using ECommerce.Application.Contracts.Files;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Persistence.DbContext;
using ECommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ECommerceConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(ICouponRepository), typeof(CouponRepository));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(ICartItemRepository), typeof(CartItemRepository));
            services.AddScoped(typeof(IPaymentHistoryRepository), typeof(PaymentHistoryRepository));
            services.AddScoped(typeof(IPaymentRepository), typeof(PaymentRepository));
            services.AddScoped(typeof(IFileRepository), typeof(FileRepository));
            services.AddScoped(typeof(IProductFileRepository), typeof(ProductFileRepository));

            return services;
        }
    }
}
