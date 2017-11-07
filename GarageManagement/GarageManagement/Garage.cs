using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private string name;
        private string address;
        private int count;
        private int capacity;
        private int firstEmptySlot;
        private T[] vehicleArray;

        public Garage(string name, string address, int capacity)
        {
            Capacity = capacity;
            Name = name;
            Address = address;
            vehicleArray = new T[capacity];
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count
        {
            get
            {
                count = vehicleArray.Count(s => s != null);
                return count;
            }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int FirstEmptySlot
        {
            get
            {
                return Array.FindIndex(vehicleArray, x => x == null);
            }

        }

        public bool Park(T vehicle, int slot)
        {
            if (vehicleArray[slot] == null)
            {
                vehicleArray[slot] = vehicle;
                count++;
                return true;
            }
            else
                return false;

        }

        public bool Unpark(int slot)
        {
            if (vehicleArray[slot] != null)
            {
                vehicleArray[slot] = null;
                count--;
                return true;
            }
            else
                return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)vehicleArray).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)vehicleArray).GetEnumerator();
        }
    }
}
