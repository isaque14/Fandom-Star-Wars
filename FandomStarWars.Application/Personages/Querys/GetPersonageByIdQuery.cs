using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Personages.Querys
{
    public class GetPersonageByIdQuery : IRequest<Personage>
    {
        public int Id { get; set; }

        public GetPersonageByIdQuery(int id)
        {
            Id = id;    
        }
    }
}
