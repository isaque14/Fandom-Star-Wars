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
            //var personage = new Personage("Madara", "teste", "teste", "teste", "teste", "teste", "teste", "teste", "teste");

            var list = new List<Personage>();
            list.Add(_personageRepository.GetByIdAsync(4).Result);
            
            var movie = new Movie("Movie Test", 17, "teste", "teste", "teste", "teste", list);


            //_context.Add(personage);

            _context.AddAsync(movie);
            await _context.SaveChangesAsync();
        }
    }
}
