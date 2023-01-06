using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Domain.Interfaces
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetAllAsync();
        Task<Film> GetByIdAsync(int id);
        Task<Film> GetByNameAsync(string name);
        Task<Film> CreateAsync(Film film);
        Task<Film> UpdateAsync(Film film);
        Task<Film> DeleteAsync(Film film);
    }
}
