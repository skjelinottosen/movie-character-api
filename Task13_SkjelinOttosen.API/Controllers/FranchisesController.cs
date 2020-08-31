using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
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
        private readonly IFranchiseRepository _franchiseRepository;

        public FranchisesController(MovieDbContext context, IMapper mapper, IFranchiseRepository franchiseRepository)
        {
            _context = context;
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseListViewDto>>> GetFranchises()
        {
            // Stores all franchises in the list
            List<Franchise> franchises = (List<Franchise>)await _franchiseRepository.GetFranchisesAsync();

            // Maps all the data transfer objects to the domain objects
            List<FranchiseListViewDto> franchiseDtos = _mapper.Map<List<FranchiseListViewDto>>(franchises);

            // Returns the list of data transfer objects
            return franchiseDtos;
        }

        // GET: api/Franchises/c3934230-a4c7-4af7-b160-8b4afe930537
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDto>> GetFranchise(Guid id)
        {
            // Includes movies associated with the franchise
            var franchise = await _franchiseRepository.GetFranchiseByIdAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var franchiseDto = _mapper.Map<FranchiseDto>(franchise);

            // Returns the list of data transfer objects
            return franchiseDto;
        }

        // GET: api/Franchises/c3934230-a4c7-4af7-b160-8b4afe930537/movies
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<FranchiseAllMoviesDto>> GetFranchiseAllMovies(Guid id)
        {
            // Includes movies associated with the franchise
            var franchise = await _franchiseRepository.GetContext().Franchises
                .Include(f => f.HasMovies)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (franchise == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var franchiseHasMoviesDto = _mapper.Map<FranchiseAllMoviesDto>(franchise);

            // Returns the list of data transfer objects
            return franchiseHasMoviesDto;
        }

        // GET: api/Franchises/id/characters
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<FranchiseAllCharactersDto>> GetFranchiseAllCharacters(Guid id)
        {
            // Includes characters associated with the franchise
            var franchise = await _franchiseRepository.GetContext().Franchises
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

            _franchiseRepository.UpdateFranchise(franchise);

            try
            {
                await _franchiseRepository.SaveAsync();
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
            await _franchiseRepository.InsertFranchiseAsync(franchise);
            await _franchiseRepository.SaveAsync();

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // DELETE: api/Franchises/c3934230-a4c7-4af7-b160-8b4afe930537
        [HttpDelete("{id}")]
        public async Task<ActionResult<Franchise>> DeleteFranchise(Guid id)
        {
            var franchise = await _franchiseRepository.GetFranchiseByIdAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _franchiseRepository.DeleteFranchise(id);
            await _franchiseRepository.SaveAsync();

            return franchise;
        }

        private bool FranchiseExists(Guid id)
        {
            return _franchiseRepository.Exists(id);
        }
    }
}
