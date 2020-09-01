using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs.ActoDTOs;
using Task13_SkjelinOttosen.API.DTOs.ActorDTOs;
using Task13_SkjelinOttosen.API.Profiles.ActorProfiles;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
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
        private readonly IActorRepository _actorRepository;

        public ActorsController(MovieDbContext context, IMapper mapper, IActorRepository actorRepository)
        {
            _context = context;
            _mapper = mapper;
            _actorRepository = actorRepository;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorListViewDto>>> GetActors()
        {
            // Stores all actors in the list using the ActorRepository class
            List<Actor> actors = (List<Actor>)await _actorRepository.GetActorsAsync();

            // Maps all the data transfer objects to the domain objects
            List<ActorListViewDto> actorDtos = _mapper.Map<List<ActorListViewDto>>(actors);

            // Returns the list of data transfer objects
            return actorDtos;
        }

        // GET: api/Actors/78d3d632-9beb-4bf4-bbc5-328d503b44ea
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDto>> GetActor(Guid id)
        {
            // Stores the actor using the ActorRepository class
            Actor actor = await _actorRepository.GetActorByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            ActorDto actorDto = _mapper.Map<ActorDto>(actor);
            
            // Returns the data transfer object
            return actorDto;
        }


        // GET: api/Actors/id/movies
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<ActorAllMoviesDto>> GetActorAllMovies(Guid id)
        {
            // Includes all the movies the actor has played in
            // Using the ActorRepository class
            var actor = await _actorRepository.GetContext().Actors
                .Include(a => a.ActInMovies)
                .ThenInclude(mc => mc.Movie)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (actor == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var actorAllMoviesDto = _mapper.Map<ActorAllMoviesDto>(actor);

            // Returns the list of data transfer objects
            return actorAllMoviesDto;
        }

        // PUT: api/Actors/78d3d632-9beb-4bf4-bbc5-328d503b44ea
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(Guid id, Actor actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            // Updates actor using the ActorRepository
            _actorRepository.UpdateActor(actor);

            try
            {
                // Saves changes using the ActorRepository
                await _actorRepository.SaveAsync();
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
            // Inserts a new Actor and save chages using  the ActorRepository
            await _actorRepository.InsertActorAsync(actor);
            await _actorRepository.SaveAsync();
          
            return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        }

        // DELETE: api/Actors/78d3d632-9beb-4bf4-bbc5-328d503b44ea
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> DeleteActor(Guid id)
        {
            var actor = await _actorRepository.GetActorByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            // Deletes Actor and save chages using the ActorRepository class
            _actorRepository.DeleteActor(id);
            await _actorRepository.SaveAsync();

            return actor;
        }

        private bool ActorExists(Guid id)
        {
            // Checks if a actor exists using the ActorRepository class
            return _actorRepository.Exists(id);
        }
    }
}
