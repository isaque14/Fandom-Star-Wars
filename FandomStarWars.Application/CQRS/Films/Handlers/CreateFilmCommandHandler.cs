using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Films.Requests.Commands;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Films.Handlers
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommandRequest, GenericResponse>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(CreateFilmCommandRequest request, CancellationToken cancellationToken)
        {
            var personagesEntity = new List<Personage>();
            try
            {
                if (request.FilmDTO.PersonagesDTO is null)
                    throw new Exception("Personages is Requireds");

                foreach (var personage in request.FilmDTO.PersonagesDTO)
                {
                    personagesEntity.Add(_mapper.Map<Personage>(personage));
                }

                var filmEntity = new Film(
                    request.FilmDTO.Title,
                    request.FilmDTO.EpisodeId,
                    request.FilmDTO.OpeningCrawl,
                    request.FilmDTO.Director,
                    request.FilmDTO.Producer,
                    request.FilmDTO.ReleaseDate,
                    personagesEntity
                );

                if (filmEntity is null)
                    throw new ApplicationException($"Error creating Movie");

                var movieCreated = await _filmRepository.CreateAsync(filmEntity);
                var movieDTO = _mapper.Map<FilmDTO>(movieCreated);

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
                    IsSuccessful = true,
                    Message = $"Error Deleting Personage. {e.Message}"
                };
            }
        }
    }
}
