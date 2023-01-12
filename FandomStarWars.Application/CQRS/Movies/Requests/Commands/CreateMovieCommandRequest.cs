using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands.Base;
using FandomStarWars.Application.DTO_s;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Requests.Commands
{
    public class CreateMovieCommandRequest : MovieCommand, IRequest<GenericResponse>
    {
        
    }
}
