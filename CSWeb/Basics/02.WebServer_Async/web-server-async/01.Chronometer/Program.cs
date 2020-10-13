using System;


namespace _01.Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            var chrono = new Chronometer();

            string command = "";
            while (command != "exit")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "lap":
                        Console.WriteLine(chrono.Lap());
                        break;
                    case "start":
                        chrono.Start();
                        break;
                    case "stop":
                        chrono.Stop();
                        break;
                    case "laps":
                        ;
                        if (chrono.Laps.Count == 0)
                        {
                            Console.WriteLine("Laps: no laps");
                        }
                        else
                        {
                            var lapIndex = 0;
                            Console.WriteLine("Laps:");
                            chrono.Laps.ForEach(lapTime =>
                            {
                                Console.WriteLine($"{lapIndex}. {lapTime}");
                                lapIndex++;
                            });
                        }
                        break;
                    case "time":
                        Console.WriteLine(chrono.GetTime);
                        break;
                    case "reset":
                        chrono.Reset();
                        break;
                    default:
                        return;
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
