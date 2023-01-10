using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands.Base;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Requests.Commands
{
    public class UpdateMovieCommandRequest : MovieCommand, IRequest<GenericResponse>
    {
        public int Id { get; set; }
    }
}
