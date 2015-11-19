/*
** SoftUni
** Course:		OOP
** Lecture:		Defining Classes
** Problem:		2.Laptop Shop
** Description:	Define a class Laptop that holds the following 
**              information about a laptop device: model, manufacturer, processor, 
**              RAM, graphics card, HDD, screen, battery, battery life in hours and price...
**
** Date:		Tuesday 11.2015 23:09 
*/

using System;
using System.Runtime.InteropServices;

namespace _02.LaptopShop
{
    class Program
    {
        static void Main()
        {
            Laptop ibm = new Laptop("IBM",2999);
            Laptop lenovo = new Laptop("Yoga",3999,"Intel Core i7",4);
            lenovo.LaptopBattery  = new Battery("LiIon", 4, 500);
            Console.WriteLine(ibm);
            Console.WriteLine();
            Console.WriteLine(lenovo);
        }
    }
}
