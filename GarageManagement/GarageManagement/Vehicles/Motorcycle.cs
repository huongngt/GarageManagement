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
    public class Motorcycle : Vehicle
    {
        private int yea;
        private int maxspeed;

        public int MaxSpeed { get { return maxspeed; } set { maxspeed = value; } }
        public int Year { get { return yea; } set { yea = value; } }
        //Creating a default constructor
        public Motorcycle(){}

        public Motorcycle( int cyl, int yea, int maxs, string mod)
        {
            CylinderVolume = cyl;
            Year = yea;
            MaxSpeed = maxs;
            Model = mod;
        }
        public string PrintMotorcycle()
        {
            return "\nIt is: " + Model + "Motorcycle's" + "Model: "+ Model  + "\nThe cylinder volume = " + CylinderVolume +
                "\nAnd the MaxSpeed is: " + MaxSpeed;
        }
    }
}
