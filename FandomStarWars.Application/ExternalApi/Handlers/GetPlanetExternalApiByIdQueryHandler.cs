using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;

namespace FandomStarWars.Application.ExternalApi.Handlers
{
    public class GetPlanetExternalApiByIdQueryHandler : IRequestHandler<GetPlanetExternalApiByIdQuery, PlanetDataExternalApiDTO>
    {
        private readonly IExternalApiService _externalApiService;

        public GetPlanetExternalApiByIdQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public Task<PlanetDataExternalApiDTO> Handle(GetPlanetExternalApiByIdQuery request, CancellationToken cancellationToken)
        {
            return _externalApiService.GetPlanetByIdAsync(request.Id);
        }
    }
}
