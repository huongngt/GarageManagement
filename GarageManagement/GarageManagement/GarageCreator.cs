using GarageManagement;
using GarageManagement.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    /// <summary>
    /// This class holds the MainMenu
    /// </summary>
    public class GarageCreator
    {
        public void MainMenu()
        {

            Garage<Vehicle> gr = new Garage<Vehicle>("stock", "swed", 100);

            Menu MainMenu = new Menu();
            MainMenu.Description = "Main Menu:";
            MainMenu.AddMenuItem("1", "Enter 1 if you want to create a new garage", new Action(() => { gr=CreateGarage(); }));
            MainMenu.AddMenuItem("2", "Enter 2 if you want to park your vehicle", new Action(() => { Park(gr); }));
            MainMenu.AddMenuItem("3", "Enter 3 if you want to unpark you vehicle", new Action(() => { Unpark(gr); }));
            MainMenu.AddMenuItem("4", "Enter 4 if you want to see information about the garage", new Action(() => { List(); }));
            MainMenu.AddMenuItem("5", "Enter 5 if you want to search about vehicle", new Action(() => { Search(); }));
            MainMenu.AddMenuItem("0", "Enter 0 to Exit", new Action(() => { Close(); }));
            MainMenu.ShowMenu();
        }

        private static void Search()
        {
            /*
              List<Vehicle> pa = new List<Vehicle>();
            Vehicle item = pa.Find(c = > c.FieldId == "SomeFieldId");
            
            */
            throw new NotImplementedException();
        }

        private static void List()
        {
            throw new NotImplementedException();
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

        public void Park(Garage<Vehicle> gar)             
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
            Console.Write("How many wheels does the vehicle have? ");
            string nw = Console.ReadLine();
            int number;
            
            while (!int.TryParse(Console.ReadLine(), out number))    
            {
                Console.Write("Invalid number! Please try again. ");
            }
            if (userinput == "1")
            {
                userinput = "Airplane";
                string numof = Console.ReadLine();
                Console.Write("How many engines does your airplane have? ");
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
                Console.Write("What is the length of your boat? ");
                while(!int.TryParse(Console.ReadLine(), out number))         
                {
                    Console.Write("Invalid number! Please try again. ");
                }
                Boat a = new Boat(reg, col, number, number);
                gh.ParkVehicle(gar, a, 0);
            }
            else if (userinput == "3")
            {
                userinput = "Car";
                Console.Write("Which fuel type does your car have? ");
                string fuel = Console.ReadLine();
                Car a = new Car(reg, col, number, fuel);
                gh.ParkVehicle(gar, a, 0);
            }
            else if (userinput == "4")
            {
                userinput = "Motorcycle";
                Console.Write("How much cylinder volume does the motorcycle have? ");
                while(!int.TryParse(Console.ReadLine(), out number))                    
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
            while(!int.TryParse(Console.ReadLine(),out capacity))
            {
                Console.Write("Invalid capacity.Please input again: ");
            }

            GarageHandler<Vehicle> gh = new GarageHandler<Vehicle>();
            Garage<Vehicle> gar = gh.CreateGarage(name, address, capacity);
            Console.WriteLine("\n--------------New garage---------------");
            Console.WriteLine(gh.PrintGarage(gar));
            Console.ReadLine();
            return gar;
        }   //Ready

        private static void Close()
        {
            Console.WriteLine("Thank you and good bye");
            System.Threading.Thread.Sleep(500);
            return;
        }   //Ready

    }
}
