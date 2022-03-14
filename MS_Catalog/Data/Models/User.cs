using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set 
            { 
                if(value == null)
                {
                    throw new ArgumentNullException("Username cannot be null!");
                }
                userName = value; 
            }
        }


        private string password;
        public string Password
        {
            get { return password; }
            set 
            { 
                if(value == null)
                {
                    throw new ArgumentNullException("Password cannot be null!");
                }
                password = value; 
            }
        }


        public List<FavouriteMovie> FavouriteMovies { get; set; }
        public List<FavouriteSeries> FavouriteSeries { get; set; }

        public User()
        {
            FavouriteMovies = new List<FavouriteMovie>();
            FavouriteSeries = new List<FavouriteSeries>();
        }
    }
}
