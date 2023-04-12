using FandomStarWars.Application.CQRS.ExternalApi.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;

namespace FandomStarWars.Application.CQRS.ExternalApi.Handlers
{
    public class GetPlanetExternalApiByIdQueryHandler : IRequestHandler<GetPlanetExternalApiByIdQuery, PlanetDataExternalApiDTO>
    {
        private readonly IExternalApiService _externalApiService;

        public GetPlanetExternalApiByIdQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<PlanetDataExternalApiDTO> Handle(GetPlanetExternalApiByIdQuery request, CancellationToken cancellationToken)
        {
            return await _externalApiService.GetPlanetByIdAsync(request.Id);
        }
    }
}
