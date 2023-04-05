using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.CQRS.Personages.Requests.Querys;
using FandomStarWars.Application.CQRS.Validations.Movie;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, GenericResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IPersonageService _personageService;
        private readonly ValidateCreateMovie _validator;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper, IPersonageService personageService, ValidateCreateMovie validator)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _personageService = personageService;
            _validator = validator;
        }

        public async Task<GenericResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            var personagesEntity = new List<Personage>();
           
            var results = _validator.Validate(request);

            if (!results.IsValid)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, Dados inválidos no Filme, verifique is erros abaixo",
                    Object = results.Errors
                };
            }

            foreach (var id in request.PersonagesId)
            {
                var personageEntity = _personageService.GetByIdAsync(id).Result;
                personagesEntity.Add(_mapper.Map<Personage>(personageEntity.Object));
            }

            var movieEntity = new Movie(
                request.Title,
                request.EpisodeId,
                request.OpeningCrawl,
                request.Director,
                request.Producer,
                request.ReleaseDate,
                personagesEntity
            );

            await _movieRepository.CreateAsync(movieEntity);
            var movieDTO = _mapper.Map<MovieDTO>(movieEntity);

            var personagesDTO = new List<PersonageDTO>();
            foreach (var personage in movieEntity.Personages)
            {
                personagesDTO.Add(_mapper.Map<PersonageDTO>(personage));
            }
            movieDTO.PersonagesDTO = personagesDTO;
                
            return new GenericResponse
            {
                IsSuccessful = true,
                Message = "Successfully creating Movie",
                Object = movieDTO
            };
        }
    }
}
