using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles.ActorProfiles
{
    public class ActorAllMoviesDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public EGender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; }

        public string Biography { get; set; }

        public string ImageURL { get; set; }

        public List<MovieCharacter> ActInMovies { get; set; }
    }
}
