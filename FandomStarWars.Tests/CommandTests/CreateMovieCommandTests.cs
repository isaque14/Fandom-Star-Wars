using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Movie;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.CommandTests
{
    public class CreateMovieCommandTests
    {
        private readonly CreateMovieCommandRequest _validCommand = new CreateMovieCommandRequest
        {
            Title = "Title",
            EpisodeId = 78,
            OpeningCrawl = "OpeningTests",
            Director = "Director",
            Producer = "Producer",
            ReleaseDate = "ReleaseDate",
            PersonagesId = new List<int> { 1, 7, 56, 9, 16}
        };

        private readonly CreateMovieCommandRequest _invalidCommand = new CreateMovieCommandRequest
        {
            Title = "Ti",
            EpisodeId = 78,
            OpeningCrawl = "OpeningTests",
            Producer = "Producer",
            ReleaseDate = "ReleaseDate",
            PersonagesId = new List<int>()
        };

        private readonly ValidateCreateMovie _validator;

        public CreateMovieCommandTests()
        {
            var service = new ServiceCollection();
            service.AddScoped<ValidateCreateMovie>();

            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateCreateMovie>();
        }


        [Fact(DisplayName = "Create Movie With Valid Parameters")]
        public void CreateMovie_WithValidParameters_ResultObjectValidState()
        {
            var result = _validator.Validate(_validCommand);
            Assert.True(result.IsValid);
        }
        
        [Fact(DisplayName = "Create Movie With Invalid Parameters")]
        public void CreateMovie_WithInvalidParameters_ResultObjectInvalidState()
        {
            var result = _validator.Validate(_invalidCommand);
            Assert.False(result.IsValid);
        }
    }
}
