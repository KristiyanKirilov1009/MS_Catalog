using MS_Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Business
{
    public interface IMovieSeriesDAO<T, Q>
    {
        // All the methods MovieDAO and SeriesDAO implements.

        public Q GetByIdAndUser(int userId, int id);
        public void AddToFav(Q favourite);
        public void RemoveFromFav(Q favourite);
        T GetById(int id);
        List<T> GetAll();
        List<T> ShowUserFavlist(int userId);
    }
}
