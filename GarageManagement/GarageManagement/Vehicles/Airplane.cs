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
    public class Airplane : Vehicle
    {
       private string name; 
       private string type;
       private int yea;


       public int Year { get { return yea; } set { yea = value; } } 
       public string Type { get { return type; } set { type = value; } } 
       public string Name { get { return name; } set { name = value; } }

        //Creating a default constructor
        public Airplane(){}

        public Airplane(int cyl, int yea, string typ, string nam, int nums, int numeg)
        {
            CylinderVolume = cyl;
            Year = yea;
            Type = typ;
            Name = nam;
            NumberOfSeats = nums;
            NumberOfEngines = numeg;
        }
        public string PrintAirplane()
        {
            return "Your airplane name is " + Name + "\nAnd it is: " + Type + " type" +
                "\nIt is: " + Year + " model" + "\nThe number of engines = " + NumberOfEngines + 
                "\nAnd the number of seats" + NumberOfSeats +".";
        }
    }
}
