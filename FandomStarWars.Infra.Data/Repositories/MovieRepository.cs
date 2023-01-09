using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FandomStarWars.Infra.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Films.FindAsync(id);
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await _context.Films.FindAsync(name);
        }

        public async Task<Movie> CreateAsync(Movie film)
        {
            try
            {
                _context.Films.Add(film);
                await _context.SaveChangesAsync();
                return film;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return film;
        }

        public async Task<Movie> UpdateAsync(Movie film)
        {
            _context.Update(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<Movie> DeleteAsync(Movie film)
        {
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
            return film;
        }
    }
}
