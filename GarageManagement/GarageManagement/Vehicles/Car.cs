using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.Vehicles
{
    /// <summary>
    /// 
    /// </summary>
    public class Car : Vehicle  
    {
        //Creating a default constructor
        public Car(){}

        public Car(int cyl, string fuelt, int nums, string col)
        {
            CylinderVolume = cyl;
            FuelType = fuelt;
            NumberOfSeats = nums;
            Color = col;
        }
        public string PrintCar()
        {
            return "Your car  is " + Color + " color" + "\nAnd it is: " + FuelType + " Fuel type" +
                "\nIt has: " + NumberOfSeats +" seats" + "\nThe cylinder volume = " + CylinderVolume + ".";
        }

    }
}
