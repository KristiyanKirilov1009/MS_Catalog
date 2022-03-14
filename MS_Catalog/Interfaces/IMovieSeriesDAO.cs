using MS_Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Business
{
    public interface IMovieSeriesDAO<T, Q>
    {
        /// <summary>
        /// Gets movie or series by id in already created account.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <param name="id">Id of the movie or series.</param>
        /// <returns>Q -> favourite movie or favourite series.</returns>
        public Q GetByIdAndUser(int userId, int id);

        /// <summary>
        /// Adds in favourite list.
        /// </summary>
        /// <param name="favourite">Movie or series we want to add.</param>
        public void AddToFav(Q favourite);

        /// <summary>
        /// Removes from favourite list.
        /// </summary>
        /// <param name="favourite">Movie or series we want to remove.</param>
        public void RemoveFromFav(Q favourite);

        /// <summary>
        /// Gets movie or series by given id.
        /// </summary>
        /// <param name="id">Id of movie or series.</param>
        /// <returns>T -> Movie or series</returns>
        T GetById(int id);

        /// <summary>
        /// Shows all the movies or series.
        /// </summary>
        /// <returns>List of movies or series.</returns>
        List<T> GetAll();

        /// <summary>
        /// Shows list of favourite movies or series.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>List of movies or series.</returns>
        List<T> ShowUserFavlist(int userId);
    }
}
