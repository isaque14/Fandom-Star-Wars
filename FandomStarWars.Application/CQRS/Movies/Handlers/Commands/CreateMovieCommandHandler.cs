using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.CQRS.Personages.Requests.Querys;
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

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper, IPersonageService personageService)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _personageService = personageService;
        }

        public async Task<GenericResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            var personagesEntity = new List<Personage>();
            try
            {
                if (request is null)
                    throw new Exception("Personages is Requireds");

                foreach (var id in request.PersonagesId)
                {
                    var personageEntity = _personageService.GetByIdAsync(id).Result;
                    personagesEntity.Add(_mapper.Map<Personage>(personageEntity.Object));
                }

                var filmEntity = new Movie(
                    request.Title,
                    request.EpisodeId,
                    request.OpeningCrawl,
                    request.Director,
                    request.Producer,
                    request.ReleaseDate,
                    personagesEntity
                );

                if (filmEntity is null)
                    throw new ApplicationException($"Error creating Movie");

                var movieCreated = await _movieRepository.CreateAsync(filmEntity);
                var movieDTO = _mapper.Map<MovieDTO>(movieCreated);

                var personagesDTO = new List<PersonageDTO>();
                foreach (var personage in movieCreated.Personages)
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
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = $"Error Creating Movie. {e.Message}"
                };
            }
        }
    }
}
