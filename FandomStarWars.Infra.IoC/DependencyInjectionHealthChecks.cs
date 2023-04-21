using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Infra.IoC
{
    public static class DependencyInjectionHealthChecks
    {
        public static IServiceCollection AddInfrastructureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("Default"), tags: new[] { "database" }, name: "PostgreSQL")
                .AddSendGrid(configuration.GetSection("SendGridEmailSettings").GetValue<string>("APIKey"), name: "SendGrid", tags: new[] { "Server-SMTP" });

            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(5);
                options.MaximumHistoryEntriesPerEndpoint(10);
                options.AddHealthCheckEndpoint("Fandom Star Wars API - Health Checks", "/health");
            })
                .AddInMemoryStorage();


            return services;
        }
    }
}
