using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FandomStarWars.Infra.Data.Repositories
{
    public class StatusTableRepository : IStatusTableRepository
    {
        private readonly DataContext _context;

        public StatusTableRepository(DataContext context)
        {
            _context = context;
        }

        public bool TableIsEmpty()
        {
            return !_context.Set<Movie>().Any();
        }
    }
}
