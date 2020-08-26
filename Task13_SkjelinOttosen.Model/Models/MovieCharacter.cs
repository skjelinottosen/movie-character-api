using System;
using System.Collections.Generic;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class MovieCharacter
    {
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public string ImageURL { get; set; }
        public Guid ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
