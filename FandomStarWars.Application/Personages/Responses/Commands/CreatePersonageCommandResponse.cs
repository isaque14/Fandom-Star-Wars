using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Base;
using System.ComponentModel;

namespace FandomStarWars.Application.Personages.Responses.Commands
{
    public class CreatePersonageCommandResponse : BaseResponseFilms
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
