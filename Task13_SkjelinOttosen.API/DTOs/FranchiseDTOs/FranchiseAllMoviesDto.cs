using System;
using System.Collections.Generic;
using Task13_SkjelinOttosen.API.DTOs.MovieDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs
{
    // Data transfer object for franchise listing all movies
    public class FranchiseAllMoviesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MovieListViewDto> Movies { get; set; }
    }
}
