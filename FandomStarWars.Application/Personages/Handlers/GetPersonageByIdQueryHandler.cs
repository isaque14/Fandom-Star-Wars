using FandomStarWars.Application.Personages.Querys;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers
{
    public class GetPersonageByIdQueryHandler : IRequestHandler<GetPersonageByIdQuery, Personage>
    {
        private readonly IPersonageRepository _repository;

        public GetPersonageByIdQueryHandler(IPersonageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Personage> Handle(GetPersonageByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
