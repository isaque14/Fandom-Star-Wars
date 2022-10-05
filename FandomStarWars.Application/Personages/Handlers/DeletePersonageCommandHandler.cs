using FandomStarWars.Application.Personages.Commands;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers
{
    public class DeletePersonageCommandHandler : IRequestHandler<DeletePersonageCommand, Personage>
    {
        private readonly IPersonageRepository _repository;

        public DeletePersonageCommandHandler(IPersonageRepository repository)
        {
            _repository = repository;
        }

        async Task<Personage> IRequestHandler<DeletePersonageCommand, Personage>.Handle(DeletePersonageCommand request, CancellationToken cancellationToken)
        {
            var personage = await _repository.GetByIdAsync(request.Id);

            if (personage == null)
                throw new ApplicationException($"Error, Personage Not found");
            
            return await _repository.DeleteAsync(personage);
        }
    }
}
