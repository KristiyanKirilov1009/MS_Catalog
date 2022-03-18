using Microsoft.EntityFrameworkCore;
using MS_Catalog.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Data
{
    internal class MS_Context : DbContext
    {
        /// <summary>
        /// This method creates the connection. 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(GetConnectionString());
        }
        /// <summary>
        /// Connection string.
        /// </summary>
        /// <returns>Returns connection string. </returns>
        public static string GetConnectionString()
        {
            MySqlConnectionStringBuilder sqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
            sqlConnectionStringBuilder.Server = "localhost";
            sqlConnectionStringBuilder.UserID = "newuser";
            sqlConnectionStringBuilder.Database = "MS_Database";
            sqlConnectionStringBuilder.Port = 3306;
            sqlConnectionStringBuilder.Password = "12345";

            return sqlConnectionStringBuilder.ConnectionString;
        }

        /// <summary>
        /// All the tables in the database.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavouriteMovie> FavouriteMovies { get; set; }
        public DbSet<FavouriteSeries> FavouriteSeries { get; set; }

        /// <summary>
        /// Table design (foreign keys, etc.).
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavouriteMovie>()
               .HasKey(k => new { k.UserId, k.MovieId });

            modelBuilder.Entity<FavouriteMovie>()
                .HasOne(fm => fm.User)
                .WithMany(us => us.FavouriteMovies)
                .HasForeignKey(fm => fm.UserId);

            modelBuilder.Entity<FavouriteMovie>()
                .HasOne(fm => fm.Movie)
                .WithMany(m => m.FavouriteMovies)
                .HasForeignKey(fm => fm.MovieId);


            modelBuilder.Entity<FavouriteSeries>()
              .HasKey(k => new { k.UserId, k.SeriesId });

            modelBuilder.Entity<FavouriteSeries>()
                .HasOne(fs => fs.User)
                .WithMany(t => t.FavouriteSeries)
                .HasForeignKey(fs => fs.UserId);

            modelBuilder.Entity<FavouriteSeries>()
                .HasOne(fs => fs.Series)
                .WithMany(s => s.FavouriteSeries)
                .HasForeignKey(fs => fs.SeriesId);
        }
    }
}
