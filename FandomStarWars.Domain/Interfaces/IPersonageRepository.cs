using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Domain.Interfaces
{
    public interface IPersonageRepository
    {
        Task<IEnumerable<Personage>> GetAllAsync();
        Task<Personage> GetByIdAsync(int id);
        Task<Personage> GetByNameAsync(string name);
        Task CreateAsync(Personage personage);   
        Task UpdateAsync(Personage personage);
        Task DeleteAsync(Personage personage);
        //Task<IEnumerable<Personage>> GetAllPersonagesByIdMovie(int movieId);
    }
}
