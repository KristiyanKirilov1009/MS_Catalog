using MS_Catalog.Controller;
using MS_Catalog.Data;
using MS_Catalog.Data.Models;
using MS_Catalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS_Catalog.Services
{
    public class UserDAO : IUserDAO
    {
        public User selectedUser { get; set; }

        private MS_Context ms_context = new MS_Context();

        /// <summary>
        /// Checks in the database for a user by given id.
        /// </summary>
        /// <param name="userId">User's id</param>
        /// <returns>Returns object from the database.</returns>
        public User GetUserById(int userId)
        {
            return ms_context.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }

        /// <summary>
        /// Checks in the database for a user by given username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns object from the database.</returns>
        public User GetUserByUsername(string username)
        {
            return ms_context.Users.Where(u => u.UserName.Equals(username)).FirstOrDefault();
        }

        /// <summary>
        /// Checks in the database for a user by given username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns object from the database.</returns>
        public User GetUserByUsernameAndPass(string username, string password)
        {
            return ms_context.Users.Where(u => u.UserName.Equals(username, StringComparison.CurrentCulture) && u.Password.Equals(password, StringComparison.Ordinal)).FirstOrDefault();
        }

        /// <summary>
        /// Adds new object in the database.
        /// </summary>
        /// <param name="user">New user.</param>
        public void Registration(User user)
        {
            ms_context.Add(user);
            ms_context.SaveChanges();
        }

        /// <summary>
        /// Saves the changes and update the database.
        /// </summary>
        public void SaveChanges()
        {
            ms_context.SaveChanges();
        }
    }
}
