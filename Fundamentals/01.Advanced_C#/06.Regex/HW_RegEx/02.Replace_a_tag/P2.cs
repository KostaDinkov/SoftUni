//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Regular Expressions
//  Problem:    2. Replace <a> tag
//              Write a program that replaces in a HTML document given as string all 
//              the tags<a href=…>…</a> with corresponding tags[URL href =…]…[/URL]. 
//              Print the result on the console
using System;
using System.Text.RegularExpressions;

namespace _02.Replace_a_tag
{
    class P2
    {
        static void Main()
        {
            string html = System.IO.File.ReadAllText(@"..\..\test.html");
            Console.WriteLine(Regex.Replace(html, @"<a(.*?)>(.*?)<\/a>", "[URL $1 ] $2 [/URL]"));

        }
    }
}
