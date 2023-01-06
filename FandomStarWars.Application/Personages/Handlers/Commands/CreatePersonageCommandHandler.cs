using AutoMapper;
using FandomStarWars.Application.DTO_s;
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
                var personage = new Personage(
                    name: request.Name,
                    height:  request.Height,
                    mass: request.Mass,
                    hairColor:  request.HairColor,
                    skinColor: request.SkinColor,
                    eyeColor: request.EyeColor,
                    birthYear: request.BirthYear,
                    gender: request.Gender,
                    homeworld: request.Homeworld
                );
                
                if (personage is null)
                    throw new ApplicationException($"Error creating Personage");

                await _repository.CreateAsync(personage);

                var personageDTO = _mapper.Map<PersonageDTO>(personage);
                var response = new CreatePersonageCommandResponse(personageDTO);

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
