namespace _3.AsynchronousTimer
{
    using System;
    using System.Timers;

    internal class AsyncTimer
    {
        private readonly Action action;
        private readonly uint interval;
        private readonly int ticks;
        private int tickCounter;
        private Timer timer;

        public AsyncTimer(uint interval, int ticks, Action action)
        {
            this.action = action;
            this.interval = interval;
            this.ticks = ticks;
        }

        public void Start()
        {
            this.timer = new Timer(this.interval);
            this.timer.Elapsed += this.TimerElapsed;
            this.timer.Enabled = true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.action();
            this.tickCounter ++;
            if (this.tickCounter == this.ticks)
            {
                this.timer.Enabled = false;
            }
        }
    }
}