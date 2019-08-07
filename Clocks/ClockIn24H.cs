namespace Clocks
{
    public class ClockIn24H : BaseClock
    {
        protected override bool InvariantDefinition => Hour   >= 0 && Hour    < 24
                                                    && Minute >= 0 && Minute <= 59
                                                    && Second >= 0 && Second <= 59
                                                    && base.InvariantDefinition
                                                    && Time < 86400;

        public ClockIn24H() {}

        public ClockIn24H(int hour, int minute, int second) : base(hour, minute,second)
        {
        }

        public int Hour => (int) Time / SecondsInAnHour;
        public int Minute => (int) Time / SecondsInAMinute % 60;
        public int Second => (int) Time % 60;
    }
}