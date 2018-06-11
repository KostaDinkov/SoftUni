using System;
using System.Collections.Generic;


namespace _02.PhonebookUpgrade
{
    class PhonebookUpgrade
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
            var contactName = "";
            var phone = "";
            

            switch (operation)
            {
                case "A":
                    phone = tokens[2];
                    contactName = tokens[1];
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
                    contactName = tokens[1];
                    
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
                case "ListAll":
                    foreach (var contact in phonebook)
                    {
                        Console.WriteLine($"{contact.Key} -> {contact.Value}");
                    }

                    break;
            }
        }
    }
}