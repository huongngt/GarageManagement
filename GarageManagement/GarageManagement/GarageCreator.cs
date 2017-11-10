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
            MainMenu.AddMenuItem("3", "Enter 3 if you want to unpark your vehicle", new Action(() => { Unpark(gr); }));
            MainMenu.AddMenuItem("4", "Enter 4 if you want to see information about the garage", new Action(() => { List(gr); }));
            MainMenu.AddMenuItem("5", "Enter 5 if you want to search about vehicle", new Action(() => { Search(); }));
            MainMenu.AddMenuItem("0", "Enter 0 to Exit", new Action(() => { Close(); }));
            MainMenu.ShowMenu();
        }

        #region SubMenu
        private static void Search()
        {
            Menu SubMenu = new Menu();
            SubMenu.Description = "Search Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 if you want to search vehicle by registration number", new Action(() => { }));
            SubMenu.AddMenuItem("2", "Enter 2 if you want to search vehicle by type", new Action(() => { }));
            SubMenu.AddMenuItem("3", "Enter 3 if you want to search vehicle by number of wheel", new Action(() => { }));
            SubMenu.AddMenuItem("4", "Enter 4 if you want to search vehicle by color", new Action(() => { }));
            SubMenu.AddMenuItem("0", "Enter 0 if you want to come back the main menu", new Action(() => { }));
            SubMenu.ShowMenu();
        }

        private static void List(Garage<Vehicle> gar)
        {
            Menu SubMenu = new Menu();
            SubMenu.Description = "List Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 if you want to list all parked vehicles", new Action(() => { DisplayList(gar,1); }));
            SubMenu.AddMenuItem("2", "Enter 2 if you want to list all types currently parked vehicle", new Action(() => { DisplayList(gar, 2); }));
            SubMenu.AddMenuItem("3", "Enter 3 if you want to list all available slots", new Action(() => { }));
            SubMenu.AddMenuItem("4", "Enter 4 if you want to list all occupied slot", new Action(() => { }));
            SubMenu.AddMenuItem("0", "Enter 0 if you want to come back the main menu", new Action(() => { }));
            SubMenu.ShowMenu();
        }

        private static void Park(Garage<Vehicle> gar)
        {
            Menu SubMenu = new Menu();
            SubMenu.Description = "Paking Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 if you want to park an airplane", new Action(() => { AddVehicle(gar, CreateVehicle(1)); }));
            SubMenu.AddMenuItem("2", "Enter 2 if you want to park a boat", new Action(() => { AddVehicle(gar, CreateVehicle(2)); }));
            SubMenu.AddMenuItem("3", "Enter 3 if you want to park a bus", new Action(() => { AddVehicle(gar, CreateVehicle(3)); }));
            SubMenu.AddMenuItem("4", "Enter 4 if you want to park a car", new Action(() => { AddVehicle(gar, CreateVehicle(4)); }));
            SubMenu.AddMenuItem("5", "Enter 5 if you want to park a motorcycle", new Action(() => { AddVehicle(gar, CreateVehicle(5)); }));
            SubMenu.AddMenuItem("6", "Enter 6 if you want to see parked vehicles", new Action(() => { DisplayList(gar, 1); }));
            SubMenu.AddMenuItem("0", "Enter 0 if you want to come back main menu", new Action(() => { }));
            SubMenu.ShowMenu();
        }

        private static void Unpark(Garage<Vehicle> gar)
        {
            
            Menu SubMenu = new Menu();
            SubMenu.Description = "Unpark Menu:";
            SubMenu.AddMenuItem("1", "Enter 1 if you want to unpark your vehicle with resgiter number", new Action(() => { RemoveVehicle(gar, 1); }));
            SubMenu.AddMenuItem("2", "Enter 2 if you want to unpark your vehicle with slot", new Action(() => { RemoveVehicle(gar, 2); }));
            SubMenu.AddMenuItem("3", "Enter 3 if you want to see parked vehicles", new Action(() => { DisplayList(gar, 1); }));
            SubMenu.AddMenuItem("0", "Enter 0 if you want to come back the main menu", new Action(() => { }));
            SubMenu.ShowMenu();
        }

        #endregion


        #region methods
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
            while (!int.TryParse(Console.ReadLine(), out capacity))
            {
                Console.Write("Invalid capacity.Please input again: ");
            }

            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gar = gh.CreateGarage(name, address, capacity);
            Console.WriteLine("--------------New garage---------------");
            Console.WriteLine(gh.PrintGarage(gar));
            Console.ReadLine();
            return gar;

        }

        private static Vehicle CreateVehicle(int v)
        {

            Console.Clear();
            Console.WriteLine("ADD A NEW VEHICLE");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("Enter the registration number:");
            string reg = Console.ReadLine();
            if (String.IsNullOrEmpty(reg))
            {
                Console.Write("registration number can not be null.Please input again: ");
            }
            Console.Write("Enter the color:");
            string col = Console.ReadLine();

            Console.Write("Enter the number of wheels:");
            int nw;
            while (!int.TryParse(Console.ReadLine(), out nw))
            {
                Console.Write("Invalid number of wheels.Please input again: ");
            }
            if (v == 1)
            {
                Console.Write("Enter the number of engine:");
                int numof;
                while (!int.TryParse(Console.ReadLine(), out numof))
                {
                    Console.Write("Invalid number of engine.Please input again: ");
                }
                Airplane air = new Airplane(reg, col, nw, numof);
                return air;
            }
            else if (v == 2)
            {
                Console.Write("Enter the length of boat:");
                int leng;
                while (!int.TryParse(Console.ReadLine(), out leng))
                {
                    Console.Write("Invalid length of boat.Please input again: ");
                }
                Boat boat = new Boat(reg, col, nw, leng);
                return boat;
            }
            else if (v == 3)
            {
                Console.Write("Enter the number of seat:");
                int seat;
                while (!int.TryParse(Console.ReadLine(), out seat))
                {
                    Console.Write("Invalid number of seat.Please input again: ");
                }
                Bus bus = new Bus(reg, col, nw, seat);
                return bus;
            }
            else if (v == 4)
            {
                Console.Write("Enter the fuel type:");
                string fuel = Console.ReadLine();
                Car car = new Car(reg, col, nw, fuel);
                return car;
            }
            else
                Console.Write("Enter the cylinder volume:");
            int cyli;
            while (!int.TryParse(Console.ReadLine(), out cyli))
            {
                Console.Write("Invalid number of cylinder volume.Please input again: ");
            }
            Motorcycle moto = new Motorcycle(reg, col, nw, cyli);
            return moto;

        }

        private static void AddVehicle(Garage<Vehicle> gar, Vehicle v)
        {

            int position = 0;
            Console.Write("\nPlease input the position you want to park, or leave empty if you don't have any specific slot: ");
            string input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                while (!int.TryParse(input, out position))
                {
                    Console.Write("Invalid posion.Please input again: ");
                    input = Console.ReadLine();
                }
            }
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Console.WriteLine(gh.ParkVehicle(gar, v, position));
            Console.ReadLine();
        }

        private static void RemoveVehicle(Garage<Vehicle> gar, int v)
        {
            Console.Clear();
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            if (v == 1)
            {
                Console.Write("Please input the registration number of your vehicle: ");
                string regis = Console.ReadLine();
                Console.WriteLine(gh.UnParkVehicle(gar, regis, 0));
                Console.ReadLine();
            }
            else
            {
                Console.Write("Please input the slot of your vehicle: ");
                int slot;
                while (!int.TryParse(Console.ReadLine(), out slot))
                {
                    Console.Write("Invalid number of slot.Please input again: ");
                }
                Console.WriteLine(gh.UnParkVehicle(gar, null, slot));
                Console.ReadLine();
            }

        }        

        private static void DisplayList(Garage<Vehicle> gar,int v)
        {
            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Console.Clear();
            Console.WriteLine("LIST OF VEHICLES");
            Console.WriteLine("----------------------------------------------------------------------");
            if (v==1)
                Console.WriteLine(gh.ShowList(gar));
            //if (v == 2)
            //    Console.WriteLine(gh.ShowType(gar));
            Console.ReadLine();
        }

        private static void Close()
        {
            Console.WriteLine("Thank you and good bye");
            System.Threading.Thread.Sleep(500);
            return;
        }

        public string ShowType(Garage<Vehicle> gar)
        {
            string result = "";
            var vlist = gar.OfType<Vehicle>().Where(x => x != null).GroupBy(x => x.GetType().Name).Select(g => new
            {
                type = g.Key,
                vehicles = g,
                count = g.Count()
            });
            foreach (var v in vlist)
            {
                result += v.type + ": " + v.count + "\n";

            }
            return result;
        }

        #endregion

    }
}
