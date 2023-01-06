using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Requests.Querys
{
    public class GetPersonageByNameQueryRequest : IRequest<GenericResponse>
    {
        public string Name { get; private set; }

        public GetPersonageByNameQueryRequest(string name)
        {
            Name = name;
        }
    }
}
