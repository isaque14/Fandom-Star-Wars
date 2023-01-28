using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Handlers.Commands
{
    public class UpdateMovieCommandRequestHandler : IRequestHandler<UpdateMovieCommandRequest, GenericResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly IPersonageService _personageService;
        private readonly IPersonageRepository _personageRepository;

        public UpdateMovieCommandRequestHandler(IMapper mapper, IMovieRepository movieRepository, IPersonageService personageService, IPersonageRepository personageRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _personageService = personageService;
            _personageRepository = personageRepository;
        }

        public async Task<GenericResponse> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var movieEntity = await _movieRepository.GetByIdAsync(request.Id);
                if (movieEntity is null) throw new Exception("Movie Not Found By Id");

                var personages = new List<Personage>();

                foreach (var id in request.PersonagesId)
                {
                    var personageEntity = await _personageRepository.GetByIdAsync(id);
                    personages.Add(personageEntity);
                }

                movieEntity.Update(
                    request.Title,
                    request.EpisodeId,
                    request.OpeningCrawl,
                    request.Director,
                    request.Producer,
                    request.ReleaseDate,
                    personages);

                var response = _movieRepository.UpdateAsync(movieEntity).Result;
                var movieDTO = _mapper.Map<MovieDTO>(response);
                
                var personagesDTO = new List<PersonageDTO>();
                foreach (var personage in response.Personages)
                {
                    personagesDTO.Add(_mapper.Map<PersonageDTO>(personage));
                }
                movieDTO.PersonagesDTO = personagesDTO;

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully obtained movie",
                    Object = movieDTO
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
