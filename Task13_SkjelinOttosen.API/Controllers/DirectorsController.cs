using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs.DirectorDTOs;
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

        public DirectorsController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorListViewDto>>> GetDirectors()
        {
            // Stores all directors in the list
            List<Director> directors = await _context.Directors.ToListAsync();

            // Maps all the data transfer objects to the domain objects
            List<DirectorListViewDto> directorDtos = _mapper.Map<List<DirectorListViewDto>>(directors);

            // Returns the list of data transfer objects
            return directorDtos;
        }

        // GET: api/Directors/632fa20a-1c0d-4e71-ab07-aab66299964e
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDto>> GetDirector(Guid id)
        {
            var director = await _context.Directors.FindAsync(id);

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

            _context.Entry(director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirector", new { id = director.Id }, director);
        }

        // DELETE: api/Directors/632fa20a-1c0d-4e71-ab07-aab66299964e
        [HttpDelete("{id}")]
        public async Task<ActionResult<Director>> DeleteDirector(Guid id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();

            return director;
        }

        private bool DirectorExists(Guid id)
        {
            return _context.Directors.Any(e => e.Id == id);
        }
    }
}
