using AutoMapper;
using FandomStarWars.Application.Personages.Commands;
using FandomStarWars.Application.Personages.Responses.Commands;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers.Commands
{
    public class UpdatePersonageCommandHandler : IRequestHandler<UpdatePersonageCommandRequest, UpdatePersonageCommandResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePersonageCommandHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdatePersonageCommandResponse> Handle(UpdatePersonageCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var personage = _repository.GetByIdAsync(request.PersonageDTO.Id).Result;

                if (personage is null)
                    throw new ApplicationException($"Error Updating Personage");

                await _repository.UpdateAsync(personage);

                var response = new UpdatePersonageCommandResponse(request.PersonageDTO);
                response.IsSuccessful = true;
                response.Message = "successfully updated personage";
                return response;
            }
            catch (Exception e)
            {
                return new UpdatePersonageCommandResponse { 
                    IsSuccessful = false, 
                    Message = $"Error Updating Personage. {e.Message}" 
                };
            }
        }
    }
}
