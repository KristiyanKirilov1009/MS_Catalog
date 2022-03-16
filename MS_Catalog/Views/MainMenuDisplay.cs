using MS_Catalog.Controller;
using MS_Catalog.Data.Models;
using MS_Catalog.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Presentation
{
    public class MainMenuDisplay
    {
        UserCtrl userCtrl = new UserCtrl();

        /// <summary>
        /// The main menu of the program.
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                       WELCOME TO MS DATABASE                      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------|---------------------------------");
            Console.WriteLine("           1. Log in             |      2. Create a new account    ");
            Console.WriteLine("                                 |                                 ");
            Console.WriteLine("                                 |                                 ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("         3.Forgot password                      4.Exit             ");
            Console.WriteLine("___________________________________________________________________");

            while (true)
            {
                Console.WriteLine("Type: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("log in ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to log in ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("new ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to create new account ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("forgot password ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to set a new password ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("exit ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("to stop the program => ");

                string option = Console.ReadLine();

                switch (option.ToLower())
                {
                    case "log in":
                        Login(); break;
                    case "new":
                        CreateNewAcc();
                        break;
                    case "forgot password": ForgotPass(); break;
                    case "exit":
                        Environment.Exit(0); return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a valid option");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        /// <summary>
        /// Changes the password in case the user has forgotten it.
        /// </summary>
        private void ForgotPass()
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.Write($"Enter your username => ");
                    string username = Console.ReadLine();

                    if (username == "")
                    {
                        throw new ArgumentException("Password cannot be null!");
                    }

                    Console.Write("Enter your new password => ");
                    string newPass = Console.ReadLine();

                    if(newPass == "")
                    {
                        throw new ArgumentException("Password cannot be null!");
                    }

                    userCtrl.ForgotPassword(username, newPass);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The password is changed successfully!");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Type ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("back");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" to log in with the new password => ");

                    string command = Console.ReadLine();


                    switch (command.ToLower())
                    {
                        case "back":
                            MainMenu();
                            break;
                        default: Console.WriteLine("Enter valid command!"); break;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }

        /// <summary>
        /// Makes new registration.
        /// </summary>
        private void CreateNewAcc()
        {
            Console.Clear();

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("REGISTER");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();

                    if(username == "")
                    {
                        throw new ArgumentException("Username cannot be null!");
                    }

                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    if (password == "")
                    {
                        throw new ArgumentException("Pasword cannot be null!");
                    }

                    UserCtrl home = new UserCtrl();
                    home.Registration(username, password);

                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }

        /// <summary>
        /// Log into the program.
        /// </summary>
        private void Login()
        {
            Console.Clear();

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("LOGIN");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    
                    if(username == "")
                    {
                        throw new ArgumentException("Username cannot be null!");
                    }

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    if (username == "")
                    {
                        throw new ArgumentException("Password cannot be null!");
                    }

                    userCtrl.LogIn(username, password);

                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
