using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Requests.Querys
{
    public class GetPersonagesQueryRequest : IRequest<GenericResponse>
    {
    }
}
