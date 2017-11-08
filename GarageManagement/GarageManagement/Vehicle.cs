﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    /// <summary>
    /// It holds the subclasses
    /// </summary>
    public class Vehicle    
    {

        private int registrationNumber;
        private string color;
        private int numberOfWheels;


        public int RegistrationNumber {get { return registrationNumber; }set { registrationNumber = value; }}
        public string Color {get { return color; }set { color = value; }}
        public int NumberOfWheels {get { return numberOfWheels; }set { numberOfWheels = value; }}

        //Default constructor
        public Vehicle(){}

        public Vehicle( int reg, string col, int nw)
        {
            RegistrationNumber = reg;
            Color = col;
            NumberOfWheels = nw;
        }     
    }
}
