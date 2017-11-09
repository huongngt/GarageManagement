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
            Console.Clear();
            List<string> pa = new List<string>();
            Console.WriteLine("                       IT IS PARKERING TIME");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Please take your time to find your vehicle to unpark it... ");
            Console.Write("What is the registration number of your vehicle? ");
            string userunpark = Console.ReadLine();
            pa.Add(userunpark);
            foreach (var item in pa)
            {
                Console.WriteLine("Your: " + userunpark + " is ready to unpark."
                    + "\nPlease notice that our parking has totaly {0} parkering places," +
                     "and still {1} free places of them.", pa.Capacity, pa.Capacity);
            }
            Console.WriteLine("\n--------------Unparked---------------");
            Console.ReadLine();
           
        }

        public void Park(Garage<Vehicle> gar)             //making the method public
        {
            Console.Clear();
            List<string> pa = new List<string>();
            Console.WriteLine("                       IT IS PARKERING TIME");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Please tell us what do you want to park? " +
                "\n1) Airplane." + "\n2) Boat." + "\n3) Car." + "\n4) Motorcycle.");
            string userinput = Console.ReadLine();
            Console.WriteLine("Please answer the below questions...");
            Console.Write("What is the registration number of the vehicle? ");   //The registration number can be number and letter at the same time, so we use string input!!
            Console.ReadLine();
            Console.Write("What is the color of the vehicle? ");
            Console.ReadLine();
            Console.Write("How many wheels does the vehicle have? ");
            int number;
            while(!int.TryParse(Console.ReadLine(), out number))   //validation the user input to integer.
            {
                Console.Write("Invalid number! Please try again. ");
            }
            if (userinput == "1")
            {
                userinput = "Airplane";
                Console.Write("How many engines does your airplane have? ");
                while(!int.TryParse(Console.ReadLine(), out number))         
                {
                    Console.Write("Invalid number! Please try again. ");
                }
             }
            else if (userinput == "2")
            {
                userinput = "Boat";
                Console.Write("What is the length of your boat? ");
                while(!int.TryParse(Console.ReadLine(), out number))         
                {
                    Console.Write("Invalid number! Please try again. ");
                }
            }
            else if (userinput == "3")
            {
                userinput = "Car";
                Console.Write("Which fuel type does your car have? ");
            }
            else if (userinput == "4")
            {
                userinput = "Motorcycle";
                Console.Write("How much cylinder volume does the motorcycle have? ");
                while(!int.TryParse(Console.ReadLine(), out number))                    
                {
                    Console.WriteLine("Invalid input! Please try again. ");
                }
            }
            else
            {
                return;
            }
            pa.Add(userinput);
            foreach (var item in pa)
            {
                Console.WriteLine("\nYour: "+ userinput  + " now parked."
                     + "\nPlease notice that our parking has totaly {0} parkering places," +
                     "and still {1} free places of them.", pa.Capacity, pa.Capacity - pa.Count);
            }
            Console.WriteLine("\n--------------Parked---------------");
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
        }

        private static void Close()
        {
            Console.WriteLine("Thank you and good bye");
            System.Threading.Thread.Sleep(500);
            return;
        }

    }
}
