using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;

namespace FandomStarWars.Application.ExternalApi.Handlers
{
    public class GetPersonageExternalApiByIdQueryHandler : IRequestHandler<GetPersonageExternalApiByIdQuery, PersonageDataExternalApiDTO>
    {
        private readonly IExternalApiService _externalApiService;

        public GetPersonageExternalApiByIdQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<PersonageDataExternalApiDTO> Handle(GetPersonageExternalApiByIdQuery request, CancellationToken cancellationToken)
        {
            return await _externalApiService.GetPersonageByIdAsync(request.Id);
        }
    }
}
