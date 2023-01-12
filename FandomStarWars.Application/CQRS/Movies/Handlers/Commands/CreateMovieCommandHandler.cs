using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, GenericResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            var personagesEntity = new List<Personage>();
            try
            {
                if (request is null)
                    throw new Exception("Personages is Requireds");


                //var list = _mapper.Map<List<Personage>>(request.Personages);
                foreach (var personageDTO in request.Personages)
                {
                    personagesEntity.Add(_mapper.Map<Personage>(personageDTO));
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
