using FandomStarWars.Application.DTO_s;
using MediatR;

namespace FandomStarWars.Application.ExternalApi.Querys
{
    public class GetPersonageExternalApiByIdQuery : IRequest<PersonageDataExternalApiDTO>
    {
        public int Id { get; set; }

        public GetPersonageExternalApiByIdQuery(int id)
        {
            Id = id;
        }
    }
}
