using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Handlers.Querys
{
    public class GetPersonageByNameQueryHandler : IRequestHandler<GetPersonageByNameQueryRequest, GenericResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonageByNameQueryHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPersonageByNameQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var personageEntity = await _repository.GetByNameAsync(request.Name);

                var personageDTO = _mapper.Map<PersonageDTO>(personageEntity);

                return new GenericResponse
                {
                    IsSuccessful = personageEntity is not null ? true : false,
                    Message = personageEntity is not null ? "Successfully obtained personage" : "No personage found with this name",
                    Object = personageDTO
                };
            }
            catch (Exception e)
            {
                return new GenericResponse { 
                    IsSuccessful = false, 
                    Message = e.Message 
                };
            }
        }
    }
}
