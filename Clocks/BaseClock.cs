namespace Clocks
{
    public abstract class BaseClock
    {
        public bool Invariant => InvariantDefinition;

        protected virtual bool InvariantDefinition => Time >= 0;

        protected const int SecondsInAMinute = 60;
        protected const int SecondsInAnHour = SecondsInAMinute * 60;

        protected long Time { get; private set; }

        protected BaseClock()
        {
        }

        protected BaseClock(int hour, int minute, int second)
        {
            Time = SecondsInAnHour * hour + SecondsInAMinute * minute + second;
        }
        
        public void AddHours(int hour)
        {
            Time += hour * SecondsInAnHour;
        }
        
        public void AddMinutes(int minute)
        {
            Time += minute * SecondsInAMinute;
        }

        public void AddSeconds(int second)
        {
            Time += second;
        }
    }
}