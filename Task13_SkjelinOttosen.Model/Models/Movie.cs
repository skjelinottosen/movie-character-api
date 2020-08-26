using System;
using System.Collections.Generic;
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
        public Guid Id { get; set; }
        public String  Title { get; set; }
        public int MyProperty { get; set; }
        public EGenre Genre { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PosterURL { get; set; }
        public string TrailerURL { get; set; }
        public Guid FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
