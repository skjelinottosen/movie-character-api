using System;
using System.Collections.Generic;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class MovieDirector
    {
        public Guid DirectorId { get; set; }
        public Director Director { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
