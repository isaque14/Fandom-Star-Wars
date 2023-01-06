using MediatR;
using static FandomStarWars.Application.DTO_s.PersonageDataExternalApiDTO;

namespace FandomStarWars.Application.ExternalApi.Querys
{
    public class GetPersonagesExternalApiByPageQuery : IRequest<Root>
    {
        public int NumberPage { get; set; }

        public GetPersonagesExternalApiByPageQuery(int numberPage)
        {
            NumberPage = numberPage;
        }
    }
}
