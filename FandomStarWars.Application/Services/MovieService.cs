using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.ExternalApi.Querys;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.CQRS.Movies.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;
using static FandomStarWars.Application.DTO_s.MovieDataExternalApiDTO;

namespace FandomStarWars.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPersonageService _personageService;
        private readonly IExternalApiService _externalApiService;

        public MovieService(IMapper mapper, IMediator mediator, IPersonageService personageService, IExternalApiService externalApiService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _personageService = personageService;
            _externalApiService = externalApiService;
        }

        public async Task<IEnumerable<MovieDTO>> GetAllFilmsInExternalApiAsync()
        {
            var numberPage = 1;
            var filmsDTO = new List<MovieDTO>();
            RootFilms filmsApi;
            var nextMovie = true;
            
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
                        var getPersonageApi = await _externalApiService.GetPersonageByIdAsync(idPersonage);
                        GenericResponse personageResponse = await _personageService.GetByNameAsync(getPersonageApi.Name);
                        

                        personagesDTO.Add(personageResponse.Object as PersonageDTO);
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

                if (filmsApi.Next is null)
                    nextMovie = false;
                
            } while (nextMovie);

            return filmsDTO;
        }

        public async Task InsertFilmsExternalApiIntoDataBase()
        {
            var filmsDTO = await GetAllFilmsInExternalApiAsync();

            foreach (var film in filmsDTO)
            {
                var response = await CreateAsync(film);
            }
        }

        public async Task<GenericResponse> GetAllAsync()
        {
            var getMoviesQuery = new GetMoviesQueryRequest();
            if (getMoviesQuery is null) 
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(getMoviesQuery);
            return response;
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
            createFilmCommand.Personages = filmDTO.PersonagesDTO;
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
