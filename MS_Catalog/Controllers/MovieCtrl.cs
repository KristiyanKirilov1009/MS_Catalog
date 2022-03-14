using MS_Catalog.Data;
using MS_Catalog.Data.Models;
using MS_Catalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS_Catalog.Controllers
{
    public class MovieCtrl
    {
        MovieDAO movieDAO = new MovieDAO();

        FavouriteMovie favouriteMovie = new FavouriteMovie();


        /// <summary>
        /// Adds in favourite list.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <param name="movieId">Movie's id.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddToFav(int userId, int movieId)
        {
            var fm = movieDAO.GetByIdAndUser(userId, movieId);

            if (fm != null)
            {
                throw new ArgumentException("There is already such movie in the favourite list!");
            }

            
            favouriteMovie.UserId = userId;
            favouriteMovie.MovieId = movieId;

            if (favouriteMovie.MovieId > movieDAO.GetAll().Count)
            {
                throw new ArgumentException("There is no such movie in the list!");
            }

            movieDAO.AddToFav(favouriteMovie);
        }


        /// <summary>
        /// Removes movies from favourite list.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <param name="movieId">Movie's id.</param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveFav(int userId, int movieId)
        {
            var fm = movieDAO.GetByIdAndUser(userId, movieId);

            if (fm == null)
            {
                throw new ArgumentException("There is no such movie in the favourite list!");
            }

            movieDAO.RemoveFromFav(fm);
        }


        /// <summary>
        /// Gets movie's description by given id. 
        /// </summary>
        /// <param name="id">Movie's id.</param>
        /// <returns>Return description.</returns>
        /// <exception cref="ArgumentException"></exception>
        public string GetDescr(int id)
        {
            Movie currentMovie = movieDAO.GetById(id);

            if (currentMovie == null)
            {
                throw new ArgumentException("There is no such a movie with this name!");
            }

            return currentMovie.Description;
        }


        /// <summary>
        /// Gets all the movies in the database.
        /// </summary>
        /// <returns>List of movies.</returns>
        public List<Movie> GetAllMovies()
        {
            return movieDAO.GetAll();
        }


        /// <summary>
        /// Shows all the movies in the favourite list.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>List of movies</returns>
        public List<Movie> ShowFavList(int userId)
        {
            return movieDAO.ShowUserFavlist(userId);
        }


        /// <summary>
        /// Sorts movies by name.
        /// </summary>
        /// <returns>List of movies.</returns>
        public List<Movie> SortByName()
        {
            List<Movie> movies = movieDAO.GetAll();

            return movies.Where(x => x != null).OrderBy(m => m.Name).ToList();
        }


        /// <summary>
        /// Sorts movies by rating.
        /// </summary>
        /// <returns>List of movies.</returns>
        public List<Movie> SortByRating()
        {
            List<Movie> movies = movieDAO.GetAll();

            return movies.Where(x => x != null).OrderByDescending(m => m.Rating).ToList();
        }
    }
}
