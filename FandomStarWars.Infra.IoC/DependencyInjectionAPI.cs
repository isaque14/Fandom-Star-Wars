using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using FandomStarWars.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName))
                );

            services.AddScoped<IPersonageRepository, CharacterRepository>();

            services.AddScoped<IPersonageService, IPersonageService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("FandomStarWars.Application");
            services.AddMediatR(myHandlers);


            return services;
        }
    }
}

