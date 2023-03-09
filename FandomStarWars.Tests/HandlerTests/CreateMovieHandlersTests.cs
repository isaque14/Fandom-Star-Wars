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
    public class CreateMovieHandlersTests
    {
        private readonly CreateMovieCommandRequest _validCommand = new CreateMovieCommandRequest
        {
            Title = "Title",
            EpisodeId = 78,
            OpeningCrawl = "OpeningTests",
            Director = "Director",
            Producer = "Producer",
            ReleaseDate = "ReleaseDate",
            PersonagesId = new List<int> { 1, 7, 56, 9, 16 }
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

        private readonly IMapper _mapper;
        private readonly ValidateCreateMovie _validator;
        private readonly CreateMovieCommandHandler _handler;
        private readonly IPersonageService _personageService;

        public CreateMovieHandlersTests()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);
            service.AddScoped<ValidateCreateMovie>();
            service.AddScoped<IPersonageService, PersonageService>();
            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateCreateMovie>();
            _personageService = provider.GetService<PersonageService>();

            _handler = new CreateMovieCommandHandler(new FakeMovieRepository(), _mapper, new FakePersonageService(), _validator);
        }

        [Fact(DisplayName = "Handler with invalid command result in stop application")]
        public void CreateMovieHandler_WithInvalidCommand_ResultInStopApplication()
        {
            GenericResponse response = _handler.Handle(_invalidCommand, new CancellationToken()).Result;
            Assert.False(response.IsSuccessful);
        }

        [Fact(DisplayName = "Handler with valid command, create Movie")]
        public void CreateMovieHandler_WithValidCommand_ResultInMovieCreated()
        {
            GenericResponse response = _handler.Handle(_validCommand, new CancellationToken()).Result;
            Assert.True(response.IsSuccessful);
        }
    }
}
