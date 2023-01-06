using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Requests.Querys
{
    public class GetPersonageByIdQueryRequest : IRequest<GenericResponse>
    {
        public int Id { get; set; }

        public GetPersonageByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
