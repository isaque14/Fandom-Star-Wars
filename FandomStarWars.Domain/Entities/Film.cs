﻿using FandomStarWars.Domain.Entities.Base;
using FandomStarWars.Domain.Validation;

namespace FandomStarWars.Domain.Entities
{
    public class Film : Entity
    {
        public string Title { get; private set; }
        public int EpisodeId { get; private set; }
        public string OpeningCrawl { get; private set; }
        public string Director { get; private set; }
        public string Producer { get; private set; }
        public string ReleaseDate { get; private set; }
        public string Created { get; private set; }
        public string? Edited { get; private set; }
        public ICollection<Personage> Personages { get; set; }

        public Film(int id, string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate, string created)
        {
            DomainExceptionValidation.When(id >= 0, "Invalid Id");
            ValidationDomain(title, episodeId, openingCrawl, director, producer, releaseDate);
            Created = DateTime.Now.ToString();
        }

        public Film(string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate)
        {
            ValidationDomain(title, episodeId, openingCrawl, director, producer, releaseDate);
            Created = DateTime.Now.ToString();
        }

        public void Update(string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate,
            string created)
        {
            Title = title;
            EpisodeId = episodeId;
            OpeningCrawl = openingCrawl;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
            Created = created;
            Edited = DateTime.Now.ToString();
        }

        public void ValidationDomain(string title, int episodeId, string openingCrawl, string director, string producer, string releaseDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title), "Title is Required");
            DomainExceptionValidation.When(episodeId <= 0, "EpisodeId is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(openingCrawl), "openingCrawl is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(director), "Director is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(producer), "Producer is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(releaseDate), "releaseDate is Required");
            
            Title = title;
            EpisodeId = episodeId;
            OpeningCrawl = openingCrawl;
            Director = director;
            Producer = producer;
            ReleaseDate = releaseDate;
        }
    }
}
