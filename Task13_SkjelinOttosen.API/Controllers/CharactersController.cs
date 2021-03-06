﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task13_SkjelinOttosen.API.DTOs.CharacterDTOs;
using Task13_SkjelinOttosen.API.Repositories.Interfaces;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(MovieDbContext context, IMapper mapper, ICharacterRepository characterRepository)
        {
            _context = context;
            _mapper = mapper;
            _characterRepository = characterRepository;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterListViewDto>>> GetCharacters()
        {
            // Stores all characters in the list using the CharacterRepository class
            List<Character> characters = (List<Character>)await _characterRepository.GetCharactersAsync();

            // Maps all the data transfer objects to the domain objects
            List<CharacterListViewDto> characterDtos = _mapper.Map <List<CharacterListViewDto>>(characters);

            // Returns the list of data transfer objects
            return characterDtos;
        }

        // GET: api/Characters/f0b9ad0f-9def-45ca-89c2-103aa847fb17
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(Guid id)
        {
            // Stores the character using the CharacterRepository class
            var character = await _characterRepository.GetCharacterByIdAsync(id);
              

            if (character == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var characterDto = _mapper.Map<CharacterDto>(character);

            // Returns the data transfer object
            return characterDto;
        }

        // GET: api/Characters/f0b9ad0f-9def-45ca-89c2-103aa847fb17/actors
        [HttpGet("{id}/actors")]
        public async Task<ActionResult<CharacterPlayedByActorsDto>> GetCharacterPlayedByActors(Guid id)
        {
            // Includes the actors who have played the character using the CharacterRepository class
            var character = await  _characterRepository.GetContext().Characters
                .Include(c => c.AppearInMovies)
                .ThenInclude(a => a.Actor).FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            // Maps the data transfer object to the domain object
            var characterDto = _mapper.Map<CharacterPlayedByActorsDto>(character);

            return characterDto;
        }


        // PUT: api/Characters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(Guid id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            // Updates the character using the CharacterRepository class
            _characterRepository.UpdateCharacter(character);

            try
            {
                // Saves changes using the CharacterRepository class
                await _characterRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Characters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            // Inserts a new Character and saves the changes using the CharacterRepository class
            await _characterRepository.InsertCharacterAsync(character);
            await _characterRepository.SaveAsync();

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> DeleteCharacter(Guid id)
        {
            // Stores the character using the CharacterRepository class
            var character = await _characterRepository.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            // Deletes the Character and saves the changes using the CharacterRepository class
            _characterRepository.DeleteCharacter(id);
            await _characterRepository.SaveAsync();

            return character;
        }

        private bool CharacterExists(Guid id)
        {
            // Check if the Characeter exist using the CharacterRepository class
            return _characterRepository.Exists(id);
        }
    }
}
