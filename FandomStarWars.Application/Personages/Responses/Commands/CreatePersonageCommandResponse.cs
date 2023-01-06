using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Base;

namespace FandomStarWars.Application.Personages.Responses.Commands
{
    public class CreatePersonageCommandResponse : BaseResponse
    {
        public PersonageDTO PersonageCreated { get; private set; }

        public CreatePersonageCommandResponse(PersonageDTO personageCreated)
        {
            PersonageCreated = personageCreated;
        }

        public CreatePersonageCommandResponse()
        {

        }
    }
}
