using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FluentValidation;

namespace FandomStarWars.Application.CQRS.Validations.Movie
{
    public class ValidateUpdateMovie : AbstractValidator<UpdateMovieCommandRequest>
    {
        public ValidateUpdateMovie()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id Inválido");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Título não pode ser vazio");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Título não pode ser menor que 3 caracteres");
            RuleFor(x => x.Director).NotEmpty().WithMessage("Diretor não pode ser vazio");
            RuleFor(x => x.Producer).NotEmpty().WithMessage("Produtor não pode ser vazio");
            RuleFor(x => x.OpeningCrawl).NotEmpty().WithMessage("OpeningCrawl não pode ser vazio");
            RuleFor(x => x.EpisodeId).NotEmpty().WithMessage("EpisodeId não pode ser vazio");
            RuleFor(x => x.ReleaseDate).NotEmpty().WithMessage("Data de Lançamento não pode ser vazio");
            RuleFor(x => x.PersonagesId).NotEmpty().WithMessage("Id dos personagens pertencentes ao filme não pode ser vazio");
        }
    }
}
