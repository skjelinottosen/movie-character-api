using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public ActorsController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorDto>>> GetActors()
        { 
            // Stores all actors in the list
            List<Actor> actors = await _context.Actors.ToListAsync();

            // Maps all the data transfer objects to the domain objects
            List<ActorDto> actorDtos =  _mapper.Map<List<ActorDto>>(actors);

            // Returns a list of data transfer objects
            return actorDtos;
        }

        // GET: api/Actors/f0b9ad0f-9def-45ca-89c2-103aa847fb17
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDto>> GetActor(Guid id)
        {
            Actor actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            ActorDto actorDto = _mapper.Map<ActorDto>(actor);
            
            // Returns the Data Transfer Object
            return actorDto;
        }


        // GET: api/Actors/id/allmovies
        [HttpGet("{id}/allmovies")]
        public async Task<ActionResult<Actor>> GetActorAllMovies(Guid id)
        {
            // Includes all the movies the actor has played in
            var actor = await _context.Actors
                .Include(a => a.ActInMovies)
                .ThenInclude(mc => mc.Movie)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }

        // PUT: api/Actors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(Guid id, Actor actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            _context.Entry(actor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
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

        // POST: api/Actors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> DeleteActor(Guid id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return actor;
        }

        private bool ActorExists(Guid id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
