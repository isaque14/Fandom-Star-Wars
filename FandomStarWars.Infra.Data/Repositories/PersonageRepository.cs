using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FandomStarWars.Infra.Data.Repositories
{
    public class PersonageRepository : IPersonageRepository
    {
        private readonly DataContext _context;

        public PersonageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personage>> GetAllAsync()
        {
            return await _context.Personages
                .Include(x => x.Movies)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Personage> GetByIdAsync(int id)
        {
            var result = await _context.Personages.FindAsync(id);
            return result;
        }

        public async Task<Personage> GetByNameAsync(string name)
        {
            return await _context.Personages.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        //public async Task<IEnumerable<Personage>> GetAllPersonagesByIdMovie(int movieId)
        //{
        //    return await _context.Personages;
        //    //    //.Include(p => p.)
        //    //    .AsNoTracking().Where(x => x.Movies.)
        //}

        public async Task CreateAsync(Personage personage)
        {
            await _context.Personages.AddAsync(personage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Personage personage)
        {
            _context.Personages.Update(personage);
            _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Personage personage)
        {
            _context.Personages.Remove(personage);
            await _context.SaveChangesAsync();
        }
    }
}
