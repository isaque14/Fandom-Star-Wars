using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Requests.Querys
{
    public class GetMovieByNameQueryRequest : IRequest<GenericResponse>
    {
        public string Name { get; set; }

        public GetMovieByNameQueryRequest(string name)
        {
            Name = name;
        }
    }
}
