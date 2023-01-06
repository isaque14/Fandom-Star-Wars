using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Handlers.Querys
{
    public class GetPersonagesQueryHandler : IRequestHandler<GetPersonagesQueryRequest, GenericResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonagesQueryHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPersonagesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var personagesEntity = await _repository.GetAllAsync();
                var personagesDTO = _mapper.Map<IEnumerable<PersonageDTO>>(personagesEntity);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Successfully obtained personages",
                    Object = personagesDTO
                };
            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = $"Error: {e.Message}"
                };   
            }
        }
    }
}
