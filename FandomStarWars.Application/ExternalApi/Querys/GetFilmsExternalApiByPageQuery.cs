using MediatR;
using static FandomStarWars.Application.DTO_s.FilmsDataExternalApiDTO;

namespace FandomStarWars.Application.ExternalApi.Querys
{
    public class GetFilmsExternalApiByPageQuery : IRequest<RootFilms>
    {
        public int NumberPage { get; set; }

        public GetFilmsExternalApiByPageQuery(int numberPage)
        {
            NumberPage = numberPage;
        }
    }
}
