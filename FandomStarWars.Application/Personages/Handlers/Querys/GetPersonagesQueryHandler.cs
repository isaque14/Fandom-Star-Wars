using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Querys;
using FandomStarWars.Application.Personages.Responses.Querys;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers.Querys
{
    public class GetPersonagesQueryHandler : IRequestHandler<GetPersonagesQueryRequest, GetPersonagesQueryResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonagesQueryHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetPersonagesQueryResponse> Handle(GetPersonagesQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GetPersonagesQueryResponse();

            try
            {
                var personagesEntity = await _repository.GetAllAsync();
                response.PersonagesDTO = _mapper.Map<IEnumerable<PersonageDTO>>(personagesEntity);
                response.IsSuccessful = true;
                response.Message = personagesEntity is not null ? "Successfully obtained personages" : "No personages found with this id";
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = $"Error: {e.Message}";
                
            }
            return response;
        }
    }
}
