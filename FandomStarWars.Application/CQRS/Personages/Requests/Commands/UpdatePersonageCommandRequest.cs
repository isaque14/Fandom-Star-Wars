using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands.Base;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Requests.Commands
{
    public class UpdatePersonageCommandRequest : PersonageCommand, IRequest<GenericResponse>
    {
        public int Id { get; private set; }
    }
}
