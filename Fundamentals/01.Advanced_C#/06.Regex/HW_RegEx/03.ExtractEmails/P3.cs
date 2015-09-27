//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Regular Expressions
//  Problem:    3.Extract Emails
//              Write a program to extract all email addresses from a given text.The text comes at 
//              the only input line.Print the emails on the console, each at a separate line.
//              Emails are considered to be in format<user>@<host>, where: 
//              •	<user> is a sequence of letters and digits, where '.', '-' and '_' can appear between them. 
//                  Examples of valid users: "stephan", "mike03", "s.johnson", "st_steward", "softuni-bulgaria", "12345". 
//                  Examples of invalid users: ''--123", ".....", "nakov_-", "_steve", ".info". 
//              •	<host> is a sequence of at least two words, separated by dots '.'. Each word is sequence of letters and 
//                  can have hyphens '-' between the letters.
//                  Examples of hosts: "softuni.bg", "software-university.com", "intoprogramming.info", "mail.softuni.org". 
//                  Examples of invalid hosts: "helloworld", ".unknown.soft.", "invalid-host-", "invalid-". 

using System;
using System.Text.RegularExpressions;

namespace _03.ExtractEmails
{
    class P3
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex((@"(?: |^)(([A-Za-z0-9]+\w*[\.\-]?)+\w*@([A-Za-z0-9-_]+\.){1,2}[A-z]+)"));
            MatchCollection matches = pattern.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value.Trim());
            }
        }
    }
}
