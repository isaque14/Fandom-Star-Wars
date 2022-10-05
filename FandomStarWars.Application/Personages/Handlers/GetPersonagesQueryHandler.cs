using FandomStarWars.Application.Personages.Querys;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers
{
    public class GetPersonagesQueryHandler : IRequestHandler<GetPersonagesQuery, IEnumerable<Personage>>
    {
        private readonly IPersonageRepository _repository;

        public GetPersonagesQueryHandler(IPersonageRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Personage>> Handle(GetPersonagesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
