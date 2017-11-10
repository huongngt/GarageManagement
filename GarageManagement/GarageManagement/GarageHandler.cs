using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    /// <summary>
    /// Class to abtract the real Garage class
    /// </summary>
    /// <typeparam name="T"> vehicle type only</typeparam>
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

        public string ShowType(Garage<Vehicle> gar)
        {
            string result = "";
            var vlist = gar.OfType<Vehicle>().Where(x => x != null).GroupBy(x => x.GetType().Name).Select(g => new
            {
                type = g.Key,
                count = g.Count()
            });
            foreach (var v in vlist)
            {
                result += v.type + ": " + v.count + "\n";

            }
            return result;
        }

        private void PagingList(List<int> list,int NoPage)
        {
            string results = "";
            for (int i = 0; i < list.Count; i = i + NoPage)
            {
                results = "";
                var items = list.Skip(i).Take(NoPage);
                for (int j = i; j < i+items.Count(); j++)
                {
                    results += (list.ElementAt(j)+1) + ", ";                
                }
                Console.Write(results.Substring(0,results.Length-2));
                Console.ReadLine();
            }
        }

        public void ShowEmpty(Garage<Vehicle> gar)
        {
            PagingList(gar.ListPos(false), 20);
        }

        public void ShowOccupied(Garage<Vehicle> gar)
        {
            PagingList(gar.ListPos(true), 20);
        }

        public void FindReg(Garage<Vehicle> gar, string reg)
        {
            var vlist = gar.FindVehicleByReg(reg);
            if (vlist.Count == 0)
                Console.WriteLine("The vehicle with registration number {0} is not found", reg);
            else
            {
                foreach (var v in vlist)
                {
                    Console.WriteLine("Slot: " + (v.Key+1) + "\n" + v.Value);
                }
            }            
        }

        public void FindWheels(Garage<Vehicle> gar, int wheels)
        {
            var vlist = gar.FindVehicleByWheels(wheels);
            if (vlist.Count == 0)
                Console.WriteLine("Not find any vehicle with {0} wheels ", wheels);
            else
            {
                foreach (var v in vlist)
                {
                    Console.WriteLine("Slot: " + (v.Key + 1) + "\n" + v.Value);
                }
            }
        }

        public void FindColor(Garage<Vehicle> gar, string color)
        {
            var vlist = gar.FindVehicleByColor(color);
            if (vlist.Count == 0)
                Console.WriteLine("Not find any vehicle with {0} wheels ", color);
            else
            {
                foreach (var v in vlist)
                {
                    Console.WriteLine("Slot: " + (v.Key + 1) + "\n" + v.Value);
                }
            }
        }

        public void ShowListType(Garage<Vehicle> gar, string typ)
        {
            var vlist = gar.OfType<Vehicle>().Where(x => x.GetType().Name.Equals(typ,StringComparison.InvariantCultureIgnoreCase));
            if (vlist.Count() == 0)
                Console.WriteLine("Not found any vehicle from the type {0}", typ);
            else
                foreach (var v in vlist)
                    Console.WriteLine(v);                
        }
    }
}
