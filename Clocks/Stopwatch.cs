namespace Clocks
{
    public class Stopwatch : BaseClock
    {
        protected override bool InvariantDefinition => Hour >= 0 
                                                    && Minute >= 0 && Minute <= 59
                                                    && Second >= 0 && Second <= 59
                                                    && base.InvariantDefinition;

        public Stopwatch()
        {
        }

        public Stopwatch(int hour, int minute, int second) : base(hour, minute, second)
        {
        }
    }
}