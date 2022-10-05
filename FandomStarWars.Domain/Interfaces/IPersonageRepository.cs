using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Domain.Interfaces
{
    public interface IPersonageRepository
    {
        Task<IEnumerable<Personage>> GetAllAsync();
        Task<Personage> GetByIdAsync(int id);
        Task<Personage> GetByNameAsync(string name);
        Task<Personage> CreateAsync(Personage personage);   
        Task<Personage> UpdateAsync(Personage personage);
        Task<Personage> DeleteAsync(Personage personage);
    }
}
