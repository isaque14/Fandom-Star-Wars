using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Handlers.Commands;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Personage;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.HandlerTests
{
    public class UpdatePersonageHandlerTests
    {
        private readonly UpdatePersonageCommandRequest _validCommand = new UpdatePersonageCommandRequest
        {
            Id = 1,
            Name = "teste",
            Height = "164",
            Mass = "70",
            HairColor = "black",
            SkinColor = "black",
            EyeColor = "green",
            BirthYear = "data",
            Gender = "male",
            Homeworld = "earth"
        };

        private readonly UpdatePersonageCommandRequest _invalidCommand = new UpdatePersonageCommandRequest
        {
            Name = "",
            Height = "164",
            Mass = "70",
            HairColor = "black",
            SkinColor = "",
            EyeColor = "green",
            BirthYear = "",
            Gender = "male",
            Homeworld = "earth"
        };

        private readonly IMapper _mapper;
        private readonly ValidateUpdatePersonage _validator;
        private readonly UpdatePersonageCommandHandler _handler;

        public UpdatePersonageHandlerTests()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);
            service.AddScoped<ValidateUpdatePersonage>();
            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateUpdatePersonage>();
            _handler = new UpdatePersonageCommandHandler(new FakePersonageRepository(), _mapper, _validator);
        }

        [Fact(DisplayName = "Handler with invalid command result in stop application")]
        public void UpdatePersonageHandler_WithInvalidCommand_ResultInStopApplication()
        {
            GenericResponse response = _handler.Handle(_invalidCommand, new CancellationToken()).Result;
            Assert.False(response.IsSuccessful);
        }

        [Fact(DisplayName = "Handler with valid command, update personage")]
        public void UpdatePersonageHandler_WithValidCommand_ResultInPersonageCreated()
        {
            GenericResponse response = _handler.Handle(_validCommand, new CancellationToken()).Result;
            Assert.True(response.IsSuccessful);
        }
    }
}
