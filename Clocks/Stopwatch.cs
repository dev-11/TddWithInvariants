using System.Diagnostics.CodeAnalysis;

namespace Clocks
{
    public class Stopwatch : BaseClock
    {
        [ExcludeFromCodeCoverage]
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

        public int Hour => (int) Time / SecondsInAnHour;
        public int Minute => (int) Time / SecondsInAMinute % 60;
        public int Second => (int) Time % 60;
    }
}