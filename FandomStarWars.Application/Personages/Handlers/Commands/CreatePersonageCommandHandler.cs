using AutoMapper;
using FandomStarWars.Application.Personages.Commands;
using FandomStarWars.Application.Personages.Responses.Commands;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Personages.Handlers.Commands
{
    public class CreatePersonageCommandHandler : IRequestHandler<CreatePersonageCommandRequest, CreatePersonageCommandResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;

        public CreatePersonageCommandHandler(IPersonageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatePersonageCommandResponse> Handle(CreatePersonageCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Personage personage = _mapper.Map<Personage>(request.PersonageDTO);
                
                if (personage is null)
                    throw new ApplicationException($"Error creating Personage");

                await _repository.CreateAsync(personage);
                var response = new CreatePersonageCommandResponse(request.PersonageDTO);

                response.IsSuccessful = true;
                response.Message = "successfully created personage";
                return response;
            }
            catch (Exception e)
            {
                return new CreatePersonageCommandResponse { 
                    IsSuccessful = false,
                    Message = e.Message
                };
            }
        }
    }

}
