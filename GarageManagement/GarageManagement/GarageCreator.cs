using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    /// <summary>
    /// This class hold the MainMenu
    /// </summary>
    public class GarageCreator
    {
        public void MainMenu()
        {
            Menu MainMenu = new Menu();
            MainMenu.Description = "Main Menu:";
            MainMenu.AddMenuItem("1", "Enter 1 if you want to create a new garage", new Action(() => { CreateGarage(); }));
            MainMenu.AddMenuItem("2", "Enter 2 if you want to park your vehicle", new Action(() => { Park(); }));
            MainMenu.AddMenuItem("3", "Enter 3 if you want to unpark you vehicle", new Action(() => { Unpark(); }));
            MainMenu.AddMenuItem("4", "Enter 4 if you want to see information about the garage", new Action(() => { List(); }));
            MainMenu.AddMenuItem("5", "Enter 5 if you want to search about vehicle", new Action(() => { Search(); }));
            MainMenu.AddMenuItem("0", "Enter 0 to Exit", new Action(() => { Close(); }));
            bool DisplayMenu = true;
            while (DisplayMenu)
            {
                MainMenu.Display();
                string input = Console.ReadLine();
                if (input == "0") DisplayMenu = false;
                MainMenu.ExecuteEntry(input);
            }
        }

        private static void Search()
        {
            throw new NotImplementedException();
        }

        private static void List()
        {
            throw new NotImplementedException();
        }

        private static void Unpark()
        {
            throw new NotImplementedException();
        }

        private static void Park()
        {
            throw new NotImplementedException();
        }

        private static GarageHandler<Vehicle> CreateGarage()
        {


            Array[] cg = new Array[100];
            Console.WriteLine("Please take a time to creat a garage");
            string input = " ";
            input = Console.ReadLine();
            Console.WriteLine("What is the name of your garage? ");
            Console.WriteLine("Where do you want to creat your garage? ");
            Console.WriteLine("Which is the max capacity you want your garage to have? ");
            Console.ReadLine();


            
            return cg;
            //GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            //Garage<Vehicle> gar = gh.CreateGarage("Liljeholmen", "Stockholm", 100);
            //Console.WriteLine(gh.PrintGarage(gar));
            //Console.ReadLine();
            //return gh;
        }

        private static void Close()
        {
            Console.WriteLine("Thank you and good bye");
            System.Threading.Thread.Sleep(500);
            return;
        }

    }
}
