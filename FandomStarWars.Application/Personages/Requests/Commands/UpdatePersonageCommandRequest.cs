using FandomStarWars.Application.Personages.Commands.Base;
using FandomStarWars.Application.Personages.Responses.Base;
using MediatR;

namespace FandomStarWars.Application.Personages.Commands
{
    public class UpdatePersonageCommandRequest : PersonageCommand, IRequest<GenericResponse>
    {
        public int Id { get; private set; }
    }
}
