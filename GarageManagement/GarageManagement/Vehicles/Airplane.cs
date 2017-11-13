using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.Vehicles
{
    /// <summary>
    ///  Subclass that inherites from the vehicle and add a new properity.
    /// </summary>
    public class Airplane : Vehicle
    {
        private int numberOfEngines;

        public int NumberOfEngines
        {
            get { return numberOfEngines; }
            set { numberOfEngines = value; }
        }




        //Creating a default constructor
        public Airplane(){}

        public Airplane(string reg, string col, int nw, int numof) : base (reg, col, nw)
        {
            NumberOfEngines = numof;  
        }
        public override string ToString()     
        {
            return base.ToString() + "\nAnd has: " + NumberOfEngines + " engines" + ".";
        }
    }
}
