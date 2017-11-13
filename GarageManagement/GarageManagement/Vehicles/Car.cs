using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.Vehicles
{
    /// <summary>
    /// Subclass that inherites from the vehicle and add a new properity.
    /// </summary>
    public class Car : Vehicle  
    {

        private string fueltype;

        public string FuelType
        {
            get { return fueltype; }
            set { fueltype = value; }
        }



        //Creating a default constructor
        public Car(){}

        public Car(int reg, string col, int nw, string fuel) : base(reg, col, nw)
        {
            FuelType = fuel;
        }
        public string PrintCar()
        {
            return "Registration number " + RegistrationNumber + "\nAnd the color: " + Color +
                 "\nAnd it has" + NumberOfWheels + " Wheels" + "\nAnd it goes with: " + FuelType + " as fuel type" + ".";
        }

    }
}
