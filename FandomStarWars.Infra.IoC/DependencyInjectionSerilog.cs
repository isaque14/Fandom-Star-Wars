using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

namespace FandomStarWars.Infra.IoC
{
    public static class DependencyInjectionSerilog
    {
        public static Logger AddInfrastructureSerilog(IConfiguration configuration)
        {
            var keySecret = configuration["ConnectionStrings:Default"];

            Logger logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.PostgreSQL(keySecret, "Logs", needAutoCreateTable: true)
                .CreateLogger();

            return logger;
        }
    }
}