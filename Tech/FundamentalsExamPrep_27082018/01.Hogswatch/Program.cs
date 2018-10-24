using System;

internal class Program
{
    private static void Main()
    {
        var homesToVisit = int.Parse(Console.ReadLine());
        var initialPresentCount = int.Parse(Console.ReadLine());

        var presentCount = initialPresentCount;
        var timesGoneBack = 0;

        var totalPresentsTaken = 0;

        for (var i = 0; i < homesToVisit; i++)
        {
            var presentsGiven = int.Parse(Console.ReadLine());


            //if he doesn't have enough presents
            if (presentCount - presentsGiven < 0)
            {
                var deficit = presentsGiven - presentCount;
                timesGoneBack++;
                presentCount = initialPresentCount / (i + 1) * (homesToVisit - i - 1) + deficit;
                totalPresentsTaken += presentCount;
                presentCount -= deficit;
                continue;
            }

            presentCount -= presentsGiven;
        }

        if (timesGoneBack < 1)
        {
            Console.WriteLine(presentCount);
        }
        else
        {
            Console.WriteLine(timesGoneBack);
            Console.WriteLine(totalPresentsTaken);
        }
    }
}