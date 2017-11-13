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

        public Car(string reg, string col, int nw, string fuel) : base(reg, col, nw)
        {
            FuelType = fuel;
        }
        public override string ToString()
        {
            return base.ToString() + "\nAnd it goes with: " + FuelType + " as fuel type" + ".";
        }

    }
}
