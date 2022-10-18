using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces;
using MediatR;
using static FandomStarWars.Application.DTO_s.FilmsDataExternalApiDTO;

namespace FandomStarWars.Application.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FilmService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
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
                    filmsDTO.Add(new FilmDTO(
                          film.Title,
                          film.Episode_Id,
                          film.Opening_Crawl,
                          film.Director,
                          film.Producer,
                          film.Release_Date,
                          DateTime.Now.ToString()
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

        public Task CreateAsync(FilmDTO filmDTO)
        {
            var Create
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
