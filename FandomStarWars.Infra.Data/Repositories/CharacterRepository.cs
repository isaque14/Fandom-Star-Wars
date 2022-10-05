using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FandomStarWars.Infra.Data.Repositories
{
    public class CharacterRepository : IPersonageRepository
    {
        private readonly DataContext _context;

        public CharacterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personage>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Personage> GetByIdAsync(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task<Personage> GetByNameAsync(string name)
        {
            return await _context.Characters.FindAsync(name);
        }

        public async Task<Personage> CreateAsync(Personage personage)
        {
            _context.Characters.Add(personage);
            await _context.SaveChangesAsync();
            return personage;
        }

        public async Task<Personage> UpdateAsync(Personage personage)
        {
            _context.Characters.Update(personage);
            await _context.SaveChangesAsync();
            return personage;
        }

        public async Task<Personage> DeleteAsync(Personage personage)
        {
            _context.Characters.Remove(personage);
            await _context.SaveChangesAsync();
            return personage;
        }
    }
}
