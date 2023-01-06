using FandomStarWars.Application.DTO_s;
using Refit;
using static FandomStarWars.Application.DTO_s.FilmsDataExternalApiDTO;
using static FandomStarWars.Application.DTO_s.PersonageDataExternalApiDTO;

namespace FandomStarWars.Application.Interfaces.APIClient
{
    public interface IExternalApiService
    {
        [Get("/people/?page={numberPage}")]
        Task<Root> GetPersonagesByPageAsync(int numberPage);

        [Get("/people/{id}")]
        Task<PersonageDataExternalApiDTO> GetPersonageByIdAsync(int id);

        [Get("/films/?page={numberPage}")]
        Task<RootFilms> GetFilmsByPageAsync(int numberPage);

        [Get("/planets/{id}")]
        Task<PlanetDataExternalApiDTO> GetPlanetByIdAsync(int id);
    }
}