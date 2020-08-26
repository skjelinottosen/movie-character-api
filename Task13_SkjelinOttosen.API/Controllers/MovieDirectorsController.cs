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
    public class MovieDirectorsController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MovieDirectorsController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieDirectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDirector>>> GetMovieDirectors()
        {
            return await _context.MovieDirectors.ToListAsync();
        }

        // GET: api/MovieDirectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDirector>> GetMovieDirector(Guid id)
        {
            var movieDirector = await _context.MovieDirectors.FindAsync(id);

            if (movieDirector == null)
            {
                return NotFound();
            }

            return movieDirector;
        }

        // PUT: api/MovieDirectors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieDirector(Guid id, MovieDirector movieDirector)
        {
            if (id != movieDirector.DirectorId)
            {
                return BadRequest();
            }

            _context.Entry(movieDirector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieDirectorExists(id))
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

        // POST: api/MovieDirectors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieDirector>> PostMovieDirector(MovieDirector movieDirector)
        {
            _context.MovieDirectors.Add(movieDirector);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieDirectorExists(movieDirector.DirectorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieDirector", new { id = movieDirector.DirectorId }, movieDirector);
        }

        // DELETE: api/MovieDirectors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDirector>> DeleteMovieDirector(Guid id)
        {
            var movieDirector = await _context.MovieDirectors.FindAsync(id);
            if (movieDirector == null)
            {
                return NotFound();
            }

            _context.MovieDirectors.Remove(movieDirector);
            await _context.SaveChangesAsync();

            return movieDirector;
        }

        private bool MovieDirectorExists(Guid id)
        {
            return _context.MovieDirectors.Any(e => e.DirectorId == id);
        }
    }
}
