using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.HandsOfCards
{
    class HandsOfCards
    {
         static Dictionary<string, int> powers = new Dictionary<string, int>()
        {
            {"2",2},
            {"3",3},
            {"4",4},
            {"5",5},
            {"6",6},
            {"7",7},
            {"8",8},
            {"9",9},
            {"10",10},
            {"J",11},
            {"Q",12},
            {"K",13},
            {"A",14},

        };
        static Dictionary<string,int> types = new Dictionary<string,int>()
        {
            {"S",4},
            {"H",3},
            {"D",2},
            {"C",1}
        };
        static void Main(string[] args)
        {
            
            var players = new Dictionary<string,HashSet<string>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "JOKER") break;

                var tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0].Trim();
                var cards = new HashSet<string>(tokens[1].Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(e=>e.Trim()));

                if (players.ContainsKey(name))
                {
                    players[name].UnionWith(cards);
                }
                else
                {
                    players.Add(name,cards);
                }
            
                
            }

            foreach (var player in players)
            {
                var score = 0;
                foreach (var card in player.Value)
                {
                    score += GetCardValue(card);
                }

                Console.WriteLine($"{player.Key}: {score}");
            }
            
        }

        private static int GetCardValue(string card)
        {
            var power = card.Substring(0,card.Length-1);
            var type = card.Substring(card.Length - 1);

            return powers[power] * types[type];
        }
    }
}