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
        private int numberofengines;
        private int cylindervolume;
        private string fueltype;
        private int numberofseatys;
        private int length;
        

        public int NumberOfSeats { get { return numberofseatys; } set { numberofseatys = value; } }
        public int CylinderVolume { get { return cylindervolume; } set { cylindervolume = value; } }
        public string FuelType { get { return fueltype; } set { fueltype = value; } }
        public int NumberOfEngines { get { return numberofengines; } set { numberofengines = value; } }
        public int Length { get { return length; } set { length = value; } }


        
        
        
        

    }
}
