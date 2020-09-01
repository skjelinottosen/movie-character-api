using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories.Interfaces
{
    // Interface for CharacterRepository
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetCharactersAsync();
        Task<Character> GetCharacterByIdAsync(Guid characterId);
        Task InsertCharacterAsync(Character character);
        void DeleteCharacter(Guid characterId);
        void UpdateCharacter(Character character);
        bool Exists(Guid id);
        MovieDbContext GetContext();
        Task SaveAsync();
        Task DisposeAsync();
    }
}
