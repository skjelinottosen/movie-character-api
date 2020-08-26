using System;
using System.Collections.Generic;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class Franchise
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public string  Description { get; set; }
        public ICollection<Movie> HasMovies { get; set; }
    }
}
