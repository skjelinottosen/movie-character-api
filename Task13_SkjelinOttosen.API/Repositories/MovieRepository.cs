using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            using (_context)
            {
                return await _context.Movies.ToListAsync();
            }
        }

        public async Task<Movie> GetMovieByIdAsync(Guid movieId)
        {
            using (_context)
            {
                return await _context.Movies.FindAsync(movieId);
            }
        }

        public async Task InsertMovieAsync(Movie movie)
        {
            using (_context)
            {
                await _context.Movies.AddAsync(movie);
            }

        }
        public void UpdateMovie(Movie movie)
        {
            using (_context)
            {
                _context.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }
        public void DeleteMovie(Guid movieId)
        {
            using (_context)
            {
                Movie movie = _context.Movies.Find(movieId);
                _context.Movies.Remove(movie);
            }
        }

        public bool Exists(Guid movieId)
        {
            using (_context)
            {
                return _context.Movies.Find(movieId) != null;
            }
        }

        public MovieDbContext GetContext()
        {
            using (_context)
            {
                return _context;
            }
        }

        public async Task SaveAsync()
        {
            using (_context)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task DisposeAsync()
        {
            using (_context)
            {
                await _context.DisposeAsync();
            }
        }
    }
}

