using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.ExternalApi.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;
using static FandomStarWars.Application.DTO_s.MovieDataExternalApiDTO;

namespace FandomStarWars.Application.Services
{
    public class ApiClientService : IApiClientService
    {
        private readonly IMediator _mediator;
        private readonly IPersonageService _personageService;
        private readonly IExternalApiService _externalApiService;
        private readonly IMovieService _movieService;

        public ApiClientService(IMediator mediator, IPersonageService personageService, IExternalApiService externalApiService, IMovieService movieService)
        {
            _mediator = mediator;
            _personageService = personageService;
            _externalApiService = externalApiService;
            _movieService = movieService;
        }

        public async Task<PersonageDTO> GetPersonageInExternalApiByIdAsync(int id)
        {
            var getPersonage = new GetPersonageExternalApiByIdQuery(id);

            if (getPersonage == null)
                throw new Exception($"API could not be loaded.");

            var personageApi = await _mediator.Send(getPersonage);

            return new PersonageDTO
            {
                Name = personageApi.Name,
                Height = personageApi.Height,
                Mass = personageApi.Mass,
                HairColor = personageApi.Hair_Color,
                SkinColor = personageApi.Skin_Color,
                EyeColor = personageApi.Eye_Color,
                BirthYear = personageApi.Birth_Year,
                Gender = personageApi.Gender,
                Homeworld = personageApi.Homeworld,
                Created = personageApi.Created,
                Edited = personageApi.Edited
            };
        }

        public async Task<IEnumerable<PersonageDTO>> GetAllPersonagesInExternalApiAsync()
        {
            int numberPage = 1;
            var getPersonageExternalApi = new GetPersonagesExternalApiByPageQuery(numberPage);

            if (getPersonageExternalApi == null)
                throw new Exception($"API could not be loaded.");

            var personagesAPi = await _mediator.Send(getPersonageExternalApi);

            var personagesDTO = new List<PersonageDTO>();

            var nextElement = true;
            while (nextElement)
            {
                foreach (var p in personagesAPi.Results)
                {
                    int idPlanet = 0;
                    var lastSegment = new Uri(p.Homeworld).Segments.Last();

                    int.TryParse(lastSegment.Remove(lastSegment.Length - 1), out idPlanet);

                    var getPlanetExternalApiByIdQuery = new GetPlanetExternalApiByIdQuery(idPlanet);
                    var planet = await _mediator.Send(getPlanetExternalApiByIdQuery);

                    personagesDTO.Add(new PersonageDTO
                    {
                        Name = p.Name,
                        Height = p.Height,
                        Mass = p.Mass,
                        HairColor = p.Hair_Color,
                        SkinColor = p.Skin_Color,
                        EyeColor = p.Eye_Color,
                        BirthYear = p.Birth_Year,
                        Gender = p.Gender,
                        Homeworld = planet.Name,
                        Created = p.Created,
                        Edited = p.Edited
                    });
                }

                numberPage++;

                var nextPage = new GetPersonagesExternalApiByPageQuery(numberPage);

                if (nextPage == null)
                    throw new Exception($"API could not be loaded.");

                if (personagesAPi.Next is null)
                    nextElement = false;

                else
                    personagesAPi = await _mediator.Send(nextPage);
            }


            return personagesDTO as IEnumerable<PersonageDTO>;
        }

        public async Task InsertPersonagesExternalApiIntoDataBase()
        {
            var personagesDTO = await GetAllPersonagesInExternalApiAsync();


            foreach (var personage in personagesDTO)
            {
                GenericResponse response = _personageService.GetByNameAsync(personage.Name).Result;

                if (!response.IsSuccessful)
                    await _personageService.CreateAsync(personage);
            }
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

                    var personagesId = new List<int>();
                    foreach (var personageDTO in personagesDTO)
                    {
                        var idPersonage = personageDTO.Id;
                        personagesId.Add(idPersonage);
                    }

                    filmsDTO.Add(new MovieDTO
                    {
                        Title = film.Title,
                        EpisodeId = film.Episode_Id,
                        OpeningCrawl = film.Opening_Crawl,
                        Director = film.Director,
                        Producer = film.Producer,
                        ReleaseDate = film.Release_Date,
                        PersonagesId = personagesId,
                        PersonagesDTO = personagesDTO
                    });

                }

                numberPage++;

                if (filmsApi.Next is null)
                    nextMovie = false;

            } while (nextMovie);

            return filmsDTO;
        }

        public async Task InsertFilmsExternalApiIntoDataBase()
        {
            var movieDTO = await GetAllFilmsInExternalApiAsync();

            foreach (var movie in movieDTO)
            {
                GenericResponse response = _movieService.GetByNameAsync(movie.Title).Result;

                if (!response.IsSuccessful)
                    await _movieService.CreateAsync(movie);
            }
        }
    }
}
