using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Films.Responses;
using MediatR;

namespace FandomStarWars.Application.Films.Commands
{
    public class CreateFilmCommandRequest : IRequest<CreateFilmCommandResponse>
    {
        public FilmDTO FilmDTO { get; private set; }

        public CreateFilmCommandRequest(FilmDTO filmDTO)
        {
            FilmDTO = filmDTO;
        }
    }
}
