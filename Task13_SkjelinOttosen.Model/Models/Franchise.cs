using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class Franchise
    {
        // Primary key
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
       
        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Movie> HasMovies { get; set; }
    }
}
