using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    /// <summary>
    /// It holds the subclasses
    /// </summary>
    public class Vehicle   //Making the class public
    {
        private int cylindervolume;
        private int yea;
        private int maxspeed;
        private string model;
        private string type;
        private string name;
        private int numberofseatys;
        private int numberofengines;
        private string fueltype;
        private int length;
        private string color;

        public string Name { get { return name; } set { name = value; } }
        public string Type { get { return type; } set { type = value; } }
        public int CylinderVolume { get { return cylindervolume; } set { cylindervolume = value; } }
        public int Year { get { return yea; } set { yea = value; } }
        public int MaxSpeed { get { return maxspeed; } set { maxspeed = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int NumberOfSeats { get { return numberofseatys; } set { numberofseatys = value; } }
        public int NumberOfEngines { get { return numberofengines; } set { numberofengines = value; } }
        public string FuelType { get { return fueltype; } set { fueltype = value; } }
        public int Length { get { return length; } set { length = value; } }
        public string Color { get { return color; } set { color = value; } }

    }
}
