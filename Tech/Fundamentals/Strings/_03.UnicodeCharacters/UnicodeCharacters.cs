using System;

namespace _03.UnicodeCharacters
{
    using System.Text;

    class UnicodeCharacters
    {
        static void Main()
        {
            var input = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                result.Append("\\u" + ((int) c).ToString("X4").ToLower());
            }

            Console.WriteLine(result.ToString());

        }
    }
}