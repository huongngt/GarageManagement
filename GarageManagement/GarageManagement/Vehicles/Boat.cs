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
    public class Boat : Vehicle
    {
        
        //Creating a default constructor
        public Boat(){}

        public Boat(int cyl, int yea, string typ, string nam)
        {
            CylinderVolume = cyl;
            Year = yea;
            Type = typ;
            Name = nam;
        }
        public string PrintBoat()
        {
            return "Your boat name is " + Name + "\nAnd it is: " + Type+" type"+
                "\nIt is: " + Year +" model" + "\nThe cylinder volume = " + CylinderVolume +".";
        }
    }
}
