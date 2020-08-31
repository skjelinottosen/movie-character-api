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
    public class CharacterRepository : ICharacterRepository
    {
        private MovieDbContext _context;
        public CharacterRepository(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacterByIdAsync(Guid characterId)
        {
            return await _context.Characters.FindAsync(characterId);
        }

        public async Task InsertCharacterAsync(Character character)
        {
            await _context.Characters.AddAsync(character);

        }
        public void UpdateCharacter(Character character)
        {
            _context.Entry(character).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
        public void DeleteCharacter(Guid characterId)
        {
            Character character = _context.Characters.Find(characterId);
            _context.Characters.Remove(character);
        }

        public bool Exists(Guid characterId)
        {
            return _context.Characters.Find(characterId) != null;
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

