using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Commands;
using MediatR;

namespace FandomStarWars.Application.Personages.Commands
{
    public class UpdatePersonageCommandRequest : IRequest<UpdatePersonageCommandResponse>
    {
        public PersonageDTO PersonageDTO { get; private set; }

        public UpdatePersonageCommandRequest(PersonageDTO personageDTO)
        {
            PersonageDTO = personageDTO;
        }
    }
}
