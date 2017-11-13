using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    public class GarageHandler<T> where T : Vehicle
    {
        public void SetName(Garage<T> garage, string name)
        {
            garage.Name = name;
        }

        public string GetName(Garage<T> garage)
        {
            return garage.Name;
        }

        public void SetAddress(Garage<T> garage, string address)
        {
            garage.Address = address;
        }

        public string GetAddress(Garage<T> garage)
        {
            return garage.Address;
        }

        public void SetCapacity(Garage<T> garage, int capacity)
        {
            garage.Capacity = capacity;
        }

        public int GetCapacity(Garage<T> garage)
        {
            return garage.Capacity;
        }

        public int GetCount(Garage<T> garage)
        {
            return garage.Count;
        }

        public string ParkVehicle(Garage<T> garage, T vehicle, int slot)
        {
            string message = "";
            if (slot < 0 || slot > garage.Capacity)
            {
                message = "The position you want to park is not existed";
                return message;
            }
            else
            {
                if (slot == 0)
                {
                    slot = garage.FirstEmptySlot + 1;
                }
                if (slot == 0)
                {
                    message = "The garage is full";
                    return message;
                }
                if (garage.Park(vehicle, slot - 1))
                    message = "You parked successfully at slot " + slot + "\n" + this.PrintGarage(garage);
                else
                    message = "The slot you want to park is not empty.";
                return message;
            }
            
        }

        public string UnParkVehicle(Garage<T> garage, string reg, int slot)
        {
            string message = "";
            
            if (slot < 0 || slot > garage.Capacity)
            {
                message = "The position you want to unpark is not existed";
                return message;
            }
            else
            {
                if (slot == 0)
                {
                    slot = garage.FindIndex(reg) + 1;
                }
                if (slot == 0)
                {
                    message = "The vehicle with the registration number not found";
                    return message;
                }
                if (garage.Unpark(slot - 1))
                    message = "You unparked successfully at slot " + slot + "\n" + this.PrintGarage(garage);
                else
                    message = "The slot you want to unpark is empty.";
                return message;
            } 
            
        }

        public Garage<T> CreateGarage(string name, string address, int capacity)
        {
            Garage<T> garage = new Garage<T>(name, address, capacity);
            return garage;
        }

        public string PrintGarage(Garage<T> garage)
        {
            return "Name: " +  garage.Name +
                "\nAdress: " + garage.Address +
                "\nMaximum capacity: " + garage.Capacity +
                "\nNumber of ocuppied slots: " + garage.Count +
                "\nNumber of empty slots: " + (garage.Capacity - garage.Count);
        }

        public string ShowList(Garage<Vehicle> gar)
        {
             return gar.List();
 
        }

        public string TypeVehicle (Garage<Vehicle> gar)
        {
            return gar.ListType();
        }

        //public string SearchByReg (Garage<Vehicle> gar, string reg)
        //{
        //    return ; 
        //}

    }
}
