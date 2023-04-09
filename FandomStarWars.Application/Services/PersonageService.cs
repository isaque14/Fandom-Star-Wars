using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.ExternalApi.Querys;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.CQRS.Personages.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Services
{
    public class PersonageService : IPersonageService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PersonageService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<GenericResponse> GetAllAsync()
        {
            var personageQuery = new GetPersonagesQueryRequest();

            if (personageQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(personageQuery);
            return response;
        }

        public async Task<GenericResponse> GetByIdAsync(int id)
        {
            var personageQuery = new GetPersonageByIdQueryRequest(id);

            if (personageQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(personageQuery);
            return response;
        }

        public async Task<GenericResponse> GetByNameAsync(string name)
        {
            var personageQuery = new GetPersonageByNameQueryRequest(name);

            if (personageQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(personageQuery);
            return response;
        }

        public async Task<GenericResponse> CreateAsync(PersonageDTO personageDTO)
        {
            var CreatePersonageCommand = _mapper.Map<CreatePersonageCommandRequest>(personageDTO); 
            
            var response = await _mediator.Send(CreatePersonageCommand);
            return response;
        }

        public async Task<GenericResponse> UpdateAsync(PersonageDTO personageDTO)
        {
            var UpdatePersonageCommand = _mapper.Map<UpdatePersonageCommandRequest>(personageDTO);
            var response = await _mediator.Send(UpdatePersonageCommand);
            return response;
        }

        public async Task<GenericResponse> DeleteAsync(int id)
        {
            var deletePersonageCommand = new DeletePersonageCommandRequest(id);

            if (deletePersonageCommand is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(deletePersonageCommand);
            return response;
        }
    }
}
