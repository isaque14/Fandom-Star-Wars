using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Films.Requests.Commands;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces;
using MediatR;
using static FandomStarWars.Application.DTO_s.MovieDataExternalApiDTO;

namespace FandomStarWars.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPersonageService _personageService;

        public MovieService(IMapper mapper, IMediator mediator, IPersonageService personageService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _personageService = personageService;
        }

        public async Task<IEnumerable<MovieDTO>> GetAllFilmsInExternalApiAsync()
        {
            var numberPage = 1;
            var filmsDTO = new List<MovieDTO>();
            RootFilms filmsApi;
            
            do
            {
                var getFilms = new GetMoviesExternalApiByPageQuery(numberPage);

                if (getFilms == null)
                    throw new Exception($"API could not be loaded.");

                filmsApi = await _mediator.Send(getFilms);
            
                foreach (var film in filmsApi.Results)
                {
                    var personagesDTO = new List<PersonageDTO>();
                   
                    foreach (var personage in film.Characters)
                    {
                        int idPersonage = 0;
                        var lastSegment = new Uri(personage).Segments.Last();

                        int.TryParse(lastSegment.Remove(lastSegment.Length - 1), out idPersonage);

                        GenericResponse personageResponse = await _personageService.GetByIdAsync(idPersonage);
                        

                        personagesDTO.Add(personageResponse.Object as PersonageDTO);
                        Console.WriteLine(personagesDTO);
                    }

                    filmsDTO.Add(new MovieDTO(
                          film.Title,
                          film.Episode_Id,
                          film.Opening_Crawl,
                          film.Director,
                          film.Producer,
                          film.Release_Date,
                          personagesDTO
                          ));
                }

                numberPage++;
            } while (filmsApi.Next != null);

            return filmsDTO;
        }

        public async Task InsertFilmsExternalApiIntoDataBase()
        {
            var filmsDTO = await GetAllFilmsInExternalApiAsync();

            foreach (var film in filmsDTO)
            {
                await CreateAsync(film);
            }
        }

        public Task<GenericResponse> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDTO> GetFilmInExternalApiByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResponse> CreateAsync(MovieDTO filmDTO)
        {
            var createFilmCommand = _mapper.Map<CreateMovieCommandRequest>(filmDTO);
            createFilmCommand.FilmDTO.PersonagesDTO = filmDTO.PersonagesDTO;
            var response = await _mediator.Send(createFilmCommand);
            return response;
        }

        public Task<GenericResponse> UpdateAsync(MovieDTO filmDTO)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
