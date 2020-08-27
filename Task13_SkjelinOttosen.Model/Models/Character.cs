using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class Character
    {
        // Primary key
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string Alias { get; set; }

        public EGender Gender { get; set; }

        [MaxLength(2048)]
        public string ImageURL { get; set; }

        public ICollection<MovieCharacter> AppearInMovies { get; set; }

    }
}
