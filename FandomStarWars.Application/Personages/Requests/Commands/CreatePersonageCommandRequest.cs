using FandomStarWars.Application.Personages.Commands.Base;
using FandomStarWars.Application.Personages.Responses.Commands;
using MediatR;

namespace FandomStarWars.Application.Personages.Commands
{
    public class CreatePersonageCommandRequest : PersonageCommand, IRequest<CreatePersonageCommandResponse>
    {
     
    }
}
