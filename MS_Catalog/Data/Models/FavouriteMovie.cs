using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Data.Models
{
    public class FavouriteMovie
    {
        public User User { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
