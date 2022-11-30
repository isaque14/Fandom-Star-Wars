using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Commands;
using FandomStarWars.Application.Personages.Responses.Commands;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers.Commands
{
    public class DeletePersonageCommandHandler : IRequestHandler<DeletePersonageCommandRequest, DeletePersonageCommandResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public DeletePersonageCommandHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeletePersonageCommandResponse> Handle(DeletePersonageCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var personage = await _repository.GetByIdAsync(request.Id);

                if (personage == null)
                    throw new ApplicationException($"Error, Personage Not found");

                var personageUpdated = await _repository.DeleteAsync(personage);
                var response = new DeletePersonageCommandResponse(_mapper.Map<PersonageDTO>(personageUpdated));
                response.IsSuccessful = true;
                response.Message = "successfully deleted personage";
                return response;
            }
            catch (Exception e)
            {
                return new DeletePersonageCommandResponse
                {
                    IsSuccessful = false,
                    Message = $"Error Deleting Personage. {e.Message}"
                };
            }
        }
    }
}
