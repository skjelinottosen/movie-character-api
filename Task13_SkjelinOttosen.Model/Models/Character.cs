using System;
using System.Collections.Generic;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public EGender Gender { get; set; }
        public string ImageURL { get; set; }
        public ICollection<MovieCharacter> ActInMovies { get; set; }

    }
}
