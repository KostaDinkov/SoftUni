//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Multidimensional Arrays, Sets, Dictionaries
//  Problem:    7.Phonebook
//              Write a program that receives some info from the console about people 
//              and their phone numbers.
//              You are free to choose the manner in which the data is entered;
//              each entry should have just one name and one number(both of them strings). 
//              After filling this simple phone book, upon receiving the command "search", 
//              your program should be able to perform a search of a contact by name 
//              and print her details in format "{name} -> {number}". In case the 
//              contact isn't found, print "Contact {name} does not exist." 

using System;
using System.Collections.Generic;

namespace Problem7
{
    class P7
    {
        static void Main()
        {
            Console.WriteLine("Enter a single name (first or last) and a telephone\nnumber separated by semicolon in the form 'John:000123'");
            Console.WriteLine("To enter search mode type 'search' \nand hit enter followed by the name you are searching");
            Console.WriteLine("To exit type 'exit' and hit enter");
            Console.WriteLine("---INPUT MODE---");

            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string command = string.Empty;
            while (!command.Equals("exit"))
            {
                command = Console.ReadLine();
                if (command.Equals("exit"))
                {
                    break;
                }
                if (command.Equals("search"))
                {
                    Console.WriteLine("---SEARCH MODE---");
                    string name = String.Empty;
                    while (true)
                    {
                        name = Console.ReadLine();
                        if (name.Equals("exit"))
                        {
                            return;
                        }
                        Console.WriteLine(phonebook.ContainsKey(name)
                            ? $"{name} -> {phonebook[name]}"
                            : $"Contact {name} does not exist.");
                    }
                }

                try
                {
                    string[] inputLine = command.Split(':');
                    if (phonebook.ContainsKey(inputLine[0]))
                    {
                        phonebook[inputLine[0]] = inputLine[1];
                        Console.WriteLine("Contact changed");
                    }
                    else
                    {
                        phonebook.Add(inputLine[0], inputLine[1]);
                        Console.WriteLine("Contact created");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
