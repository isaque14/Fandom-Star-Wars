using FandomStarWars.Application.Personages.Commands;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers
{
    public class UpdatePersonageCommandHandler : IRequestHandler<UpdatePersonageCommand, Personage>
    {
        private readonly IPersonageRepository _repository;

        public UpdatePersonageCommandHandler(IPersonageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Personage> Handle(UpdatePersonageCommand request, CancellationToken cancellationToken)
        {
            var personage = _repository.GetByIdAsync(request.Id).Result;

            if (personage == null)
                throw new ApplicationException($"Error Updating Personage");

            personage.Update(request.Name, request.Height, request.Mass, request.HairColor, request.SkinColor,
                                        request.EyeColor, request.BirthYear, request.Gender, request.Homeworld);

            return await _repository.UpdateAsync(personage);
        }
    }
}
