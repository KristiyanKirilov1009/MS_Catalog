using MS_Catalog.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Interfaces
{
    public interface IUserDAO
    {
        //All the methods UserDAO implements. 

        User GetUserById(int userId);
        User GetUserByUsername(string username);
        User GetUserByUsernameAndPass(string username, string password);
        void Registration(User user);
    }
}
