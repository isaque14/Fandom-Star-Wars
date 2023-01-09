using FandomStarWars.Application.CQRS.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;
using static FandomStarWars.Application.DTO_s.MovieDataExternalApiDTO;

namespace FandomStarWars.Application.CQRS.ExternalApi.Handlers
{
    public class GetMoviesExternalApiByPageQueryHandler : IRequestHandler<GetMoviesExternalApiByPageQuery, RootFilms>
    {
        private readonly IExternalApiService _externalApiService;

        public GetMoviesExternalApiByPageQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<RootFilms> Handle(GetMoviesExternalApiByPageQuery request, CancellationToken cancellationToken)
        {
            return await _externalApiService.GetFilmsByPageAsync(request.NumberPage);
        }
    }
}
