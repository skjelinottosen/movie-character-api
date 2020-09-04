using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private MovieDbContext _context;
        public DirectorRepository(MovieDbContext context)
        {
            using (_context)
            {
                _context = context;
            }
        }
        public async Task<IEnumerable<Director>> GetDirectorsAsync()
        {
            using (_context)
            {
                return await _context.Directors.ToListAsync();
            }
        }

        public async Task<Director> GetDirectorByIdAsync(Guid directorId)
        {
            using (_context)
            {
                return await _context.Directors.FindAsync(directorId);
            }
        }

        public async Task InsertDirectorAsync(Director director)
        {
            using (_context)
            {
                await _context.Directors.AddAsync(director);
            }
        }
        public void UpdateDirector(Director director)
        {
            using (_context)
            {
                _context.Entry(director).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
        public void DeleteDirector(Guid directorId)
        {
            using (_context)
            {
                Director director = _context.Directors.Find(directorId);
                _context.Directors.Remove(director);
            }
        }

        public bool Exists(Guid directorId)
        {
            using (_context)
            {
                return _context.Directors.Find(directorId) != null;
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

