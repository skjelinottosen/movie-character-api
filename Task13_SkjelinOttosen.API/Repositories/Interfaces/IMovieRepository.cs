using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.DataAccess.DataAccess;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid movieId);
        Task InsertMovieAsync(Movie movie);
        void DeleteMovie(Guid movieId);
        void UpdateMovie(Movie movie);
        bool Exists(Guid id);
        MovieDbContext GetContext();
        Task SaveAsync();
        Task DisposeAsync();
    }
}
