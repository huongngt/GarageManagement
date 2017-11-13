using GarageManagement.Vehicles;
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
            //hardcode just for test
            Garage<Vehicle> gr = new Garage<Vehicle>("test", "addr", 100);

            Menu MainMenu = new Menu();
            MainMenu.Description = "Main Menu:";
            MainMenu.AddMenuItem("1", "Enter 1 if you want to create a new garage", new Action(() => { gr = CreateGarage(); }));
            MainMenu.AddMenuItem("2", "Enter 2 if you want to park your vehicle", new Action(() => { Park(gr); }));
            MainMenu.AddMenuItem("3", "Enter 3 if you want to unpark you vehicle", new Action(() => { Unpark(gr); }));
            MainMenu.AddMenuItem("4", "Enter 4 if you want to see information about the garage", new Action(() => { List(gr); }));
            MainMenu.AddMenuItem("5", "Enter 5 if you want to search about vehicle", new Action(() => { Search(gr); }));
            MainMenu.AddMenuItem("0", "Enter 0 to Exit", new Action(() => { Close(); }));
            MainMenu.Color = "White";
            MainMenu.ShowMenu();
            }             //Ready

        #region SubMenu
        private static void Search(Garage<Vehicle> gar)
        {
            Menu SubMenu = new Menu();
            SubMenu.Description = "Search Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 if you want to search vehicle by registration number", new Action(() => { Search(gar, 1); }));
            SubMenu.AddMenuItem("2", "Enter 2 if you want to search vehicle by type", new Action(() => { Search(gar, 2); }));
            SubMenu.AddMenuItem("3", "Enter 3 if you want to search vehicle by number of wheel", new Action(() => { Search(gar, 3); }));
            SubMenu.AddMenuItem("4", "Enter 4 if you want to search vehicle by color", new Action(() => { Search(gar, 4); }));
            SubMenu.AddMenuItem("0", "Enter 0 if you want to come back the main menu", new Action(() => { }));
            SubMenu.Color = "Cyan";
            SubMenu.ShowMenu();
        }

        private static void List(Garage<Vehicle> gar)
        {
            Menu SubMenu = new Menu();
            SubMenu.Description = "List Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 if you want to list all parked vehicles", new Action(() => { DisplayList(gar, 1); }));
            SubMenu.AddMenuItem("2", "Enter 2 if you want to list all types currently parked vehicle", new Action(() => { DisplayList(gar, 2); }));
            SubMenu.AddMenuItem("3", "Enter 3 if you want to list all available slots", new Action(() => { DisplayList(gar, 3); }));
            SubMenu.AddMenuItem("4", "Enter 4 if you want to list all occupied slot", new Action(() => { DisplayList(gar, 4); }));
            SubMenu.AddMenuItem("0", "Enter 0 if you want to come back the main menu", new Action(() => { }));
            SubMenu.Color = "Yellow";
            SubMenu.ShowMenu();
        }

        private static void Park(Garage<Vehicle> gar)
        {
            Console.Clear();
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Console.WriteLine("                       IT IS PARKERING TIME");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Please tell us what do you want to park? " +
                "\n1) Airplane." + "\n2) Boat." + "\n3) Car." + "\n4) Motorcycle.");
            string userinput = Console.ReadLine();
            Console.WriteLine("Please answer the below questions...\n");
            Console.Write("What is the registration number of the vehicle? ");
            string reg = Console.ReadLine();
            Console.Write("What is the color of the vehicle? ");
            string col = Console.ReadLine();
            string nw = Console.ReadLine();
            int number;
            Console.WriteLine("How many wheels does the vehicle have? ");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Invalid number! Please try again. ");
            }
            if (userinput == "1")
            {
                userinput = "Airplane";
                string numof = Console.ReadLine();
                Console.WriteLine("How many engines does your airplane have? ");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Invalid number! Please try again. ");
                }
                Airplane a = new Airplane(reg, col, number, number);
                gh.ParkVehicle(gar, a, 0);
            }
            else if (userinput == "2")
            {
                userinput = "Boat";
                Console.WriteLine("What is the length of your boat? ");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Invalid number! Please try again. ");
                }
                Boat a = new Boat(reg, col, number, number);
                gh.ParkVehicle(gar, a, 0);
            }
            else if (userinput == "3")
            {
                userinput = "Car";
                Console.WriteLine("Which fuel type does your car have? ");
                string fuel = Console.ReadLine();
                Car a = new Car(reg, col, number, fuel);
                gh.ParkVehicle(gar, a, 0);
            }
            else if (userinput == "4")
            {
                userinput = "Motorcycle";
                Console.WriteLine("How much cylinder volume does the motorcycle have? ");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Invalid input! Please try again. ");
                }
                Motorcycle a = new Motorcycle(reg, col, number, number);
                gh.ParkVehicle(gar, a, 0);
            }
            Console.WriteLine("\n--------------Parked---------------");
            Console.WriteLine(gh.ShowList(gar));
            Console.ReadLine();
        }

        private static void Unpark(Garage<Vehicle> gar)
        {

            Console.Clear();
            List<string> pa = new List<string>();
            Console.WriteLine("                       IT IS PARKERING TIME");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Please take your time to find your vehicle to unpark it... ");
            Console.Write("What is the registration number of your vehicle? ");
            string userunpark = Console.ReadLine();
            GarageHandler<Vehicle> un = new GarageHandler<Vehicle>();
            Console.WriteLine(un.UnParkVehicle(gar, userunpark, 0));
            Console.WriteLine("\n--------------Unparked---------------");
            Console.WriteLine(un.ShowList(gar));
            Console.ReadLine();
        }
        #endregion

        #region methods
        private static Garage<Vehicle> CreateGarage()
        {
            Console.Clear();
            Console.WriteLine("                       CREATE A NEW GARAGE");
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
            while (!int.TryParse(Console.ReadLine(), out capacity))
            {
                Console.Write("Invalid capacity.Please input again: ");
            }

            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gar = gh.CreateGarage(name, address, capacity);
            Console.WriteLine("\n--------------New garage---------------");
            Console.WriteLine(gh.PrintGarage(gar));
            Console.ReadLine();
            return gar;


        }       //Ready

        private static void DisplayList(Garage<Vehicle> gar, int choice)
        {
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Console.Clear();
            
            if (choice == 1)
            {
                Console.WriteLine("LIST OF VEHICLES");
                Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(gh.ShowList(gar));
            }
            if (choice == 2)
            {
                Console.WriteLine("LIST OF VEHICLE TYPES");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(gh.ShowType(gar));
            }
            if (choice == 3)
            {
                Console.WriteLine("LIST OF AVAILABLE SLOTS");
                Console.WriteLine("----------------------------------------------------------------------");
                gh.ShowEmpty(gar);
            }
            if (choice == 4)
            {
                Console.WriteLine("LIST OF OCCUPIED SLOTS");
                Console.WriteLine("----------------------------------------------------------------------");
                gh.ShowOccupied(gar);
            }
            Console.ReadLine();
         }   //Read

        private static void Search(Garage<Vehicle> gar, int choice)
        {
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Console.Clear();
            Console.WriteLine("SEARCH VEHICLE");
            Console.WriteLine("----------------------------------------------------------------------");
            if (choice == 1)
            {
                Console.Write("Enter the registration number of the vehicle: ");
                string reg = Console.ReadLine();
                while (String.IsNullOrEmpty(reg))
                {
                    Console.Write("registration number can not be null.Please input again: ");
                    reg = Console.ReadLine();
                }
                gh.FindVehicleByReg(gar, reg);
            }
            if (choice == 2)
            {
                Console.Write("Enter the type of the vehicle: ");
                string typ = Console.ReadLine();
                while (String.IsNullOrEmpty(typ))
                {
                    Console.Write("Vehicle type can not be null.Please input again: ");
                    typ = Console.ReadLine();
                }
                gh.ShowListType(gar, typ);
            }
            if (choice == 3)
            {
                Console.Write("Enter the number of the wheels: ");
                int wheels;
                while (!int.TryParse(Console.ReadLine(), out wheels))
                {
                    Console.Write("Invalid number of the wheels.Please input again: ");
                }
                gh.FindVehicleByWheels(gar, wheels);

            }
            if (choice == 4)
            {
                Console.Write("Enter the color of the vehicle: ");
                string col = Console.ReadLine();
                while (String.IsNullOrEmpty(col))
                {
                    Console.Write("Vehicle color can not be null.Please input again: ");
                    col = Console.ReadLine();
                }
                gh.FindVehicleByColor(gar, col);
            }
            Console.ReadLine();
        }


        private static void Close()
        {
            Console.WriteLine("Thank you and good bye");
            System.Threading.Thread.Sleep(500);
            return;
        }
        #endregion

    }
}
                                                                                                                                                                                                