using FandomStarWars.Application.Films.Commands;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Films.Handlers
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Film>
    {
        private readonly IFilmRepository _filmRepository;

        public CreateFilmCommandHandler(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<Film> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var film = new Film(
                request.Title, 
                request.EpisodeId, 
                request.OpeningCrawl, 
                request.Director, 
                request.Producer, 
                request.ReleaseDate);

            if (film == null)
                throw new ApplicationException($"Error creating Personage");

            return await _filmRepository.CreateAsync(film);
        }
    }
}
