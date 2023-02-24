using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Movie;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.CommandTests
{
    public class UpdateMovieCommandTests
    {
        private readonly UpdateMovieCommandRequest _validCommand = new UpdateMovieCommandRequest
        {
            Id = 1,
            Title = "Title",
            EpisodeId = 78,
            OpeningCrawl = "OpeningTests",
            Director = "Director",
            Producer = "Producer",
            ReleaseDate = "ReleaseDate",
            PersonagesId = new List<int> { 1, 7, 56, 9, 16 }
        };

        private readonly UpdateMovieCommandRequest _invalidCommand = new UpdateMovieCommandRequest
        {
            Title = "Ti",
            EpisodeId = 78,
            OpeningCrawl = "OpeningTests",
            Producer = "Producer",
            ReleaseDate = "ReleaseDate",
            PersonagesId = new List<int>()
        };

        private readonly ValidateUpdateMovie _validator;

        public UpdateMovieCommandTests()
        {
            var service = new ServiceCollection();
            service.AddScoped<ValidateUpdateMovie>();

            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateUpdateMovie>();
        }

        [Fact(DisplayName = "Update Movie With Valid Parameters")]
        public void UpdateMovie_WithValidParameters_ResultObjectValidSttate()
        {
            var result = _validator.Validate(_validCommand);
            Assert.True(result.IsValid);
        }
        
        [Fact(DisplayName = "Update Movie With Invalid Parameters")]
        public void UpdateMovie_WithInvalidParameters_ResultObjectInvalidSttate()
        {
            var result = _validator.Validate(_invalidCommand);
            Assert.False(result.IsValid);
        }
    }
}
