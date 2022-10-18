using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Films.Commands.Base
{
    public abstract class FilmCommand : IRequest<Film>
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public string Created { get; set; }
    }
}
