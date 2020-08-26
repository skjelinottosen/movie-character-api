using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.DataAccess.DataAccess
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCharacter> MovieCharacters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        //    {
        //        DataSource = @"PC7383\SQLEXPRESS",
        //        InitialCatalog = "Task13",
        //        IntegratedSecurity = true
        //    };
        //    optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
        //}


        // Overrrides the configuration for the creating of the database
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // Creates composite key for the joining entity MovieCharacter 
            modelbuilder.Entity<MovieCharacter>().HasKey(mc => new { mc.CharacterId , mc.MovieId});

            // Creates composite key for the joining entity MovieDirector
            modelbuilder.Entity<MovieDirector>().HasKey(md => new { md.DirectorId, md.MovieId, });
        }
    }
}
