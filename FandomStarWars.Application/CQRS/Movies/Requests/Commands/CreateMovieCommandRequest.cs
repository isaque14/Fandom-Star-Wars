using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Requests.Commands
{
    public class CreateMovieCommandRequest : IRequest<GenericResponse>
    {
        public MovieDTO FilmDTO { get; private set; }

        public CreateMovieCommandRequest(MovieDTO filmDTO)
        {
            FilmDTO = filmDTO;
        }
    }
}
