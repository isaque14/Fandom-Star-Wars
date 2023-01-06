using FandomStarWars.Application.Personages.Responses.Querys;
using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Personages.Querys
{
    public class GetPersonagesQueryRequest : IRequest<GetPersonagesQueryResponse>
    {
    }
}
