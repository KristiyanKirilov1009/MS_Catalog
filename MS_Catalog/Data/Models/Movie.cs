using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }

        public List<FavouriteMovie> FavouriteMovies { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
