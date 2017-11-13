using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.Vehicles
{
    /// <summary>
    ///Subclass that inherites from the vehicle and add a new properity. 
    /// </summary>
    public class Motorcycle : Vehicle
    {

        private int cylinderVolume;

        public int CylinderVolume
        {
            get { return cylinderVolume; }
            set { cylinderVolume = value; }
        }



        //Creating a default constructor
        public Motorcycle(){}

        public Motorcycle(string reg, string col, int nw, int cyli) : base(reg, col, nw)
        {
            CylinderVolume = cyli;
        }
        public override string ToString()
        {
            return base.ToString() + "\nAnd the cylinder volume is: " + CylinderVolume + ".";
        }
    }
}
