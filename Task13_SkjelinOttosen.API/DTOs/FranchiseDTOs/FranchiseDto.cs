using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs
{
    public class FranchiseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public List<Movie> HasMovies { get; set; }
    }
}
