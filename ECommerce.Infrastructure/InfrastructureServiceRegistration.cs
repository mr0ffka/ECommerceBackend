using ECommerce.Application.Contracts.Email;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Models.Email;
using ECommerce.Infrastructure.EmailService;
using ECommerce.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient(typeof(IEmailSender), typeof(EmailSender));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
