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
            List<string> pa = new List<string>();
            Console.WriteLine("                       IT IS PARKERING TIME");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Please tell us what do you want to park? " +
                "\n1) Airplane." + "\n2) Boat." + "\n3) Car." + "\n4) Motorcycle."+ "\n0) Return to the MainMenu");
            bool park = true;
            while(park)
            {
                string value = Console.ReadLine();
                if (value != "" && value != null)
                {
                    char options = value[0];
                    //string options = Console.ReadLine();
                    switch (options)
                    {
                        case '1':
                            Console.Clear();
                            string userinput1 = value.Substring(1);
                            Console.Write("What is the registration number of your airplane? ");
                            Console.ReadLine();
                            Console.Write("What is the color of your airplane? ");
                            Console.ReadLine();
                            Console.Write("How many wheels does your airplane have? ");
                            Console.ReadLine();
                            Console.Write("How many engines does your airplane have? ");
                            Console.ReadLine();
                            pa.Add(userinput1);
                            break;
                        case '2':
                            Console.Clear();
                            string userinput2 = value.Substring(1);
                            Console.Write("What is the registration number of your boat? ");
                            Console.ReadLine();
                            Console.Write("What is the color of your boat? ");
                            Console.ReadLine();
                            Console.Write("How many wheels does your boat have? ");
                            Console.ReadLine();
                            Console.Write("What is the length of your boat? ");
                            Console.ReadLine();
                            pa.Add(userinput2);
                            break;
                        case '3':
                            Console.Clear();
                            string userinput3 = value.Substring(1);
                            Console.Write("What is the registration number of your car? ");
                            Console.ReadLine();
                            Console.Write("What is the color of your car? ");
                            Console.ReadLine();
                            Console.Write("How many wheels does your car have? ");
                            Console.ReadLine();
                            Console.Write("Which feul type does your car have? ");
                            Console.ReadLine();
                            pa.Add(userinput3);
                            break;
                        case '4':
                            Console.Clear();
                            string userinput4 = value.Substring(1);
                            Console.Write("What is the registration number of your motorcycle? ");
                            Console.ReadLine();
                            Console.Write("What is the color of your motorcycle? ");
                            Console.ReadLine();
                            Console.Write("How many wheels does the motorcycle have? ");
                            Console.ReadLine();
                            Console.Write("How much cylinder volume does the motorcycle have? ");
                            Console.ReadLine();
                            pa.Add(userinput4);
                            break;
                        case '0':
                            return;
                    }
                    foreach (var item in pa)
                    {
                        Console.WriteLine("\nYour: " + options + " now parked."
                             + "\nPlease notice that our parking has totaly {0} parkering places," +
                             "and still {1} free places of them.", pa.Capacity, pa.Capacity - pa.Count);
                    }
                }
            }
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
