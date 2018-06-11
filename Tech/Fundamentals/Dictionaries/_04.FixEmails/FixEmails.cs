using System;
using System.Collections.Generic;

namespace _04.FixEmails
{
    class FixEmails
    {
        static void Main()
        {
            var contacts = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();
                if (name == "stop") break;
                var email = Console.ReadLine();

                if (!email.EndsWith("us") && !email.EndsWith("uk"))
                {
                    if (contacts.ContainsKey(name))
                    {
                        contacts[name] = email;
                    }
                    else
                    {
                        contacts.Add(name,email);
                    }
                }
                
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Key} -> {contact.Value}");
            }
        }
    }
}