﻿using System;
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

            Garage<Vehicle> gr = new Garage<Vehicle>();

            Menu MainMenu = new Menu();
            MainMenu.Description = "Main Menu:";
            MainMenu.AddMenuItem("1", "Enter 1 if you want to create a new garage", new Action(() => { gr=CreateGarage(); }));
            MainMenu.AddMenuItem("2", "Enter 2 if you want to park your vehicle", new Action(() => { Park(gr); }));
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

        private static void Park(Garage<Vehicle> gar)
        {
            throw new NotImplementedException();

        }

        private static Garage<Vehicle> CreateGarage()
        {            
            Console.Clear();
            Console.WriteLine("CREATE A NEW GARAGE");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("Please input the name of garage: ");
            string name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Console.Write("Name can not be an empty string. Please input again: ");
                name = Console.ReadLine();
        }

            Console.Write("Please input the address of garage: ");
            string address = Console.ReadLine();

            Console.Write("Please input the capacity of garage: ");
            int capacity;
            while(!int.TryParse(Console.ReadLine(),out capacity))
        {
                Console.Write("Invalid capacity.Please input again: ");
            }

            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gar = gh.CreateGarage(name, address, capacity);
            Console.WriteLine("--------------New garage---------------");
            Console.WriteLine(gh.PrintGarage(gar));
            //Console.Clear();
            //Console.WriteLine("Your garage name is: {0} and it is located in {1} with MaxCapacity {2}", name, address, capacity);
            Console.ReadLine();
            return gar;
        }

        private static void Close()
        {
            Console.WriteLine("Thank you and good bye");
            System.Threading.Thread.Sleep(500);
            return;
        }

    }
}
