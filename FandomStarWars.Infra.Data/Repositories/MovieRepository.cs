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
            var movies = await _context.Movies.Include("Personages").ToListAsync();
            //foreach (var movie in movies)
            //{
            //    var personages = new List<Personage>();
            //    var a = _context.Personages.Where(x => x.Films.Any(p => p.Title == movie.Title)).ToListAsync();
            //    //movie.Personages = personages;
            //}
            return movies;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await _context.Movies.FindAsync(name);
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;           
        }

        public async Task<Movie> UpdateAsync(Movie film)
        {
            _context.Update(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<Movie> DeleteAsync(Movie film)
        {
            _context.Movies.Remove(film);
            await _context.SaveChangesAsync();
            return film;
        }
    }
}
