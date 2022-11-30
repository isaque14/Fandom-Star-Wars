using FandomStarWars.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FandomStarWars.Application.DTO_s
{
    public class FilmDTO
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public string Created { get; set; }

        [Required(ErrorMessage = "Personages is Requireds")]
        public ICollection<PersonageDTO> PersonagesDTO { get; set; }

        public FilmDTO(string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate)
        {
            Title = title;
            EpisodeId = episodeId;
            OpeningCrawl = openingCrawl;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
            Created = DateTime.Now.ToString();
        }

        public FilmDTO(string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate, 
            ICollection<PersonageDTO> personagesDTO)
        {
            Title = title;
            EpisodeId = episodeId;
            OpeningCrawl = openingCrawl;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
            Created = DateTime.Now.ToString();
            PersonagesDTO = personagesDTO;
        }
    }
}
