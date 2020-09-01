using System;

namespace Task13_SkjelinOttosen.API.DTOs.MovieDTOs
{
    // Data transfer object listing the movies. Can be used in a list view
    public class MovieListViewDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
