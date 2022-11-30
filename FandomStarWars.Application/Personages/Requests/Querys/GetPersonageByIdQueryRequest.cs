using FandomStarWars.Application.Personages.Responses.Querys;
using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Personages.Querys
{
    public class GetPersonageByIdQueryRequest : IRequest<GetPersonageByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetPersonageByIdQueryRequest(int id)
        {
            Id = id;    
        }
    }
}
