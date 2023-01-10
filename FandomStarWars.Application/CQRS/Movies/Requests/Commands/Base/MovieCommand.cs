using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Requests.Commands.Base
{
    public abstract class MovieCommand
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public string Created { get; set; }
        public ICollection<PersonageDTO> Personages { get; set; }
    }
}
