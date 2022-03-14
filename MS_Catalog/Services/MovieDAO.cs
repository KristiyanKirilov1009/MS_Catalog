using Microsoft.EntityFrameworkCore;
using MS_Catalog.Business;
using MS_Catalog.Controller;
using MS_Catalog.Data;
using MS_Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS_Catalog.Services
{
    public class MovieDAO : IMovieSeriesDAO<Movie, FavouriteMovie>
    {
        private MS_Context ms_context = new MS_Context();


        /// <summary>
        /// Gets movie in user's accoount by given movie id.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <param name="id">Movie's id.</param>
        /// <returns>Returns movie.</returns>
        public FavouriteMovie GetByIdAndUser(int userId, int id)
        {
            return ms_context.FavouriteMovies.Where(x => x.MovieId.Equals(id) 
                                                           && x.UserId.Equals(userId)).FirstOrDefault();
        }

        /// <summary>
        /// Adds movie in favourite list.
        /// </summary>
        /// <param name="fm">Movie.</param>
        public void AddToFav(FavouriteMovie fm)
        {
            ms_context.FavouriteMovies.Add(fm);
            ms_context.SaveChanges();
        }


        /// <summary>
        /// Removes movie from favourite list.
        /// </summary>
        /// <param name="fm">Movie</param>
        public void RemoveFromFav(FavouriteMovie fm)
        {
            ms_context.FavouriteMovies.Remove(fm);
            ms_context.SaveChanges();
        }


        /// <summary>
        /// Lists all the movies in the database. 
        /// </summary>
        /// <returns>List of all movies in the database.</returns>
        public List<Movie> GetAll()
        {
            return ms_context.Movies.ToList();
        }


        /// <summary>
        /// Gets movie by given id.
        /// </summary>
        /// <param name="id">Movie's id.</param>
        /// <returns>Returns movie.</returns>
        public Movie GetById(int id)
        {
            return ms_context.Movies.Where(m => m.Id == id).FirstOrDefault();
        }


        /// <summary>
        /// Shows user's favourite movie list.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>Returns list of movies.</returns>
        public List<Movie> ShowUserFavlist(int userId)
        {
            return ms_context.FavouriteMovies.Include(x => x.Movie).
                 Where(m => m.UserId.Equals(userId)).Select(a => a.Movie).ToList();
        }

    }
}
