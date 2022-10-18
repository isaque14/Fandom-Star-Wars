using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FandomStarWars.Infra.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly DataContext _context;

        public FilmRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Film>> GetAllAsync()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Film> GetByIdAsync(int id)
        {
            return await _context.Films.FindAsync(id);
        }

        public async Task<Film> GetByNameAsync(string name)
        {
            return await _context.Films.FindAsync(name);
        }

        public async Task<Film> CreateAsync(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<Film> UpdateAsync(Film film)
        {
            _context.Update(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<Film> DeleteAsync(Film film)
        {
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
            return film;
        }
    }
}
