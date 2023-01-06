using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;
using MediatR;

namespace FandomStarWars.Application.CQRS.Films.Requests.Commands
{
    public class CreateFilmCommandRequest : IRequest<GenericResponse>
    {
        public FilmDTO FilmDTO { get; private set; }

        public CreateFilmCommandRequest(FilmDTO filmDTO)
        {
            FilmDTO = filmDTO;
        }
    }
}
