using FluentAssertions;
using Xunit;

namespace Clocks.Tests
{
    public class ClockIn12HTests
    {
        [Fact]
        public void InvariantIsTrueOnEmptyCtor()
        {
            var clock = new ClockIn12H();
            clock.Invariant.Should().BeTrue();
        }

        [Fact]
        public void MidnightIsInTheRightFormat()
        {
            var clock = new ClockIn12H(0,0,0);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(12);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.AM);
        }

        [Fact]
        public void NoonIsInTheRightFormat()
        {
            var clock = new ClockIn12H(12,0,0);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(12);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.PM);
        }


        [Fact]
        public void AddHoursTurnsMorningToAfternoon()
        {
            var clock = new ClockIn12H(11,0,0);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(11);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.AM);
            
            clock.AddHours(2);
            
            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(1);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.PM);
        }

        [Fact]
        public void AddHoursTurnsAfternoonToMorning()
        {
            var clock = new ClockIn12H(14,0,0);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(2);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.PM);
            
            clock.AddHours(-4);
            
            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(10);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.AM);
        }

        [Fact]
        public void AddMinutesTurnsMorningToAfternoon()
        {
            var clock = new ClockIn12H(9,0,0);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(9);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.AM);
            
            clock.AddMinutes(600);
            
            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(7);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.PM);
        }

        [Fact]
        public void AddSecondsTurnsMorningToAfternoon()
        {
            var clock = new ClockIn12H(9,30,0);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(9);
            clock.Minute.Should().Be(30);
            clock.Second.Should().Be(0);
            clock.DayPeriod.Should().Be(DayPeriod.AM);
            
            clock.AddSeconds(12345);
            
            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(12);
            clock.Minute.Should().Be(55);
            clock.Second.Should().Be(45);
            clock.DayPeriod.Should().Be(DayPeriod.PM);
        }
    }
}