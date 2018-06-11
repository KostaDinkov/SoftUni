using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            var leftMostIndex = 0;
            var leftMostLen = 1;

            var inputList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            for (int i = 1; i < inputList.Count; i++)
            {
                var currentSeqStart = i - 1;
                var sequenceLen = 1;
                while (i < inputList.Count && inputList[i] == inputList[i - 1])
                {
                    sequenceLen++;
                    i++;
                    if (sequenceLen > leftMostLen)
                    {
                        leftMostLen = sequenceLen;
                        leftMostIndex = currentSeqStart;
                    }
                }
            }

            Console.WriteLine(String.Join(' ', inputList.GetRange(leftMostIndex, leftMostLen)));
        }
    }
}