using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public FranchisesController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDto>>> GetFranchises()
        {
            // Stores all franchises in the list
            List<Franchise> franchises = await _context.Franchises.ToListAsync();

            // Maps all the data transfer objects to the domain objects
            List<FranchiseDto> franchiseDtos = _mapper.Map<List<FranchiseDto>>(franchises);

            // Returns the list of data transfer objects
            return franchiseDtos;
        }

        // GET: api/Franchises/c3934230-a4c7-4af7-b160-8b4afe930537
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiesHasMoviesDto>> GetFranchise(Guid id)
        {
            // Includes movies associated with the franchise
            var franchise = await _context.Franchises
                .Include(f => f.HasMovies)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (franchise == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var franchiseHasMoviesDto = _mapper.Map<FranchiesHasMoviesDto>(franchise);

            // Returns the list of data transfer objects
            return franchiseHasMoviesDto;
        }

        // GET: api/Franchises/id/allcharacters
        [HttpGet("{id}/allcharacter")]
        public async Task<ActionResult<FranchiseAllCharactersDto>> GetFranchiseAllCharacters(Guid id)
        {
            // Includes characters associated with the franchise
            var franchise = await _context.Franchises
                .Include(f => f.HasMovies).ThenInclude(m => m.HasCharacters).ThenInclude(mc => mc.Character)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (franchise == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var franchiseAllCharacters = _mapper.Map<FranchiseAllCharactersDto>(franchise);

            // Returns the list of data transfer objects
            return franchiseAllCharacters;
        }

        // PUT: api/Franchises/c3934230-a4c7-4af7-b160-8b4afe930537
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(Guid id, Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            _context.Entry(franchise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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

        // POST: api/Franchises
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // DELETE: api/Franchises/c3934230-a4c7-4af7-b160-8b4afe930537
        [HttpDelete("{id}")]
        public async Task<ActionResult<Franchise>> DeleteFranchise(Guid id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return franchise;
        }

        private bool FranchiseExists(Guid id)
        {
            return _context.Franchises.Any(e => e.Id == id);
        }
    }
}
