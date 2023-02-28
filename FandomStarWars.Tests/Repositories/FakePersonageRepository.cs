using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;

namespace FandomStarWars.Tests.Repositories
{
    public class FakePersonageRepository : IPersonageRepository
    {
        public Task<Personage> CreateAsync(Personage personage)
        {
            return null;
        }

        public Task<Personage> DeleteAsync(Personage personage)
        {
            return null;
        }

        public Task<IEnumerable<Personage>> GetAllAsync()
        {
            return null;
        }

        public Task<Personage> GetByIdAsync(int id)
        {
            return null;
        }

        public Task<Personage> GetByNameAsync(string name)
        {
            return null;
        }

        public Task<Personage> UpdateAsync(Personage personage)
        {
            return null;
        }
    }
}
