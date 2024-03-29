﻿using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.CQRS.Validations.Personage;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Personages.Handlers.Commands
{
    public class UpdatePersonageCommandHandler : IRequestHandler<UpdatePersonageCommandRequest, GenericResponse>
    {
        private readonly IPersonageRepository _repository;
        private readonly IMapper _mapper;
        private readonly ValidateUpdatePersonage _validator;

        public UpdatePersonageCommandHandler(IPersonageRepository repository, IMapper mapper, ValidateUpdatePersonage validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GenericResponse> Handle(UpdatePersonageCommandRequest request, CancellationToken cancellationToken)
        {
            var results = _validator.Validate(request);

            if (!results.IsValid)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, parece que o Personagem contém dados inválidos",
                    Object = request.ErrorMensage(results.Errors)
                };
            }

            try
            {
                var personage = await _repository.GetByIdAsync(request.Id);
                if (personage is null)
                {
                    return new GenericResponse
                    {
                        IsSuccessful = false,
                        Message = "Ops, Nenhum personagem encontrado com este Id",
                        Object = request.ErrorMensage(results.Errors)
                    };
                }

                personage.Update(
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

                await _repository.UpdateAsync(personage);

                var personageDTO = _mapper.Map<PersonageDTO>(personage);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully updated personage",
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
