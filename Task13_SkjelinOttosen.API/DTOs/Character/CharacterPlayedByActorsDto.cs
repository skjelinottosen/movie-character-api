using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.DTOs.Character
{
    public class CharacterPlayedByActorsDto 
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Alias { get; set; }

        public EGender Gender { get; set; }

        public string ImageURL { get; set; }

        public List<MovieCharacter> AppearInMovies { get; set; }

    }
}
