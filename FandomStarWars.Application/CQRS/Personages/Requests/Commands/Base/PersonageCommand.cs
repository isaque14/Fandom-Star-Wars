using FluentValidation.Results;

namespace FandomStarWars.Application.CQRS.Personages.Requests.Commands.Base
{
    public abstract class PersonageCommand
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }

        public string ErrorMensage (List<ValidationFailure> errors)
        {
            var msg = "";
            foreach (var erro in errors)
            {
                msg = msg + $"{erro + System.Environment.NewLine} ";
            }
            return msg;
        }

    }
}
