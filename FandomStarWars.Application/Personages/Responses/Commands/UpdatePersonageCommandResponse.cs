using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Base;

namespace FandomStarWars.Application.Personages.Responses.Commands
{
    public class UpdatePersonageCommandResponse : BaseResponseFilms
    {
        public PersonageDTO PersonageUpdated { get; private set; }

        public UpdatePersonageCommandResponse(PersonageDTO personageUpdated)
        {
            PersonageUpdated = personageUpdated;
        }

        public UpdatePersonageCommandResponse()
        {

        }
    }
}
