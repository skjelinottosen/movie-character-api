using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories.Interfaces
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActorsAsync();
        Task<Actor> GetActorByIdAsync(Guid actorId);
        Task InsertActorAsync(Actor actor);
        void DeleteActor(Guid actorId);
        void UpdateActor(Actor actor);
        bool Exists(Guid id);
        MovieDbContext GetContext();
        Task SaveAsync();
        Task DisposeAsync();
    }
}
