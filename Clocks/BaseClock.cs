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
            var newMinute = Minute + minute;

            Hour   += newMinute / 60;
            Minute  = newMinute % 60;
        }

        public void AddSeconds(int second)
        {
            var newSecond = Second + second;
            var newMinute = Minute + newSecond % 3600 / 60;

            Hour   += newMinute / 60 + newSecond / 3600 % 60;
            Minute  = newMinute % 60;
            Second  = newSecond % 3600 % 60;
        }
    }
}