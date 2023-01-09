using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Films.Requests.Querys
{
    public class GetMoviesQueryRequest : IRequest<GenericResponse>
    {
    }
}
