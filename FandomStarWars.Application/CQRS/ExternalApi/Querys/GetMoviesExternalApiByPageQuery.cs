using MediatR;
using static FandomStarWars.Application.DTO_s.MovieDataExternalApiDTO;

namespace FandomStarWars.Application.CQRS.ExternalApi.Querys
{
    public class GetMoviesExternalApiByPageQuery : IRequest<RootFilms>
    {
        public int NumberPage { get; set; }

        public GetMoviesExternalApiByPageQuery(int numberPage)
        {
            NumberPage = numberPage;
        }
    }
}
