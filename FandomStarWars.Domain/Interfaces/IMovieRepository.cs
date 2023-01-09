using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetByNameAsync(string name);
        Task<Movie> CreateAsync(Movie film);
        Task<Movie> UpdateAsync(Movie film);
        Task<Movie> DeleteAsync(Movie film);
    }
}
