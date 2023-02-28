using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Handlers.Commands
{
    public class DeletePersonageCommandHandler : IRequestHandler<DeletePersonageCommandRequest, GenericResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public DeletePersonageCommandHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(DeletePersonageCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var personage = await _repository.GetByIdAsync(request.Id);

                if (personage is null)
                    throw new ApplicationException($"Error, Personage Not found");

                _repository.DeleteAsync(personage);
                var personageDTO = _mapper.Map<PersonageDTO>(personage);
                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully deleted personage",
                    Object = personageDTO
                };
            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = $"Error Deleting Personage. {e.Message}"
                };
            }
        }
    }
}
