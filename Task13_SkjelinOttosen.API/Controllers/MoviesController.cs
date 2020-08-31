using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs.MovieDTOs;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieListViewDto>>> GetMovies()
        {
            // Stores all movies in the list
            List<Movie> movie = await _context.Movies.ToListAsync();

            // Maps all the data transfer objects to the domain objects
            List<MovieListViewDto> movieDtos = _mapper.Map<List<MovieListViewDto>>(movie);

            // Returns the list of data transfer objects
            return movieDtos;
        }

        // GET: api/Movies/80d7d9f6-f465-4d85-bea8-cdadffa4abc3
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(Guid id)
        {
          
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var movieDto = _mapper.Map<MovieDto>(movie);

            // Returns the data transfer object
            return movieDto;
        }

        // GET: api/Movies/80d7d9f6-f465-4d85-bea8-cdadffa4abc3/characters-actors
        [HttpGet("{id}/characters-actors")]
        public async Task<ActionResult<MovieCharactersActorsDto>> GetMovieCharactersActors(Guid id)
        {
            // Includes moviecharacters and actors acting in the movie
            var movie = await _context.Movies.Include(m => m.HasCharacters)
                .ThenInclude(mc => mc.Character)
                .ThenInclude(c => c.AppearInMovies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var movieCharactersActorsDto = _mapper.Map<MovieCharactersActorsDto>(movie);

            // Returns the data transfer object
            return movieCharactersActorsDto;
        }

        // PUT: api/Movies/80d7d9f6-f465-4d85-bea8-cdadffa4abc3
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(Guid id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/80d7d9f6-f465-4d85-bea8-cdadffa4abc3
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(Guid id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(Guid id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
