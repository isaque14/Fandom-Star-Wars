using FandomStarWars.Application.DTO_s;
using MediatR;

namespace FandomStarWars.Application.CQRS.ExternalApi.Querys
{
    public class GetPlanetExternalApiByIdQuery : IRequest<PlanetDataExternalApiDTO>
    {
        public int Id { get; set; }

        public GetPlanetExternalApiByIdQuery(int id)
        {
            Id = id;
        }
    }
}
