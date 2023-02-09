using FandomStarWars.Domain.Entities.Base;

namespace FandomStarWars.Domain.Entities
{
    public class Movie : Entity
    {
        public string Title { get; private set; }
        public int EpisodeId { get; private set; }
        public string OpeningCrawl { get; private set; }
        public string Director { get; private set; }
        public string Producer { get; private set; }
        public string ReleaseDate { get; private set; }
        public string Created { get; private set; }
        public string? Edited { get; private set; }
        public ICollection<Personage>? Personages { get; set; }

        public Movie(int id, string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate)
        {
            Id = id;
            Title = title;
            EpisodeId = episodeId;
            OpeningCrawl = openingCrawl;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
            Created = DateTime.Now.ToString();
        }

        public Movie(string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate, ICollection<Personage> personages)
        {
            Title = title;
            EpisodeId = episodeId;
            OpeningCrawl = openingCrawl;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
            Personages = personages;
            Created = DateTime.Now.ToString();
        }

        public Movie(string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate)
        {
            Title = title;
            EpisodeId = episodeId;
            OpeningCrawl = openingCrawl;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
            Created = DateTime.Now.ToString();
        }

        public void Update(string title, 
            int episodeId, 
            string openingCrawl, 
            string director, 
            string producer, 
            string releaseDate, 
            ICollection<Personage> personages)
        {
            Title = title;
            EpisodeId = episodeId;
            OpeningCrawl = openingCrawl;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
            Edited = DateTime.Now.ToString();
            Personages = personages;
        }
    }
}
