using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Base;

namespace FandomStarWars.Application.Personages.Responses.Commands
{
    public class DeletePersonageCommandResponse : BaseResponseFilms
    {
        public PersonageDTO PersonageDeleted { get; set; }

        public DeletePersonageCommandResponse(PersonageDTO personageDeleted)
        {
            PersonageDeleted = personageDeleted;
        }

        public DeletePersonageCommandResponse()
        {
                
        }
    }
}
