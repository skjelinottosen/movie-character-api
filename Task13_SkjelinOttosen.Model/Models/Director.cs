using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class Director
    {
        // Primary key
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public EGender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        [MaxLength(50)]
        public string BirthPlace { get; set; }
        
        [MaxLength(500)]
        public string Biography { get; set; }
        
        [MaxLength(2048)]
        public string ImageURL { get; set; }

        public ICollection<MovieDirector> HasDirectedMovies { get; set; }     
    }
}
