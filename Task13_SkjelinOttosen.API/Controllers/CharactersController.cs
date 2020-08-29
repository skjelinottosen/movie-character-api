using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs;
using Task13_SkjelinOttosen.API.DTOs.CharacterDTOs;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public CharactersController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
        {
            // Stores all characters in the list
            List<Character> characters = await _context.Characters.ToListAsync();

            // Maps all the data transfer objects to the domain objects
            List<CharacterDto> characterDtos = _mapper.Map <List<CharacterDto>>(characters);

            // Returns the list of data transfer objects
            return characterDtos;
        }

        // GET: api/Characters/f0b9ad0f-9def-45ca-89c2-103aa847fb17
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(Guid id)
        {
            // Includes the actors who have played the character
            var character = await _context.Characters.FindAsync(id);
              

            if (character == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var characterDto = _mapper.Map<CharacterDto>(character);

            return characterDto;
        }

        // GET: api/Characters/f0b9ad0f-9def-45ca-89c2-103aa847fb17/actors
        [HttpGet("{id}/actors")]
        public async Task<ActionResult<CharacterPlayedByActorsDto>> GetCharacterPlayedByActors(Guid id)
        {
            // Includes the actors who have played the character
            var character = await _context.Characters.
                Include(c => c.AppearInMovies)
                .ThenInclude(a => a.Actor).FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var characterDto = _mapper.Map<CharacterPlayedByActorsDto>(character);

            return characterDto;
        }



        // PUT: api/Characters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(Guid id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Characters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> DeleteCharacter(Guid id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return character;
        }

        private bool CharacterExists(Guid id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
