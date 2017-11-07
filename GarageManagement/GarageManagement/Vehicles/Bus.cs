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
    public class Bus : Vehicle
    {
        
        //Creating a default constructor
        public Bus(){}

        public Bus( int cyl, string fuelt, int nums, int leng)
        {
            CylinderVolume = cyl;
            FuelType = fuelt;
            NumberOfSeats = nums;
            Length = leng;
        }

        public string PrintBus()
        {
            return "\nThe bus has" + NumberOfSeats + " seats" + "\n And it is: " + Length +  
                "\nThe fuel type is: " + FuelType  + "\nThe cylinder volume = " + CylinderVolume + ".";
        }
    }
}
