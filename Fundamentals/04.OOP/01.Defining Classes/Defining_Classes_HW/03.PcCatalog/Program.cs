/*
** SoftUni
** Course:		OOP
** Lecture:		Defining Classes
** Problem:		3. Pc Catalog
** Description:	Define a class Computer that holds name, several components and price. 
**              The components (processor, graphics card, motherboard, etc.) should be objects of class 
**              Component, which holds name, details (optional) and price... 
** 	
** Date:		Wednesday 11.2015 20:29 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PcCatalog
{
    internal class Program
    {
        private static void Main()
        {
            List<Computer> myComputers = new List<Computer>();

            Computer homeDesktop = new Computer("Custom Desktop PC");
            homeDesktop.AddComponent(new Component("Graphics Card", 599.32m, "RAM: 2 GB"));
            homeDesktop.AddComponent(new Component("RAM", 200m, "16 GB"));
            homeDesktop.AddComponent(new Component("Case", 100m));
            homeDesktop.AddComponent(new Component("CPU", 1000, "Intel i7 @ 3.5GHz"));
            homeDesktop.AddComponent(new Component("Case",50m)); // this should overwrite the existing 'Case'
            myComputers.Add(homeDesktop);

            Computer laptop = new Computer("Vaio laptop",
                new Component("Display", 300),
                new Component("Battery", 133.3m),
                new Component("Charger", 50.5m));
            myComputers.Add(laptop);

            Computer tablet = new Computer("Surface 4",
                new Component("Tablet", 1200),
                new Component("Stylus", 100));
            myComputers.Add(tablet);

            // sort the computers
            List<Computer> sortedComputers = myComputers.OrderByDescending(comp => comp.TotalPrice).ToList();

            foreach (var computer in sortedComputers)
            {
                Console.WriteLine(computer.GetInfo());
                Console.WriteLine();
            }
        }
    }
}