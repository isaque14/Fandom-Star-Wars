using FandomStarWars.Application.Interfaces.APIClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace FandomStarWars.Infra.IoC
{
    public static class DependencyInjectionAPIClient
    {
		private const string ConfigExternalAPI = "BaseUrl:ExternalApiClient";

		public static IServiceCollection AddInfrastructureExternalApiClients(this IServiceCollection services, IConfiguration configuration)
        {
			var baseUrl = configuration[ConfigExternalAPI];

			services.AddRefitClient<IApiClientRepository>()
				.ConfigureHttpClient(config => config.BaseAddress = new Uri("https://swapi.dev/api/"));

			return services;
		}
    }
}
