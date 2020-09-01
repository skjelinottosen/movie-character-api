using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories.Interfaces
{
    // Interface for FranchiseRepository
    public interface IFranchiseRepository 
    {
        Task<IEnumerable<Franchise>> GetFranchisesAsync();
        Task<Franchise> GetFranchiseByIdAsync(Guid franchiseId);
        Task InsertFranchiseAsync(Franchise franchise);
        void DeleteFranchise(Guid franchiseId);
        void UpdateFranchise(Franchise franchise);
        bool Exists(Guid id);
        MovieDbContext GetContext();
        Task SaveAsync();
        Task DisposeAsync();
    }
}
