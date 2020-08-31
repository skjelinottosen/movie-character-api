using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private MovieDbContext _context;
        public ActorRepository(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public  async Task<Actor> GetActorByIdAsync(Guid actorId)
        {
            return await _context.Actors.FindAsync(actorId);
        }

        public async Task InsertActorAsync(Actor actor)
        {
           await _context.Actors.AddAsync(actor);
       
        }
        public void UpdateActor(Actor actor)
        {
           _context.Entry(actor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        
        }
        public void DeleteActor(Guid actorId)
        {
            Actor actor = _context.Actors.Find(actorId);
            _context.Actors.Remove(actor);
        }

        public bool Exists(Guid actorId)
        {
            return _context.Actors.Find(actorId) != null;
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
