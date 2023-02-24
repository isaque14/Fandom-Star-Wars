using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Personage;
using FandomStarWars.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.CommandTests
{
    public class CreatePersonageCommandTest
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
        private readonly ValidateCreatePersonage _validator;

        public CreatePersonageCommandTest()
        {
            var service = new ServiceCollection();
            service.AddScoped<ValidateCreatePersonage>();

            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateCreatePersonage>();
        }


        [Fact(DisplayName = "Create Personage With Valid State")]
        public void CreatePersonage_WithValidParameters_ResultObjectValidateState()
        {
            var result = _validator.Validate(_validCommand);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Create Personage With Invalid State")]
        public void CreatePersonage_WithInvalidParameters_Result_ResultObjectInvalidState()
        {
            var result = _validator.Validate(_invalidCommand); 
            Assert.False(result.IsValid);    
        }
    }
}
