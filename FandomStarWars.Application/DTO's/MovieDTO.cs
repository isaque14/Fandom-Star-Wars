using FandomStarWars.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FandomStarWars.Application.DTO_s
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public string Created { get; set; }

        //[Required(ErrorMessage = "Personages is Requireds")]
        public IEnumerable<PersonageDTO> PersonagesDTO { get; set; }
    }
}
