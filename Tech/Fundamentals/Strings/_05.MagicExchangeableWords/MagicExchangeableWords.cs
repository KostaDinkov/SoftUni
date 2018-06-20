using System;

namespace _05.MagicExchangeableWords
{
    using System.Collections.Generic;

    class MagicExchangeableWords
    {
        static void Main()
        {
            var inputTokens = Console.ReadLine().Trim().Split();
            HashSet<char> firstWord = new HashSet<char>(inputTokens[0]);
            HashSet<char> secondWord = new HashSet<char>(inputTokens[1]);
            Console.WriteLine((firstWord.Count == secondWord.Count) ? "true" : "false");
        }
    }
}