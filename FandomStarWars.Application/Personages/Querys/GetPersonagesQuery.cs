using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Personages.Querys
{
    public class GetPersonagesQuery : IRequest<IEnumerable<Personage>>
    {
    }
}
