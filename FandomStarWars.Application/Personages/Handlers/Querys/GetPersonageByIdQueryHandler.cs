using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Querys;
using FandomStarWars.Application.Personages.Responses.Querys;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers.Querys
{
    public class GetPersonageByIdQueryHandler : IRequestHandler<GetPersonageByIdQueryRequest, GetPersonageByIdQueryResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonageByIdQueryHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetPersonageByIdQueryResponse> Handle(GetPersonageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GetPersonageByIdQueryResponse();

            try
            {
                var personageEntity = await _repository.GetByIdAsync(request.Id);

                response.PersonageDTO = _mapper.Map<PersonageDTO>(personageEntity);
                response.IsSuccessful = true;
                response.Message = personageEntity is not null ? "Successfully obtained personage" : "No personage found with this id";
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
