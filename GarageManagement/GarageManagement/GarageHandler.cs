using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    /// <summary>
    /// This class is between the UI and the actual garage class handling the functionality that the UI needs access to.
    /// </summary>
     class GarageHandler : Garage                              //Making the class public
    {
       public void MainMenu()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("Welcome User!");
                Console.WriteLine("Please tell us what do you want to do"+
                    " by choosing between the bellow options!");
                Console.WriteLine("1) Create a garage");
                Console.WriteLine("2) Park");
                Console.WriteLine("3) Unpark");
                Console.WriteLine("4) Exite");

                char input = ' '; //creating the character input to be used with switch-case.

                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the firset car in an input line.

                }
                catch (IndexOutOfRangeException)//if the user input is empty, then we ask again for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");

                }

                switch (input)
                {
                    case '1':
                        Console.Clear();
                        CreateGarage();
                        break;

                    case '2':
                        Console.Clear();
                        Park();
                        break;

                    case '3':
                        Console.Clear();
                        Unpark();
                        break;

                    case '4':
                        Console.Clear();
                        Exit();
                        break;

                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input");
                        break;
                }
            }
        }
    }
}
