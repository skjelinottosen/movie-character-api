using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs.DirectorDTOs;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDirectorRepository _directorRepository;

        public DirectorsController(MovieDbContext context, IMapper mapper, IDirectorRepository directorRepository)
        {
            _context = context;
            _mapper = mapper;
            _directorRepository = directorRepository;
        }

        // GET: api/Directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorListViewDto>>> GetDirectors()
        {
            // Stores all directors in the list using the DirectorRepository class
            List<Director> directors = (List<Director>)await _directorRepository.GetDirectorsAsync();

            // Maps all the data transfer objects to the domain objects
            List<DirectorListViewDto> directorDtos = _mapper.Map<List<DirectorListViewDto>>(directors);

            // Returns the list of data transfer objects
            return directorDtos;
        }

        // GET: api/Directors/632fa20a-1c0d-4e71-ab07-aab66299964e
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDto>> GetDirector(Guid id)
        {
            // Stores the Director using the DirectorRepository class
            var director = await _directorRepository.GetDirectorByIdAsync(id);

            if (director == null)
            {
                return NotFound();
            }
           
            // Maps the data transfer object to the domain object
            var directorDto = _mapper.Map<DirectorDto>(director);

            // Returns the data transfer object
            return directorDto;
        }

        // PUT: api/Directors/632fa20a-1c0d-4e71-ab07-aab66299964e
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(Guid id, Director director)
        {
            if (id != director.Id)
            {
                return BadRequest();
            }

            // Updates the Director using the DirectorRepository class
            _directorRepository.UpdateDirector(director);

            try
            {
                // Saves changes using the DirectorRepository class
                await _directorRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/Directors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Director>> PostDirector(Director director)
        {
            // Inserts a new Director and saves changes using the DirectorRepository class
            await _directorRepository.InsertDirectorAsync(director);
            await _directorRepository.SaveAsync();

            return CreatedAtAction("GetDirector", new { id = director.Id }, director);
        }

        // DELETE: api/Directors/632fa20a-1c0d-4e71-ab07-aab66299964e
        [HttpDelete("{id}")]
        public async Task<ActionResult<Director>> DeleteDirector(Guid id)
        {
            var director = await _directorRepository.GetDirectorByIdAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            // Deletes the director and saves the changes using the DirectorRepository class
            _directorRepository.DeleteDirector(id);
            await _directorRepository.SaveAsync();
           
            return director;
        }

        private bool DirectorExists(Guid id)
        {
            // Checks if the Director exist using the DirectorRepository class
            return _directorRepository.Exists(id);
        }
    }
}
