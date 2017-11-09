﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.Vehicles
{
    /// <summary>
    /// Subclass that inherites from the vehicle and add a new properity.
    /// </summary>
    public class Bus : Vehicle
    {

        private int numberOfSeats;

        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set { numberOfSeats = value; }
        }


        //Creating a default constructor
        public Bus(){}

        public Bus(string reg, string col, int nw, int numofs) : base(reg, col, nw)
        {
            NumberOfSeats = numofs;
        }

        public string PrintBus()
        {
            return "Registration number " + RegistrationNumber + "\nAnd the color: " + Color +
                "\nAnd it has" + NumberOfWheels +" Wheels"+ "\nAnd has: "+ NumberOfSeats+ " seats"+ ".";
        }
    }
}
