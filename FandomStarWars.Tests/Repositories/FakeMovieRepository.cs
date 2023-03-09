using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using System.IO;
using System.Xml.Linq;

namespace FandomStarWars.Tests.Repositories
{
    public class FakeMovieRepository : IMovieRepository
    {
        public async Task CreateAsync(Movie film)
        {
            
        }

        public async Task DeleteAsync(Movie film)
        {
            
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            var mock = new List<Movie>();
            var movie = new Movie(
                3,
                "Title",
                78,
                "OpeningTests",
                "Director",
                "Producer",
                "ReleaseDate"
                );
            mock.Add( movie );

            return Task.FromResult( mock as IEnumerable<Movie> );
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            var movie = new Movie(
                3,
                "Title",
                78,
                "OpeningTests",
                "Director",
                "Producer",
                "ReleaseDate"
                );
            
            return Task.FromResult(movie);
        }

        public Task<Movie> GetByNameAsync(string name)
        {
            var movie = new Movie(
                3,
                "Title",
                78,
                "OpeningTests",
                "Director",
                "Producer",
                "ReleaseDate"
                );

            return Task.FromResult(movie);
        }

        public async Task UpdateAsync(Movie film)
        {
            
        }
    }
}
