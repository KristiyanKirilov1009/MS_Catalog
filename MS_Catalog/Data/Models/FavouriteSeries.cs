using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Data.Models
{
    public class FavouriteSeries
    {
        public User User { get; set; }
        public Series Series { get; set; }

        public int UserId { get; set; }
        public int SeriesId { get; set; }
    }
}
