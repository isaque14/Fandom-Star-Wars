using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;
using static FandomStarWars.Application.DTO_s.FilmsDataExternalApiDTO;

namespace FandomStarWars.Application.ExternalApi.Handlers
{
    public class GetFilmsExternalApiByPageQueryHandler : IRequestHandler<GetFilmsExternalApiByPageQuery, RootFilms>
    {
        private readonly IExternalApiService _externalApiService;

        public GetFilmsExternalApiByPageQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<RootFilms> Handle(GetFilmsExternalApiByPageQuery request, CancellationToken cancellationToken)
        {
            return await _externalApiService.GetFilmsByPageAsync(request.NumberPage);
        }
    }
}
