using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public enum EGenre
    {
        Action,
        Adventure,
        Comedy,
        Crime,
        Documentary,
        Drama,
        Fantasy,
        Historical,
        Horror,
        Mystery,
        Philosophical,
        Political,
        Romance,
        Saga,
        Satire,
        ScienceFiction,
        Social,
        Speculative,
        Thriller,
        Urban,
        Western
    }
    public class Movie
    {
        // Primary key
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }
       
        public EGenre Genre { get; set; }

        public DateTime ReleaseYear { get; set; }

        [MaxLength(2048)]
        public string PosterURL { get; set; }

        [MaxLength(2048)]
        public string TrailerURL { get; set; }
        public Guid FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
        public ICollection<MovieCharacter> HasCharacters { get; set; }
        public ICollection<MovieDirector> HasDirectors { get; set; }
    }
}
