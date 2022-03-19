using MS_Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Interfaces
{
    public interface IUserDAO
    {
         
        /// <summary>
        /// Gets user by id.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>Returns user.</returns>
        User GetUserById(int userId);


        /// <summary>
        /// Gets user by username.
        /// </summary>
        /// <param name="username">User's username.</param>
        /// <returns>Returns user.</returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// Gets user by username and password.
        /// </summary>
        /// <param name="username">User's username.</param>
        /// <param name="password">User's password.</param>
        /// <returns>Returns user.</returns>
        User GetUserByUsernameAndPass(string username, string password);

        /// <summary>
        /// Makes registration
        /// </summary>
        /// <param name="user">User.</param>
        void Registration(User user);
    }
}
