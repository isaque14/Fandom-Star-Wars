using FandomStarWars.Application.DTO_s;

namespace FandomStarWars.Application.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmDTO>> GetAllAsync();
        Task<FilmDTO> GetByIdAsync(int id);
        Task<FilmDTO> GetByNameAsync(string name);
        Task CreateAsync(FilmDTO filmDTO);
        Task UpdateAsync(FilmDTO filmDTO);
        Task DeleteAsync(int id);

        Task InsertFilmsExternalApiIntoDataBase();
        Task<FilmDTO> GetFilmInExternalApiByIdAsync(int id);
        Task<IEnumerable<FilmDTO>> GetAllFilmsInExternalApiAsync();
    }
}
