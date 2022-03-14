using MS_Catalog.Data;
using MS_Catalog.Data.Models;
using MS_Catalog.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MS_Catalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MainMenuDisplay mainMenuView = new MainMenuDisplay();
                mainMenuView.MainMenu();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
