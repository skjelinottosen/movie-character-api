using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories.Interfaces
{
    // Interface for DirectorRepository
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetDirectorsAsync();
        Task<Director> GetDirectorByIdAsync(Guid DirectorId);
        Task InsertDirectorAsync(Director director);
        void DeleteDirector(Guid directorId);
        void UpdateDirector(Director director);
        bool Exists(Guid id);
        MovieDbContext GetContext();
        Task SaveAsync();
        Task DisposeAsync();
    }
}
