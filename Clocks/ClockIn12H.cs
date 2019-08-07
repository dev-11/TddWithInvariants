namespace Clocks
{
    public class ClockIn12H : ClockIn24H
    {
        public ClockIn12H()
        {
        }

        public ClockIn12H(int hour, int minute, int second) : base(hour, minute, second)
        {
        }

        public new int Hour
        {
            get
            {
                DayPeriod = base.Hour >= 12 ? DayPeriod.PM : DayPeriod.AM;

                if (base.Hour == 0)
                {
                    return 12;
                }
                
                return base.Hour - (base.Hour > 12 ? 12 : 0);
            }
        }

        public DayPeriod DayPeriod { get; private set; }

        protected override bool InvariantDefinition => Hour >= 1 && Hour <= 12
                                                    && DayPeriod != DayPeriod.Undefined
                                                    && base.InvariantDefinition;
    }
}