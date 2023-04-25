using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;

namespace FandomStarWars.Infra.IoC
{
    public static class DependencyInjectionSendGrid
    {
        public static IServiceCollection AddInfrastructureSendGrid(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddSendGrid(opt =>
            {
                opt.ApiKey = configuration.GetSection("SendGridEmailSettings").GetValue<string>("APIKey");
            });

            return services;
        }
    }
}
