using MS_Catalog.Data.Models;
using MS_Catalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS_Catalog.Controllers
{
    public class SeriesCtrl
    {
        SeriesDAO seriesDAO = new SeriesDAO();

        FavouriteSeries favouriteSeries = new FavouriteSeries();


        /// <summary>
        /// Adds in favourite list.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <param name="seriesId">Series' id.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddToFav(int userId, int seriesId)
        {
            var fs = seriesDAO.GetByIdAndUser(userId, seriesId);

            if (fs != null)
            {
                throw new ArgumentException("There is already such series in the favourite list!");
            }

            favouriteSeries.UserId = userId;
            favouriteSeries.SeriesId = seriesId;

            if(favouriteSeries.SeriesId > seriesDAO.GetAll().Count)
            {
                throw new ArgumentException("There is no such series in the list!");
            }

            seriesDAO.AddToFav(favouriteSeries);
        }


        /// <summary>
        /// Removes series from favourite list.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="seriesId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveFav(int userId, int seriesId)
        {
            var fs = seriesDAO.GetByIdAndUser(userId, seriesId);

            if (fs == null)
            {
                throw new ArgumentException("There is no such series in the favourite list!");
            }

            seriesDAO.RemoveFromFav(fs);
        }


        /// <summary>
        /// Gets series' description by given id. 
        /// </summary>
        /// <param name="id">Series' id.</param>
        /// <returns>Return description.</returns>
        /// <exception cref="ArgumentException"></exception>
        public string GetDescr(int id)
        {
            Series currentSeries = seriesDAO.GetById(id);

            if (currentSeries == null)
            {
                throw new ArgumentException("There is no such series with this name!");
            }

            return currentSeries.Description;
        }


        /// <summary>
        /// Gets all the series in the database.
        /// </summary>
        /// <returns>List of series.</returns>
        public List<Series> GetAllSeries()
        {
            return seriesDAO.GetAll();
        }


        /// <summary>
        /// Shows all the series in the favourite list.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of series.</returns>
        public List<Series> ShowFavList(int userId)
        {
            return seriesDAO.ShowUserFavlist(userId);
        }


        /// <summary>
        /// Sorts series by name.
        /// </summary>
        /// <returns>List of series.</returns>
        public List<Series> SortByName()
        {
            List<Series> series = seriesDAO.GetAll();

            return series.Where(x => x != null).OrderBy(m => m.Name).ToList();
        }


        /// <summary>
        /// Sorts series by rating.
        /// </summary>
        /// <returns>List of series.</returns>
        public List<Series> SortByRating()
        {
            List<Series> series = seriesDAO.GetAll();

            return series.Where(x => x != null).OrderByDescending(s => s.Rating).ToList();
        }
    }
}
