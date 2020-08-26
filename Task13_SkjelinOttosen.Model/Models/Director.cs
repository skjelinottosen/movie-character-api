using System;
using System.Collections.Generic;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public class Director
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public EGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string Biography { get; set; }
        public string ImageURL { get; set; }
        public ICollection<MovieDirector> HasDirectedMovies { get; set; }     
    }
}
