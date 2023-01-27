﻿using FandomStarWars.Domain.Entities;
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
            var movies = await _context.Movies
                .Include(p => p.Personages)
                .AsNoTracking()
                .ToListAsync();

            return movies;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies
                .Include(p => p.Personages)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
                
        }

        public async Task<Movie> GetByNameAsync(string title)
        {
            return await _context.Movies
                .Include(p => p.Personages)
                .AsNoTracking()
                .Where(x => x.Title == title)
                .FirstOrDefaultAsync();
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            await InsertMoviePersonage(movie);
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;           
        }

        public async Task InsertMoviePersonage(Movie movie)
        {
            var personagesMattch = new List<Personage>();
            foreach (var personage in movie.Personages)
            {
                var personageMatch = await _context.Personages.Where(x => x.Name == personage.Name).FirstOrDefaultAsync();
                personagesMattch.Add(personageMatch);
                Console.WriteLine(personageMatch.ToString());
            }
            movie.Personages = personagesMattch;
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
