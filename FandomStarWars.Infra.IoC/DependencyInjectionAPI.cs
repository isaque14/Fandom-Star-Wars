using FandomStarWars.Application.CQRS.Validations.Personage;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Interfaces.APIClient;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Application.Services;
using FandomStarWars.Domain.Account;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using FandomStarWars.Infra.Data.Identity;
using FandomStarWars.Infra.Data.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

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

            services.AddControllers().AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssembly(typeof(MovieDTO).Assembly);
            });

            services.AddScoped<IPersonageRepository, PersonageRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IStatusTableRepository, StatusTableRepository>();

            services.AddScoped<IPersonageService, PersonageService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddScoped<ISeedDataBankService, SeedDataBankService>();
            services.AddScoped<IApiClientService, ApiClientService>();
            services.AddScoped<IHealthCheck, OpenAIHealthCheckService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("FandomStarWars.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}

