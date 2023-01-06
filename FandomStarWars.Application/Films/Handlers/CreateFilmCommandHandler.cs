using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Films.Commands;
using FandomStarWars.Application.Films.Responses;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Films.Handlers
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommandRequest, CreateFilmCommandResponse>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<CreateFilmCommandResponse> Handle(CreateFilmCommandRequest request, CancellationToken cancellationToken)
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
                    throw new ApplicationException($"Error creating Personage");

                var filmCreated = await _filmRepository.CreateAsync(filmEntity);
                var response = new CreateFilmCommandResponse(filmCreated: _mapper.Map<FilmDTO>(filmCreated));
                response.IsSuccessful = true;
                response.Message = "successfully deleted personage";
                return response;
            }
            catch (Exception e)
            {
                return new CreateFilmCommandResponse { 
                    IsSuccessful = true,
                    Message = $"Error Deleting Personage. {e.Message}"
                };
            }
        }
    }
}
