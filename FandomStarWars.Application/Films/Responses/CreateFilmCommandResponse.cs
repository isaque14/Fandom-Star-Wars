using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Films.Responses.Base;

namespace FandomStarWars.Application.Films.Responses
{
    public class CreateFilmCommandResponse : BaseResponseFilms
    {
        public FilmDTO FilmCreated { get; set; }

        public CreateFilmCommandResponse(FilmDTO filmCreated)
        {
            FilmCreated = filmCreated;
        }

        public CreateFilmCommandResponse()
        {

        }
    }
}
