using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;

namespace FandomStarWars.Tests.Repositories
{
    public class FakePersonageRepository : IPersonageRepository
    {
        public void CreateAsync(Personage personage)
        {
            
        }

        public void DeleteAsync(Personage personage)
        {
            
        }

        public Task<IEnumerable<Personage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Personage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Personage> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Personage personage)
        {
            
        }
    }
}
