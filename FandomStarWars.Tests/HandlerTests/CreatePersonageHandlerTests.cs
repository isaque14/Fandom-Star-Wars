using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Handlers.Commands;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Personage;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Tests.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.HandlerTests
{
    public class CreatePersonageHandlerTests
    {
        private readonly CreatePersonageCommandRequest _validCommand = new CreatePersonageCommandRequest
        {
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

        private readonly CreatePersonageCommandRequest _invalidCommand = new CreatePersonageCommandRequest
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
        private readonly ValidateCreatePersonage _validator;
        private readonly CreatePersonageCommandHandler _handler;

        public CreatePersonageHandlerTests()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);
            service.AddScoped<ValidateCreatePersonage>();
            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateCreatePersonage>();
            _handler = new CreatePersonageCommandHandler(new FakePersonageRepository(), _mapper, _validator);
        }

        [Fact(DisplayName = "Handler with invalid command result in stop application")]
        public void CreatePersonageHandler_WithInvalidCommand_ResultInStopApplication()
        {
            GenericResponse response = _handler.Handle(_invalidCommand, new CancellationToken()).Result;
            Assert.False(response.IsSuccessful);
        }
        
        [Fact(DisplayName = "Handler with valid command, create personage")]
        public void CreatePersonageHandler_WithValidCommand_ResultInPersonageCreated()
        {
            GenericResponse response = _handler.Handle(_validCommand, new CancellationToken()).Result;
            Assert.True(response.IsSuccessful);
        }
    }
}
