using AutoMapper;
using FandomStarWars.Application.DTO_s;
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
                var personage = _repository.GetByIdAsync(request.Id).Result;
                if (personage is null) throw new ApplicationException($"Error Updating Personage");

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
                var response = new UpdatePersonageCommandResponse(personageDTO);
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
