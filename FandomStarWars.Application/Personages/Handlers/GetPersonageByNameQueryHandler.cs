using FandomStarWars.Application.Personages.Querys;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers
{
    public class GetPersonageByNameQueryHandler : IRequestHandler<GetPersonageByNameQuery, Personage>
    {
        private readonly IPersonageRepository _repository;

        public GetPersonageByNameQueryHandler(IPersonageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Personage> Handle(GetPersonageByNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByNameAsync(request.Name);
        }
    }
}
