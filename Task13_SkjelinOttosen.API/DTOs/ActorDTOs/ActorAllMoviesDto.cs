using System;
using System.Collections.Generic;
using Task13_SkjelinOttosen.API.DTOs.MovieDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles.ActorProfiles
{
    // Data transfer object to include a list of movies
    public class ActorAllMoviesDto
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
        public List<MovieListViewDto> Movies { get; set; }

    }
}
