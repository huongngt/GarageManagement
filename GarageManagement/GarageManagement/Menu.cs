﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement
{
    public class Menu
    {

        public List<MenuItem> menulist = new List<MenuItem>();
        public string Description { get; set; }
        public string Color { get; set; }

        public void AddMenuItem(string option, string description, Action action)
        {
            MenuItem item = new MenuItem();
            item.Description = description;
            item.option = option;
            item.RelatedAction = action;
            menulist.Add(item);
        }

        private void Display()
        {
            Console.Clear();
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), this.Color, true);
            Console.WriteLine(Description);
            foreach (var item in menulist)
            {
                Console.WriteLine(item.Description);
            }
        }

        public void ShowMenu()
        {
            bool DisplayMenu = true;
            while (DisplayMenu)
            {
                this.Display();                
                string input = Console.ReadLine();
                if (input == "0") DisplayMenu = false;
                this.ExecuteEntry(input);
            } 
        }

        public void ExecuteEntry(string option)
        {
            var item = menulist.Where(p => p.option == option).ToList();
            if (item.Count == 0)
            {
                Console.WriteLine("Incorrect choice");
                Console.ReadLine();
            }
            else
                item[0].ExecuteEntry();
        }

    }
}
