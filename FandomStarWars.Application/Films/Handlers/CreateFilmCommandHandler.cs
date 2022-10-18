using FandomStarWars.Application.Films.Commands;
using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Films.Handlers
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Film>
    {
        public CreateFilmCommandHandler(IF)
        {

        }

        public Task<Film> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
