using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Films.Commands;
using FandomStarWars.Application.Interfaces;
using MediatR;
using static FandomStarWars.Application.DTO_s.FilmsDataExternalApiDTO;

namespace FandomStarWars.Application.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPersonageService _personageService;

        public FilmService(IMapper mapper, IMediator mediator, IPersonageService personageService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _personageService = personageService;
        }

        public async Task<IEnumerable<FilmDTO>> GetAllFilmsInExternalApiAsync()
        {
            var numberPage = 1;
            var filmsDTO = new List<FilmDTO>();
            RootFilms filmsApi;
            
            do
            {
                var getFilms = new GetFilmsExternalApiByPageQuery(numberPage);

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

                        personagesDTO.Add(_personageService.GetByIdAsync(idPersonage).Result);
                        Console.WriteLine(personagesDTO);
                    }

                    filmsDTO.Add(new FilmDTO(
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

        public Task<IEnumerable<FilmDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FilmDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FilmDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<FilmDTO> GetFilmInExternalApiByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(FilmDTO filmDTO)
        {
            var createFilmCommand = _mapper.Map<CreateFilmCommandRequest>(filmDTO);
            createFilmCommand.FilmDTO.PersonagesDTO = filmDTO.PersonagesDTO;
            await _mediator.Send(createFilmCommand);
        }

        public Task UpdateAsync(FilmDTO filmDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
