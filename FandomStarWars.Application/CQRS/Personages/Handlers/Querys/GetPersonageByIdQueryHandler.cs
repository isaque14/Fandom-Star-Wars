using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Handlers.Querys
{
    public class GetPersonageByIdQueryHandler : IRequestHandler<GetPersonageByIdQueryRequest, GenericResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonageByIdQueryHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPersonageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var personageEntity = await _repository.GetByIdAsync(request.Id);
                var personageDTO = _mapper.Map<PersonageDTO>(personageEntity);

                return new GenericResponse
                {
                    IsSuccessful = personageEntity is not null ? true : false,
                    Message = personageEntity is not null ? "Successfully obtained personage" : "No personage found with this id",
                    Object = personageDTO
                };
            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = e.Message
                };
            }
        }
    }
}
