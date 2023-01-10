using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Requests.Querys
{
    public class GetMoviesQueryRequest : IRequest<GenericResponse>
    {
    }
}
