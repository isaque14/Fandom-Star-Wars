using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Requests.Commands
{
    public class DeletePersonageCommandRequest : IRequest<GenericResponse>
    {
        public int Id { get; set; }
        public DeletePersonageCommandRequest(int id)
        {
            Id = Id;
        }
    }
}
