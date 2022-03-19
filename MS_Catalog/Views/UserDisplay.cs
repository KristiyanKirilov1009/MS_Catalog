using MS_Catalog.Controller;
using MS_Catalog.Controllers;
using MS_Catalog.Data;
using MS_Catalog.Data.Models;
using MS_Catalog.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Catalog.Presentation
{
    public class UserDisplay
    {
        MainMenuDisplay mmd = new MainMenuDisplay();

        UserCtrl userCtrl = new UserCtrl();
        MovieCtrl movieCtrl = new MovieCtrl();
        SeriesCtrl seriesCtrl = new SeriesCtrl();

        private User current = null;
        public UserDisplay(User user)
        {
            if (user == null) throw new ArgumentException("The user is null!");
            current = user;
        }

        /// <summary>
        /// The menu every user sees.
        /// </summary>
        public void UserMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"                       WELCOME, {current.UserName}!               ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------|---------------------------------");
            Console.WriteLine("             MOVIES              |               SERIES            ");
            Console.WriteLine("---------------------------------|---------------------------------");
            Console.WriteLine("   1. Movies                     |   2. Series                     ");
            Console.WriteLine("   3. Movies favourite list      |   4. Series favourite list      ");
            Console.WriteLine("                                 |                                 ");
            Console.WriteLine("                                 |                                 ");
            Console.WriteLine("   5. Change username            |   6. Change password            ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                            7. Log out                             ");
            Console.WriteLine("___________________________________________________________________");

            while (true)
            {
                Console.WriteLine("Type: ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("movies ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to see the movies ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("series ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to see the series ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("m list ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to see the movies favourite list");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("s list ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to see the series favourite list");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("change username ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to change the username of the account");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("change password ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to change the password of the account");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("log out ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("to log out => ");

                string option = Console.ReadLine();

                switch (option.ToLower())
                {
                    case "movies":
                        SeeAllMovies();
                        Console.WriteLine();
                        break;
                    case "series":
                        SeeAllSeries();
                        Console.WriteLine();
                        break;
                    case "m list":
                        FavMovies();
                        break;
                    case "s list":
                        FavSeries();
                        break;
                    case "change username":
                        ChangeUsername();
                        break;
                    case "change password":
                        ChangePass();
                        break;
                    case "log out":
                        Console.Clear();
                        mmd.MainMenu(); return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a valid option");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets all the movies and their ratings from controller.
        /// </summary>
        private void SeeAllMovies()
        {
            Console.Clear();

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            Console.Write(new string(' ', 16) + "MOVIES" + new string(' ', 16));
            Console.WriteLine(new string(' ', 29) + "RATING" + new string(' ', 16));

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < movieCtrl.GetAllMovies().Count; i++)
            {
                Console.WriteLine($"{i + 1 + ".",-4} {movieCtrl.GetAllMovies()[i].Name,-63} {movieCtrl.GetAllMovies()[i].Rating.ToString("0.0"),-20}");
                Console.WriteLine(new string('-', 90));
            }

            MoviesCommands();
        }

        /// <summary>
        /// Gets all the series and their ratings from controller.
        /// </summary>
        private void SeeAllSeries()
        {
            Console.Clear();

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            Console.Write(new string(' ', 16) + "SERIES" + new string(' ', 16));
            Console.WriteLine(new string(' ', 29) + "RATING" + new string(' ', 16));

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < seriesCtrl.GetAllSeries().Count; i++)
            {
                Console.WriteLine($"{i + 1 + ".",-4} {seriesCtrl.GetAllSeries()[i].Name,-63} {seriesCtrl.GetAllSeries()[i].Rating.ToString("0.0"),-20}");
                Console.WriteLine(new string('-', 90));
            }

            SeriesCommands();
        }


        /// <summary>
        /// Shows all the commands every user has when they read about movies.
        /// </summary>
        private void MoviesCommands()
        {

            Console.WriteLine("             1. See description                             2. Add to favourites");
            Console.WriteLine("             3. Remove from favourite list                  4. Sort by name     ");
            Console.WriteLine("             4. Sort by rating                              6. Back to Main Menu");
            Console.WriteLine(new string('_', 90));

            while (true)
            {
                Console.WriteLine("Type: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("description");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to see the description of a movie");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("add");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to add a movie to favourite list");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("remove");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to remove a movie from favourite list");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("sort rating");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to sort by rating");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("sort name");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to sort by name");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("back");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to get back to the main menu => ");


                string option = Console.ReadLine();

                switch (option.ToLower())
                {
                    case "description":
                        ShowMovieDescr(); break;
                    case "add":
                        AddToFM();
                        Console.WriteLine();
                        break;
                    case "remove":
                        RemoveFM();
                        Console.WriteLine();
                        break;
                    case "sort name":
                        SortMoviesByName();
                        Console.WriteLine();
                        break;
                    case "sort rating":
                        SortMoviesByRating();
                        Console.WriteLine();
                        break;
                    case "back":
                        Console.Clear(); UserMenu(); return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a valid option");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        /// <summary>
        /// Shows all the commands every user has when they read about series.
        /// </summary>
        private void SeriesCommands()
        {

            Console.WriteLine("             1. See description                             2. Add to favourites");
            Console.WriteLine("             3. Remove from favourite list                  4. Sort by name     ");
            Console.WriteLine("             4. Sort by rating                              6. Back to Main Menu");
            Console.WriteLine(new string('_', 90));

            while (true)
            {
                Console.WriteLine("Type: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("description");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to see the description of series");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("add");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to add series to favourite list");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("remove");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to remove series from favourite list");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("sort rating");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to sort by rating");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("sort name");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to sort by name");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("back");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to get back to the main menu => ");

                string option = Console.ReadLine();

                switch (option.ToLower())
                {
                    case "description":
                        ShowSeriesDescr(); break;
                    case "add":
                        AddToFS();
                        Console.WriteLine();
                        break;
                    case "remove":
                        RemoveFS();
                        Console.WriteLine();
                        break;
                    case "sort name":
                        SortSeriesByName();
                        Console.WriteLine();
                        break;
                    case "sort rating":
                        SortSeriesByRating();
                        Console.WriteLine();
                        break;
                    case "back":
                        Console.Clear(); UserMenu(); return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a valid option");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                }
            }
        }


        /// <summary>
        /// Shows additional information about movie by given id.
        /// </summary>
        private void ShowMovieDescr()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Which movie do you want to read for (movie id)? - ");
                Console.ForegroundColor = ConsoleColor.White;

                int id = int.Parse(Console.ReadLine());

                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
                Console.WriteLine(movieCtrl.GetDescr(id));
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;

                ShowMovieDescr();
            }
        }

        /// <summary>
        /// Shows additional information about series by given id.
        /// </summary>
        private void ShowSeriesDescr()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Which series do you want to read for (series id)? - ");
                Console.ForegroundColor = ConsoleColor.White;

                int id = int.Parse(Console.ReadLine());

                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
                Console.WriteLine(seriesCtrl.GetDescr(id));
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;

                ShowSeriesDescr();
            }
        }


        /// <summary>
        /// Adds movies to favourite list.
        /// </summary>
        private void AddToFM()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Enter movie id you want to add in your favourite list? => ");
                Console.ForegroundColor = ConsoleColor.White;

                int id = int.Parse(Console.ReadLine());
                movieCtrl.AddToFav(current.UserId, id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added successfully");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string('-', 50));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Adds series to favourite list.
        /// </summary>
        private void AddToFS()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Enter series id you want to add in your favourite list? => ");
                Console.ForegroundColor = ConsoleColor.White;

                int id = int.Parse(Console.ReadLine());
                seriesCtrl.AddToFav(current.UserId, id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added successfully");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string('-', 50));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        /// <summary>
        /// Removes movies to favourite list.
        /// </summary>
        private void RemoveFM()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Which movie id would you like to remove from your favourite list? => ");
                Console.ForegroundColor = ConsoleColor.White;

                int id = int.Parse(Console.ReadLine());

                movieCtrl.RemoveFav(current.UserId, id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Removed successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Removes series to favourite list.
        /// </summary>
        private void RemoveFS()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Which series id would you like to remove from your favourite list? => ");
                Console.ForegroundColor = ConsoleColor.White;

                int id = int.Parse(Console.ReadLine());

                seriesCtrl.RemoveFav(current.UserId, id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Removed successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        /// <summary>
        /// Shows the favourite list of movies of a specified user.
        /// </summary>
        private void FavMovies()
        {
            Console.Clear();

            Console.WriteLine($"{new string(' ', 10)} {current.UserName}'s movies list");

            Console.WriteLine(new string('-', 20));

            foreach (var movie in movieCtrl.ShowFavList(current.UserId))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.WriteLine($"{movie.Name}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(new string('-', 20));
            }

            while (true)
            {
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("back");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to get back to movies list: ");

                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "back": UserMenu(); break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("No such a command");
                        Console.ForegroundColor = ConsoleColor.White; break;
                }
            }


        }

        /// <summary>
        /// Shows the favourite list of series of a specified user.
        /// </summary>
        private void FavSeries()
        {
            Console.Clear();

            Console.WriteLine($"{new string(' ', 10)} {current.UserName}'s series list");

            Console.WriteLine(new string('-', 20));

            foreach (var series in seriesCtrl.ShowFavList(current.UserId))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.WriteLine($"{series.Name}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(new string('-', 20));
            }

            while (true)
            {
                Console.Write("Type ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("back");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to get back to movies list: ");

                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "back": UserMenu(); break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No such a command");
                        Console.ForegroundColor = ConsoleColor.White; break;
                }
            }
        }


        /// <summary>
        /// Changes the password of a specified user.
        /// </summary>
        private void ChangePass()
        {
            while(true)
            {
                try
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Change password sector");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Enter your new password => ");
                    string newPassword = Console.ReadLine();

                    userCtrl.ChangePassword(current.UserId, newPassword);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Password changed successfully!");
                    Console.ForegroundColor = ConsoleColor.White;

                    mmd.MainMenu();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }


        /// <summary>
        /// Changes the username of a specified user.
        /// </summary>
        private void ChangeUsername()
        {
            Console.Clear();

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Change username sector");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Enter your new username => ");
                    string newUsername = Console.ReadLine();

                    userCtrl.ChangeUsername(current.UserId, newUsername);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Username changed successfully!");
                    Console.ForegroundColor = ConsoleColor.White;

                    mmd.MainMenu();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

        /// <summary>
        /// Sorts movies by name.
        /// </summary>
        private void SortMoviesByName()
        {
            Console.Clear();

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            Console.Write(new string(' ', 16) + "MOVIES" + new string(' ', 16));
            Console.WriteLine(new string(' ', 29) + "RATING" + new string(' ', 16));

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < movieCtrl.SortByName().Count; i++)
            {
                Console.WriteLine($"{movieCtrl.SortByName()[i].Id + ".",-4} {movieCtrl.SortByName()[i].Name,-63} {movieCtrl.SortByName()[i].Rating.ToString("0.0"),-20}");
                Console.WriteLine(new string('-', 90));
            }
        }

        /// <summary>
        /// Sorts series by name.
        /// </summary>
        private void SortSeriesByName()
        {
            Console.Clear();

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            Console.Write(new string(' ', 16) + "Series" + new string(' ', 16));
            Console.WriteLine(new string(' ', 29) + "RATING" + new string(' ', 16));

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < seriesCtrl.SortByName().Count; i++)
            {
                Console.WriteLine($"{seriesCtrl.SortByName()[i].Id + ".",-4} {seriesCtrl.SortByName()[i].Name,-63} {seriesCtrl.SortByName()[i].Rating.ToString("0.0"),-20}");
                Console.WriteLine(new string('-', 90));
            }
        }

        /// <summary>
        /// Sorts movies by rating.
        /// </summary>
        private void SortMoviesByRating()
        {
            Console.Clear();

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            Console.Write(new string(' ', 16) + "MOVIES" + new string(' ', 16));
            Console.WriteLine(new string(' ', 29) + "RATING" + new string(' ', 16));

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < movieCtrl.SortByRating().Count; i++)
            {
                Console.WriteLine($"{movieCtrl.SortByRating()[i].Id + ".",-4} {movieCtrl.SortByRating()[i].Name,-63} {movieCtrl.SortByRating()[i].Rating.ToString("0.0"),-20}");
                Console.WriteLine(new string('-', 90));
            }
        }

        /// <summary>
        /// Sorts series by rating.
        /// </summary>
        private void SortSeriesByRating()
        {
            Console.Clear();

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            Console.Write(new string(' ', 16) + "Series" + new string(' ', 16));
            Console.WriteLine(new string(' ', 29) + "RATING" + new string(' ', 16));

            Console.Write(new string('-', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < seriesCtrl.SortByRating().Count; i++)
            {
                Console.WriteLine($"{seriesCtrl.SortByRating()[i].Id + ".",-4} {seriesCtrl.SortByRating()[i].Name,-63} {seriesCtrl.SortByRating()[i].Rating.ToString("0.0"),-20}");
                Console.WriteLine(new string('-', 90));
            }
        }
    }
}
