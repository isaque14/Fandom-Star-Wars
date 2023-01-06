using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;
using static FandomStarWars.Application.DTO_s.PersonageDataExternalApiDTO;

namespace FandomStarWars.Application.ExternalApi.Handlers
{
    public class GetPersonagesExternalApiByPageQueryHandler : IRequestHandler<GetPersonagesExternalApiByPageQuery, Root>
    {
        private readonly IExternalApiService _externalApiService;

        public GetPersonagesExternalApiByPageQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public Task<Root> Handle(GetPersonagesExternalApiByPageQuery request, CancellationToken cancellationToken)
        {
            return _externalApiService.GetPersonagesByPageAsync(request.NumberPage);
        }
    }
}
