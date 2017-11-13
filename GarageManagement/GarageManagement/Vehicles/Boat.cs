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
    public class Boat : Vehicle
    {
        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }


        //Creating a default constructor
        public Boat(){}

        public Boat(string reg, string col, int nw, int leng) : base(reg, col, nw)
        {
            Length = leng;
        }
        public override string ToString()
        {
            return base.ToString() + "\nAnd has length: " + Length + " meter" + ".";
        }
    }
}
