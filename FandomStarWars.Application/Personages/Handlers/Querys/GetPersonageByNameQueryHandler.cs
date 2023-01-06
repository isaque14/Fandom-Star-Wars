using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Querys;
using FandomStarWars.Application.Personages.Responses.Querys;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers.Querys
{
    public class GetPersonageByNameQueryHandler : IRequestHandler<GetPersonageByNameQueryRequest, GetPersonageByNameQueryResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonageByNameQueryHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetPersonageByNameQueryResponse> Handle(GetPersonageByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GetPersonageByNameQueryResponse();

            try
            {
                var personageEntity = await _repository.GetByNameAsync(request.Name);
                
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
