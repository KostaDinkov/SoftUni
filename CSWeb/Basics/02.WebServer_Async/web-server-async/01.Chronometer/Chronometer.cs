
using System.Collections.Generic;
using System.Diagnostics;


namespace _01.Chronometer
{
    class Chronometer : IChronometer
    {
        public string GetTime => GetElapsedTime();

        public List<string> Laps { get; }

        private Stopwatch sw;

        public Chronometer()
        {
            sw = new Stopwatch();
            Laps = new List<string>();
        }
        public void Start()
        {
            sw.Start();
        }

        public void Stop()
        {
            sw.Stop();
        }

        public string Lap()
        {
            string elapsed = GetTime;
            Laps.Add(elapsed);

            return elapsed;
        }

        public void Reset()
        {
            Laps.Clear();
            sw.Reset();
        }

        private string GetElapsedTime()
        {
            return (sw.Elapsed.Minutes.ToString().PadLeft(2, '0') + ":" + 
                    sw.Elapsed.Seconds.ToString().PadLeft(2, '0') + ":" + 
                    sw.Elapsed.Milliseconds.ToString().PadLeft(4,'0'));
        }


    }
}
