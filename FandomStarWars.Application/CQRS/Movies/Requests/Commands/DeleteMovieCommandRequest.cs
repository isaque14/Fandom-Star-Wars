using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Requests.Commands
{
    public class DeleteMovieCommandRequest : IRequest<GenericResponse>
    {
        public int Id { get; set; }

        public DeleteMovieCommandRequest(int id)
        {
            Id = id;
        }
    }
}
