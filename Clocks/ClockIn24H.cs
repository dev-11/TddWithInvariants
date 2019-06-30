namespace Clocks
{
    public class ClockIn24H : BaseClock
    {
        protected override bool InvariantDefinition => Hour   >= 0 && Hour    < 24
                                                    && Minute >= 0 && Minute <= 59
                                                    && Second >= 0 && Second <= 59
                                                    && base.InvariantDefinition;

        public ClockIn24H() {}

        public ClockIn24H(int hour, int minute, int second)
        {
            Hour   = hour;
            Minute = minute;
            Second = second;
        }
    }
}