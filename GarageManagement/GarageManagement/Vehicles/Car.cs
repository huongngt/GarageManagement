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
        private string model;
        private string color;


        public string Model { get { return model; } set { model = value; } }
        public string Color { get { return color; } set { color = value; } }
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
