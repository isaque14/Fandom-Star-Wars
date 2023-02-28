using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Personage;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Handlers.Commands
{
    public class CreatePersonageCommandHandler : IRequestHandler<CreatePersonageCommandRequest, GenericResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;
        private readonly ValidateCreatePersonage _validator;

        public CreatePersonageCommandHandler(IPersonageRepository repository, IMapper mapper, ValidateCreatePersonage validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GenericResponse> Handle(CreatePersonageCommandRequest request, CancellationToken cancellationToken)
        {
            var results = _validator.Validate(request);

            if (!results.IsValid)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = request.ErrorMensage(results.Errors)
                };
            }

            var personage = new Personage(
                name: request.Name,
                height: request.Height,
                mass: request.Mass,
                hairColor: request.HairColor,
                skinColor: request.SkinColor,
                eyeColor: request.EyeColor,
                birthYear: request.BirthYear,
                gender: request.Gender,
                homeworld: request.Homeworld
            );

            _repository.CreateAsync(personage);
            var personageDTO = _mapper.Map<PersonageDTO>(personage);
            return new GenericResponse
            {
                IsSuccessful = true,
                Message = "successfully created personage",
                Object = personageDTO
            };
        }
    }

}
