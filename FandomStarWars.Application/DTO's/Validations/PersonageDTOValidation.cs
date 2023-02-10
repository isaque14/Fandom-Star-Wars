using FluentValidation;

namespace FandomStarWars.Application.DTO_s.Validations
{
    public class PersonageDTOValidation : AbstractValidator<PersonageDTO>
    {
        public PersonageDTOValidation() 
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome não pode ser vazio");

            RuleFor(p => p.Height)
                .NotEmpty()
                .NotNull()
                .WithMessage("Altura não pode ser vazio");

            RuleFor(p => p.Mass)
                .NotEmpty()
                .NotNull()
                .WithMessage("Peso não pode ser vazio");

            RuleFor(p => p.BirthYear)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de Nascimento não pode ser vazio");

            RuleFor(p => p.HairColor)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cor de cabelo não pode ser vazio");

            RuleFor(p => p.SkinColor)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cor da pele não pode ser vazio");

            RuleFor(p => p.EyeColor)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cor dos olhos não pode ser vazio");

            RuleFor(p => p.Gender)
                .NotEmpty()
                .NotNull()
                .WithMessage("Genero não pode ser vazio");

            RuleFor(p => p.Homeworld)
                .NotEmpty()
                .NotNull()
                .WithMessage("Planeta natal não pode ser vazio");
        }
    }
}
