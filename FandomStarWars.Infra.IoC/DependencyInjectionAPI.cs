using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Application.Services;
using FandomStarWars.Domain.Account;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using FandomStarWars.Infra.Data.Identity;
using FandomStarWars.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IPersonageRepository, PersonageRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMockRepository, MockRepository>();

            services.AddScoped<IPersonageService, PersonageService>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("FandomStarWars.Application");
            services.AddMediatR(myHandlers);


            return services;
        }
    }
}

