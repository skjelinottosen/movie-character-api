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
            _context = context;
        }
        public async Task<IEnumerable<Director>> GetDirectorsAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director> GetDirectorByIdAsync(Guid directorId)
        {
            return await _context.Directors.FindAsync(directorId);
        }

        public async Task InsertDirectorAsync(Director director)
        {
            await _context.Directors.AddAsync(director);

        }
        public void UpdateDirector(Director director)
        {
            _context.Entry(director).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
        public void DeleteDirector(Guid directorId)
        {
            Director director = _context.Directors.Find(directorId);
            _context.Directors.Remove(director);
        }

        public bool Exists(Guid directorId)
        {
            return _context.Directors.Find(directorId) != null;
        }

        public MovieDbContext GetContext()
        {
            return _context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

