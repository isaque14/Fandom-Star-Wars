using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Domain.Interfaces
{
    public interface IPersonageRepository
    {
        Task<IEnumerable<Personage>> GetAllAsync();
        Task<Personage> GetByIdAsync(int id);
        Task<Personage> GetByNameAsync(string name);
        void CreateAsync(Personage personage);   
        void UpdateAsync(Personage personage);
        void DeleteAsync(Personage personage);
        //Task<IEnumerable<Personage>> GetAllPersonagesByIdMovie(int movieId);
    }
}
