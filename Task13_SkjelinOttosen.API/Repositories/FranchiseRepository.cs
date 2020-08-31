using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories
{
    public class FranchiseRepository : IFranchiseRepository
    {
        private MovieDbContext _context;
        public FranchiseRepository(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Franchise>> GetFranchisesAsync()
        {
            return await _context.Franchises.ToListAsync();
        }

        public async Task<Franchise> GetFranchiseByIdAsync(Guid franchiseId)
        {
            return await _context.Franchises.FindAsync(franchiseId);
        }

        public async Task InsertFranchiseAsync(Franchise franchise)
        {
            await _context.Franchises.AddAsync(franchise);

        }
        public void UpdateFranchise(Franchise franchise)
        {
            _context.Entry(franchise).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
        public void DeleteFranchise(Guid franchiseId)
        {
            Franchise franchise = _context.Franchises.Find(franchiseId);
            _context.Franchises.Remove(franchise);
        }

        public bool Exists(Guid franchiseId)
        {
            return _context.Franchises.Find(franchiseId) != null;
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

