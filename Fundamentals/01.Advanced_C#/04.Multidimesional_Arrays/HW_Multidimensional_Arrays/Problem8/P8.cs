//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Multidimensional Arrays, Sets, Dictionaries
//  Problem:    7.Night Life
//              Being a nerd means writing programs about night clubs instead of actually going 
//              to ones.Spiro is a nerd and he decided to summarize some info about the most 
//              popular night clubs around the world.
//              He's come up with the following structure – he'll summarize the data by city, 
//              where each city will have a list of venues and each venue will have a list of 
//              performers. Help him finish the program, so he can stop staring at the computer 
//              screen and go get himself a cold beer.
//              You'll receive the input from the console. There will be an arbitrary number of lines 
//              until you receive the string "END". Each line will contain data in format: "city;venue;performer".
//              If either city, venue or performer don't exist yet in the database, add them. If either the city and/or 
//              venue already exist, update their info.
//              Cities should remain in the order in which they were added, venues should be sorted alphabetically and 
//              performers should be unique (per venue) and also sorted alphabetically.
//              Print the data by listing the cities and for each city its venues (on a new line starting with "->") 
//              and performers(separated by comma and space). Check the examples to get the idea.And grab a beer when 
//              you're done, you deserve it. Spiro is buying.

//NOTE: Provided in a TestInput.txt file in the project there is some test input for copying and pasting in the console!

using System;
using System.Collections.Generic;

namespace Problem8
{
    class P8
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,SortedSet<string>>> schedule = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine.Equals("END"))
                {
                    break;
                }
                string[] input = inputLine.Split(';');
                string city = input[0];
                string venue = input[1];
                string performer = input[2];

                if (schedule.ContainsKey(city))
                {
                    if (schedule[city].ContainsKey(venue))
                    {
                        schedule[city][venue].Add(performer);
                    }
                    else
                    {
                        schedule[city].Add(venue,new SortedSet<string>() {performer});
                    }
                }
                else
                {
                    schedule.Add(city,new Dictionary<string, SortedSet<string>>() );
                    schedule[city].Add(venue, new SortedSet<string>() { performer });
                }
            }
            //print the info
            List<string> cities = new List<string>(schedule.Keys);
            foreach (var city in cities)
            {
                Console.WriteLine(city);
                List<string> venues = new List<string>(schedule[city].Keys);
                foreach (var venue in venues)
                {
                    string performers = string.Join(", ",schedule[city][venue]);
                    Console.WriteLine($"->{venue}: {performers}");
                }
            }
            
            
        }
    }
}
