using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetByNameAsync(string name);
        Task CreateAsync(Movie film);
        Task UpdateAsync(Movie film);
        Task DeleteAsync(Movie film);
    }
}
