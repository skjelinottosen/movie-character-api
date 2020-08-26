using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.DataAccess.DataAccess
{
    public class MovieDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"PC7383\SQLEXPRESS",
                InitialCatalog = "Task13",
                IntegratedSecurity = true
            };
            optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
        }

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
