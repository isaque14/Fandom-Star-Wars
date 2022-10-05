using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Personages.Querys
{
    public class GetPersonagesByIdQuery : IRequest<Personage>
    {
        public int Id { get; set; }

        public GetPersonagesByIdQuery(int id)
        {
            Id = id;    
        }
    }
}
