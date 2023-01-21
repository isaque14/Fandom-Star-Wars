using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;

namespace FandomStarWars.Infra.Data.Repositories
{
    public class MockRepository : IMockRepository
    {
        private readonly DataContext _context;
        private readonly IPersonageRepository _personageRepository;

        public MockRepository(DataContext context, IPersonageRepository personageRepository)
        {
            _context = context;
            _personageRepository = personageRepository;
        }

        public async Task SeedBank()
        {
            var personage = new Personage("Madara", "teste", "teste", "teste", "teste", "teste", "teste", "teste", "teste");
            var personage2 = new Personage("Kurama", "teste", "teste", "teste", "teste", "teste", "teste", "teste", "teste");
            var personage3 = new Personage("Kaguya", "teste", "teste", "teste", "teste", "teste", "teste", "teste", "teste");

            var list = new List<Personage>();
            list.Add(personage);
            list.Add(personage2);
            list.Add(personage3);
            
            var movie = new Movie("Movie Test", 17, "teste", "teste", "teste", "teste");


            //_context.Add(personage);

            //_context.Movies.Where(   AddAsync(movie) _context.Personages.Find(12));


            //_context.Personages.AddAsync(personage);
            //_context.Personages.AddAsync(personage2);
            //_context.Personages.AddAsync(personage3);
            await _context.SaveChangesAsync();
        }
    }
}
