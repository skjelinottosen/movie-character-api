using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs.MovieDTOs;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
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
        private readonly IMovieRepository _movieRepository;

        public MoviesController(MovieDbContext context, IMapper mapper, IMovieRepository movieRepository)
        {
            _context = context;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieListViewDto>>> GetMovies()
        {
            // Stores all movies in the list using the MovieRepository class
            List<Movie> movie = (List<Movie>)await _movieRepository.GetMoviesAsync();

            // Maps all the data transfer objects to the domain objects
            List<MovieListViewDto> movieDtos = _mapper.Map<List<MovieListViewDto>>(movie);

            // Returns the list of data transfer objects
            return movieDtos;
        }

        // GET: api/Movies/80d7d9f6-f465-4d85-bea8-cdadffa4abc3
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(Guid id)
        {
            // Stores Movie using the MovieRepository class
            var movie = await _movieRepository.GetMovieByIdAsync(id);

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
            // Stores movie includes moviecharacters and actors acting in the movie
            // Using the MovierRepository class
            var movie = await _movieRepository.GetContext().Movies
                .Include(m => m.HasCharacters)
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

            // Updates the Movie using the MovieRepository class
            _movieRepository.UpdateMovie(movie);

            try
            {
                // Saves the changes using the MovieRepository class
                await _movieRepository.SaveAsync();
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
            // Inserts a new Movie and saves the changes using the MovieRepository class
            await _movieRepository.InsertMovieAsync(movie);
            await _movieRepository.SaveAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/80d7d9f6-f465-4d85-bea8-cdadffa4abc3
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(Guid id)
        {
            // Stores the movie using the MovieRepositrory class
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            // Deletes the Movie and saves the changes using the MovieRepository
            _movieRepository.DeleteMovie(id);
            await _movieRepository.SaveAsync();

            return movie;
        }

        private bool MovieExists(Guid id)
        {
            // Check if the Movie exists using the MovieRepository class 
            return _movieRepository.Exists(id);
        }
    }
}
