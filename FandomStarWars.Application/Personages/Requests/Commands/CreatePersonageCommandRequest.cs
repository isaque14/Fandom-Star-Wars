using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Commands.Base;
using FandomStarWars.Application.Personages.Responses.Commands;
using MediatR;

namespace FandomStarWars.Application.Personages.Commands
{
    public class CreatePersonageCommandRequest : IRequest<CreatePersonageCommandResponse>
    {
        public PersonageDTO PersonageDTO { get; set; }

        public CreatePersonageCommandRequest(PersonageDTO personageDTO)
        {
            PersonageDTO = personageDTO;
        }
    }
}
