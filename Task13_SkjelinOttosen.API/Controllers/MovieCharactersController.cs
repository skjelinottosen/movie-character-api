using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCharactersController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MovieCharactersController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieCharacters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieCharacter>>> GetMovieCharacters()
        {
            return await _context.MovieCharacters.ToListAsync();
        }

        // GET: api/MovieCharacters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieCharacter>> GetMovieCharacter(Guid id)
        {
            var movieCharacter = await _context.MovieCharacters.FindAsync(id);

            if (movieCharacter == null)
            {
                return NotFound();
            }

            return movieCharacter;
        }

        // PUT: api/MovieCharacters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieCharacter(Guid id, MovieCharacter movieCharacter)
        {
            if (id != movieCharacter.CharacterId)
            {
                return BadRequest();
            }

            _context.Entry(movieCharacter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieCharacterExists(id))
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

        // POST: api/MovieCharacters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieCharacter>> PostMovieCharacter(MovieCharacter movieCharacter)
        {
            _context.MovieCharacters.Add(movieCharacter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieCharacterExists(movieCharacter.CharacterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieCharacter", new { id = movieCharacter.CharacterId }, movieCharacter);
        }

        // DELETE: api/MovieCharacters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieCharacter>> DeleteMovieCharacter(Guid id)
        {
            var movieCharacter = await _context.MovieCharacters.FindAsync(id);
            if (movieCharacter == null)
            {
                return NotFound();
            }

            _context.MovieCharacters.Remove(movieCharacter);
            await _context.SaveChangesAsync();

            return movieCharacter;
        }

        private bool MovieCharacterExists(Guid id)
        {
            return _context.MovieCharacters.Any(e => e.CharacterId == id);
        }
    }
}
