using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FluentValidation;

namespace FandomStarWars.Application.CQRS.Validations.Personage
{
    public class ValidateUpdatePersonage : AbstractValidator<UpdatePersonageCommandRequest>
    {
        public ValidateUpdatePersonage() 
        {
            RuleFor(p => p.Id)
                .LessThanOrEqualTo(0)
                .WithMessage("Id Inválido");

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome não pode ser vazio");

            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Nome não pode ser menor que 3 caracteres");

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
