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
            using (_context)
            {
                return await _context.Characters.ToListAsync();
            }
        }

        public async Task<Character> GetCharacterByIdAsync(Guid characterId)
        {
            using (_context)
            {
                return await _context.Characters.FindAsync(characterId);
            }
        }

        public async Task InsertCharacterAsync(Character character)
        {
            using (_context)
            {
                await _context.Characters.AddAsync(character);
            }

        }
        public void UpdateCharacter(Character character)
        {
            using (_context)
            {
                _context.Entry(character).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }
        public void DeleteCharacter(Guid characterId)
        {
            using (_context)
            {
                Character character = _context.Characters.Find(characterId);
                _context.Characters.Remove(character);
            }
        }

        public bool Exists(Guid characterId)
        {
            using (_context)
            {
                return _context.Characters.Find(characterId) != null;
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

