using MS_Catalog.Data;
using MS_Catalog.Data.Models;
using MS_Catalog.Presentation;
using MS_Catalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS_Catalog.Controller
{
    public class UserCtrl
    {
        User selectedUser = new User();
        UserDAO userDAO = new UserDAO();


        /// <summary>
        /// Changes user's password by given username and new version of the password.
        /// </summary>
        /// <param name="username">User's username.</param>
        /// <param name="newP">User's new password.</param>
        /// <exception cref="ArgumentException"></exception>
        public void ForgotPassword(string username, string newP)
        {
            User currentUser = userDAO.GetUserByUsername(username);

            if (currentUser == null)
            {
                throw new ArgumentException("There is no such a user!");
            }

            currentUser.Password = newP;

            userDAO.SaveChanges();
        }


        /// <summary>
        /// Logs in user's account.
        /// </summary>
        /// <param name="username">User's username.</param>
        /// <param name="password">User's password.</param>
        /// <exception cref="Exception"></exception>
        public void LogIn(string username, string password)
        {
            User currentUser = userDAO.GetUserByUsernameAndPass(username, password);

            if (currentUser == null)
            {
                throw new Exception("Invalid username or password!");
            }

            LoadUserView(currentUser);
        }


        /// <summary>
        /// Creates new account.
        /// </summary>
        /// <param name="username">User's username.</param>
        /// <param name="password">User's password.</param>
        /// <exception cref="ArgumentException"></exception>
        public void Registration(string username, string password)
        {
            User currentUser = userDAO.GetUserByUsername(username);

            if (currentUser != null)
            {
                throw new ArgumentException("This username is already taken!");
            }

            selectedUser.UserName = username;
            selectedUser.Password = password;

            userDAO.Registration(selectedUser);

            LoadUserView(selectedUser);
        }


        /// <summary>
        /// Loads user's view.
        /// </summary>
        /// <param name="user">Current user</param>
        private void LoadUserView(User user)
        {
            UserDisplay uD = new UserDisplay(user);
            uD.UserMenu();
        }


        /// <summary>
        /// Makes connection to UserDAO and changes the password.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newP">User's new password.</param>
        public void ChangePassword(int userId, string newP)
        {
            User user = userDAO.GetUserById(userId);

            user.Password = newP;

            userDAO.SaveChanges();
        }


        /// <summary>
        /// Makes connection to UserDAO and changes the username.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newP">User's new password.</param>
        public void ChangeUsername(int userId, string newU)
        {
            User user = userDAO.GetUserById(userId);

            if (userDAO.GetUserByUsername(newU) != null)
            {
                throw new ArgumentException("There is already username like this! Try again!");
            }

            user.UserName = newU;

            userDAO.SaveChanges();
        }
    }
}

