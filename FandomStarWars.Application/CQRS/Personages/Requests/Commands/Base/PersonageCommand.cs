using FluentValidation.Results;

namespace FandomStarWars.Application.CQRS.Personages.Requests.Commands.Base
{
    public abstract class PersonageCommand
    {
        public string Name { get; private set; }
        public string Height { get; private set; }
        public string Mass { get; private set; }
        public string HairColor { get; private set; }
        public string SkinColor { get; private set; }
        public string EyeColor { get; private set; }
        public string BirthYear { get; private set; }
        public string Gender { get; private set; }
        public string Homeworld { get; private set; }

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
