﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.DTOs.MovieDTOs
{
    public class MovieDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public EGenre Genre { get; set; }

        public DateTime ReleaseYear { get; set; }

        public string PosterURL { get; set; }

        public string TrailerURL { get; set; }
        public Guid FranchiseId { get; set; }
        //public Franchise Franchise { get; set; }
        public List<MovieCharacter> HasCharacters { get; set; }
        public List<MovieDirector> HasDirectors { get; set; }
    }
}