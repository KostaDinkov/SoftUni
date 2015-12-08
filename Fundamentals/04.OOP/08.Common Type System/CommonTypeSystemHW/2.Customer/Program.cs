//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Common Type System
// Problem:     2.Customer
// Description: Define a class Customer, which contains data about a customer – 
//              first name, middle name and last name, ID (EGN), permanent address, mobile phone, 
//                  e-mail, list of payments and customer type. 
//              •	Define a class Payment which holds a product name and price.
//              •	Define an enumeration for the customer type, holding the following types of 
//                  customers: One-time , Regular, Golden, Diamond.
//              •	Override the standard methods, inherited by System.Object: Equals(), ToString(), 
//              GetHashCode() and operators == and !=.
//              •	Implement the ICloneable interface. The Clone() method should make a deep copy of 
//                  all object fields into a new object of type Customer.
//              •	Implement the IComparable<Customer> interface to compare customers by full 
//                  name(as first criteria, in lexicographic order) and by ID(as second criteria, in ascending order).
//              
// Date:        Monday 12.2015 19:41 
//---------------------------------------------------

namespace _2.Customer
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //create some Customer instances
            var BobaFett = new Customer("Boba", "J", "Fett", 1234565342);
            BobaFett.Payments.Add(new Payment("Laser Blaster", 435543));
            BobaFett.Payments.Add(new Payment("Flame Thrower", 435532));

            var Revan = new Customer("Revan", "", "", 5342668492);
            Revan.Payments.Add(new Payment("Mysterious Mask", 57384));
            Revan.Payments.Add(new Payment("Lightsaber repair", 33235));

            //create new cloned Customer
            var RevanClone = (Customer) Revan.Clone();

            //check hash codes, they should differ
            Console.WriteLine(Revan.GetHashCode());
            Console.WriteLine(RevanClone.GetHashCode());

            //compare the objects first by values, then by reference
            Console.WriteLine(RevanClone.Equals(Revan));    //should print true
            Console.WriteLine(Revan == RevanClone);         //should print false

            //add them to a list and sort them
            var customers = new List<Customer>();
            customers.Add(BobaFett);
            customers.Add(Revan);
            customers.Add(new Customer("Han", "Fracking", "Solo", 43769485));

            customers.Sort();
            Console.WriteLine(string.Join("\n", customers));
        }
    }
}