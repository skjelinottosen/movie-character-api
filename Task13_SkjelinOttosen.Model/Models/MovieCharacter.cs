using System;
using System.ComponentModel.DataAnnotations;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class MovieCharacter
    {
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        [MaxLength(2048)]
        public string ImageURL { get; set; }
        public Guid ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
