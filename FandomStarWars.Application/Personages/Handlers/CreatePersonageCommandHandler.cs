using FandomStarWars.Application.Personages.Commands;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers
{
    public class CreatePersonageCommandHandler : IRequestHandler<CreatePersonageCommand, Personage>
    {
        private readonly IPersonageRepository _repository;

        public CreatePersonageCommandHandler(IPersonageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Personage> Handle(CreatePersonageCommand request, CancellationToken cancellationToken)
        {
            var personage = new Personage(request.Name, request.Height, request.Mass, request.HairColor, request.SkinColor,
                request.EyeColor, request.BirthYear, request.Gender, request.Homeworld);

            if (personage == null)
                throw new ApplicationException($"Error creating Personage");

            return await _repository.CreateAsync(personage);
        }
    }
}
