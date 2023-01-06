using FandomStarWars.Application.Personages.Commands.Base;
using FandomStarWars.Application.Personages.Responses.Querys;
using MediatR;

namespace FandomStarWars.Application.Personages.Querys
{
    public class GetPersonageByNameQueryRequest : IRequest<GetPersonageByNameQueryResponse>
    {
        public string Name { get; private set; }

        public GetPersonageByNameQueryRequest(string name)
        {
            Name = name;
        }
    }
}
