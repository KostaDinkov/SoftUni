using System;
using System.Collections.Generic;

namespace _01.Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            var phonebook = new SortedDictionary<string,string>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                processInput(input, phonebook);
                input = Console.ReadLine();
            }
        }

        private static void processInput(string input, SortedDictionary<string, string> phonebook)
        {
            var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var operation = tokens[0];
            var contactName = tokens[1];
            var phone = "";
            if (operation == "A")
            {
                phone = tokens[2];
            }

            switch (operation)
            {
                case "A":
                    if (phonebook.ContainsKey(contactName))
                    {
                        phonebook[contactName] = phone;
                    }
                    else
                    {
                        phonebook.Add(contactName, phone);
                    }

                    break;
                case "S":
                    string result;
                    if (!phonebook.TryGetValue(contactName, out result))
                    {
                        result = $"Contact {contactName} does not exist.";
                    }
                    else
                    {
                        result = $"{contactName} -> {result}";
                    }

                    Console.WriteLine(result);
                    break;
            }
        }
    }
}