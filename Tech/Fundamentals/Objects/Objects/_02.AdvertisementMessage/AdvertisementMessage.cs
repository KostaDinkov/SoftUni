namespace _02.AdvertisementMessage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class AdvertisementMessage
    {
        private static List<string> phrases = new List<string>()
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can’t live without this product."
        };

        private static List<string> events = new List<string>()
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };

        private static List<string> authors =
            new List<string> {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};

        private static List<string> cities = new List<string> {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

        private static void Main()
        {
            int msgCount = int.Parse(Console.ReadLine());
            var rnd = new Random();

            for (int i = 0; i < msgCount; i++)
            {
                StringBuilder msg = new StringBuilder();

                msg.Append(phrases[rnd.Next(0, phrases.Count)]+" ");
                msg.Append(events[rnd.Next(0, events.Count)]+" ");
                msg.Append(authors[rnd.Next(0, authors.Count)]);
                msg.Append(" - ");
                msg.Append(cities[rnd.Next(0, cities.Count)]);

                Console.WriteLine(msg.ToString());
            }
        }
    }
}