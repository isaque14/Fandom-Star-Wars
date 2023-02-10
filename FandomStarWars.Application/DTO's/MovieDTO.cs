using System.ComponentModel.DataAnnotations;

namespace FandomStarWars.Application.DTO_s
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public string? Created { get; set; }
        public string? Edited { get; set; }
        public IEnumerable<int> PersonagesId { get; set; }

        public IEnumerable<PersonageDTO>? PersonagesDTO { get; set; }
    }
}
