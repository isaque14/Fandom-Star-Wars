using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetByNameAsync(string name);
        void CreateAsync(Movie film);
        void UpdateAsync(Movie film);
        void DeleteAsync(Movie film);
    }
}
