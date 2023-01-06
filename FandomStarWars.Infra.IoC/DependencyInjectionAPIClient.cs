using FandomStarWars.Application.Interfaces.APIClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace FandomStarWars.Infra.IoC
{
    public static class DependencyInjectionAPIClient
    {
		public static IServiceCollection AddInfrastructureExternalApiClients(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddRefitClient<IExternalApiService>()
			.ConfigureHttpClient(config => config.BaseAddress = new Uri("https://swapi.dev/api/"));

			return services;
		}
    }
}
