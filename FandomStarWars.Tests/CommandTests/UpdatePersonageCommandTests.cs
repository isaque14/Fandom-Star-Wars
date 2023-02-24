using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Personage;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;

namespace FandomStarWars.Tests.CommandTests
{
    public class UpdatePersonageCommandTests
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
            Id = 0,
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

        private readonly ValidateUpdatePersonage _validator;

        public UpdatePersonageCommandTests()
        {
            var service = new ServiceCollection();
            service.AddScoped<ValidateUpdatePersonage>();

            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateUpdatePersonage>();
        }

        [Fact(DisplayName = "Update Personage With Valid State")]
        public void UpadatePersonage_WithValidParameters_ResultObjectValidState()
        {
            var result = _validator.Validate(_validCommand);
            Assert.True(result.IsValid);
        }
        
        [Fact(DisplayName = "Update Personage With Invalid State")]
        public void UpadatePersonage_WithInvalidParameters_ResultObjectInvalidState()
        {
            var result = _validator.Validate(_invalidCommand);
            Assert.False(result.IsValid);
        }
    }
}
