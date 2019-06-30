namespace Clocks
{
    public abstract class BaseClock
    {
        public bool Invariant => InvariantDefinition;

        protected virtual bool InvariantDefinition => true;

        public int Hour { get; protected set; }
        public int Minute { get; protected set; }
        public int Second { get; protected set; }

        protected BaseClock()
        {
        }

        protected BaseClock(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        
        public void AddHours(int hour)
        {
            Hour += hour;
        }
        
        public void AddMinutes(int minute)
        {
            Hour   += minute / 60;
            Minute += minute % 60;
        }

        public void AddSeconds(int second)
        {
            Hour   += second / 3600;
            Minute += second % 3600 / 60;
            Second += second % 3600 % 60;
        }
    }
}