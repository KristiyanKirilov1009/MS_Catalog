using Microsoft.EntityFrameworkCore;
using MS_Catalog.Business;
using MS_Catalog.Data;
using MS_Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS_Catalog.Services
{
    public class SeriesDAO : IMovieSeriesDAO<Series, FavouriteSeries>
    {
        private MS_Context ms_context = new MS_Context();

        /// <summary>
        /// Gets series in user's account by id.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <param name="id"> Series' id.</param>
        /// <returns></returns>
        public FavouriteSeries GetByIdAndUser(int userId, int id)
        {
            return ms_context.FavouriteSeries.Where(x => x.SeriesId.Equals(id)
                                                           && x.UserId.Equals(userId)).FirstOrDefault();
        }


        /// <summary>
        /// Adds series by given series.
        /// </summary>
        /// <param name="fs">Series.</param>
        public void AddToFav(FavouriteSeries fs)
        {
            ms_context.FavouriteSeries.Add(fs);
            ms_context.SaveChanges();
        }


        /// <summary>
        /// Removes series from favourite list.
        /// </summary>
        /// <param name="fs">Series.</param>
        public void RemoveFromFav(FavouriteSeries fs)
        {
            ms_context.FavouriteSeries.Remove(fs);
            ms_context.SaveChanges();
        }


        /// <summary>
        /// Lists all the series in the database. 
        /// </summary>
        /// <returns>List of all series in the database.</returns>
        public List<Series> GetAll()
        {
            return ms_context.Series.ToList();
        }


        /// <summary>
        /// Gets series by given id.
        /// </summary>
        /// <param name="id">Series' id.</param>
        /// <returns>Returns series.</returns>
        public Series GetById(int id)
        {
            return ms_context.Series.Where(s => s.Id == id).FirstOrDefault();
        }
        

        /// <summary>
        /// Shows user's favourite series list.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>Returns list of series.</returns>
        public List<Series> ShowUserFavlist(int userId)
        {
            List<Series> userFavouriteSeries = ms_context.FavouriteSeries.Include(x => x.Series).
                Where(m => m.UserId.Equals(userId)).Select(a => a.Series).ToList();

            return userFavouriteSeries;
        }
    }
}
