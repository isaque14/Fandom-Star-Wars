using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Handlers.Commands;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Movie;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Application.Services;
using FandomStarWars.Tests.Repositories;
using FandomStarWars.Tests.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.HandlerTests
{
    public class UpdateMovieHandlersTest
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

        private readonly IMapper _mapper;
        private readonly ValidateUpdateMovie _validator;
        private readonly UpdateMovieCommandRequestHandler _handler;

        public UpdateMovieHandlersTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);
            service.AddScoped<ValidateUpdateMovie>();
            service.AddScoped<IPersonageService, PersonageService>();
            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateUpdateMovie>();

            _handler = new UpdateMovieCommandRequestHandler(
                _mapper,
                new FakeMovieRepository(), 
                new FakePersonageService(), 
                new FakePersonageRepository(), 
                _validator
                );
        }

        [Fact(DisplayName = "Handler with invalid command result in stop application")]
        public void UpdateMovieHandler_WithInvalidCommand_ResultInStopApplication()
        {
            GenericResponse response = _handler.Handle(_invalidCommand, new CancellationToken()).Result;
            Assert.False(response.IsSuccessful);
        }

        [Fact(DisplayName = "Handler with valid command, Update Movie")]
        public void MovieHandler_WithValidCommand_ResultInMovieUpdated()
        {
            GenericResponse response = _handler.Handle(_validCommand, new CancellationToken()).Result;
            Assert.True(response.IsSuccessful);
        }
    }
}
