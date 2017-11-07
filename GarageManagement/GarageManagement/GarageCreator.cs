using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    public class GarageCreator
    {
        public void MainMenu()
        {
            GarageHandler<Vehicle> gar = new GarageHandler<Vehicle>();
            Menu MainMenu = new Menu();
            MainMenu.Description = "Main Menu:";
            MainMenu.AddMenuItem("1", "Enter 1 if you want to create a new garage", new Action(() => { gar = CreateGarage(); }));
            MainMenu.AddMenuItem("2", "Enter 2 if you want to park your vehicle", new Action(() => { Park(gar); }));
            MainMenu.AddMenuItem("3", "Enter 3 if you want to unpark you vehicle", new Action(() => { Unpark(gar); }));
            MainMenu.AddMenuItem("4", "Enter 4 if you want to see information about the garage", new Action(() => { List(gar); }));
            MainMenu.AddMenuItem("5", "Enter 5 if you want to search about vehicle", new Action(() => { Search(gar); }));
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

        private static void Search(GarageHandler<Vehicle> gar)
        {
            throw new NotImplementedException();
        }

        private static void List(GarageHandler<Vehicle> gar)
        {
            throw new NotImplementedException();
        }

        private static void Unpark(GarageHandler<Vehicle> gar)
        {
            throw new NotImplementedException();
        }

        private static void Park(GarageHandler<Vehicle> gar)
        {
            if (gar== null)
            {
                Console.WriteLine("There is no garage to park");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("please input your vehicle information: ");
            }
        }

        private static GarageHandler<Vehicle> CreateGarage()
        {
            GarageHandler<Vehicle> gar1 = new GarageHandler<Vehicle>();
            Garage<Vehicle> gar = gar1.CreateGarage("Liljeholmen", "Stockholm", 100);
            Console.WriteLine(gar1.PrintGarage(gar));
            Console.ReadLine();
            return gar1;
        }

        private static void Close()
        {
            Console.WriteLine("Thank you and good bye");
            System.Threading.Thread.Sleep(500);
            return;
        }

    }
}
