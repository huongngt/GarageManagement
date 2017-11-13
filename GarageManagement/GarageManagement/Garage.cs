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
        private T[] vehicleArray;

        public Garage()
        {

        }

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

        public string List()
        {
            string result = "";
            for (int i = 0; i < Capacity; i++)
                if (vehicleArray[i] != null)
                {
                    result += "Slot " + (i + 1) + "\n" + vehicleArray[i].GetType().Name + "\n" + vehicleArray[i] + "\n"; 
                    
                }
            return result;
        }


        public string ListType()
        {
            string resultT = "";
            var vtype= vehicleArray.Where(x => x != null).Select(x => x.GetType().Name);
            foreach (var v in vtype)
            {
                resultT += v + "|";
            }
  
            return resultT;
        }

        public int FindIndex(string registrationnumber)
        {
            return Array.FindIndex(vehicleArray, x => x != null && x.RegistrationNumber == registrationnumber);
            
        }
        //Creating a dictionary to search through the list with the registration number.

        //    public Dictionary<int, T> SearchByreg (string registrationnumber)
        //{
        //    return SearchByreg;
        //}

        /*
         * These functions are what lets us implement the IEnumerable interface
         * The yield return lets the function return multiple times without having to call 
         * the function again and again.
         */

        public IEnumerator<T> GetEnumerator()
        {

            for (int i = 0; i < count; i++)
            {
                yield return vehicleArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)vehicleArray).GetEnumerator();
        }

        internal string SearchByreg()
        {
            throw new NotImplementedException();
        }
    }
}
