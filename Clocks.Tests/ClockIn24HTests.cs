using FluentAssertions;
using Xunit;

namespace Clocks.Tests
{
    public class ClockIn24HTests
    {
        [Fact]
        public void InvariantIsTrueOnEmptyCtor()
        {
            var time = new ClockIn24H();
            time.Invariant.Should().BeTrue();
        }

        [Theory]
        [InlineData(-1,  0,  0)]
        [InlineData(24,  0,  0)]
        [InlineData(-1, -1, -1)]
        [InlineData(25, 60, 60)]
        public void InvariantBreaksOnIncorrectCtorParameters(int hour, int minute, int second)
        {
            var clock = new ClockIn24H(hour, minute, second);
            clock.Invariant.Should().BeFalse();
        }

        [Theory]
        [InlineData(0,   0,  0)]
        [InlineData(2,   4,  6)]
        [InlineData(23, 59, 59)]
        public void CtorCreatesObject(int hour, int minute, int second)
        {
            var clock = new ClockIn24H(hour,minute, second);
            clock.Invariant.Should().BeTrue();
            
            clock.Hour.Should().Be(hour);
            clock.Minute.Should().Be(minute);
            clock.Second.Should().Be(second);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(-1)]
        public void InvariantBreaksOnOutOfRangeHour(int hour)
        {
            var clock = new ClockIn24H();

            clock.Invariant.Should().BeTrue();
            
            clock.AddHours(hour);

            clock.Invariant.Should().BeFalse();
        }

        [Theory]
        [InlineData(1440)]
        [InlineData(-1)]
        public void InvariantBreaksOnOutOfRangeMinute(int minute)
        {
            var clock = new ClockIn24H();
            clock.Invariant.Should().BeTrue();
            
            clock.AddMinutes(minute);
            
            clock.Invariant.Should().BeFalse();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(86400)]
        public void InvariantBreaksOnOutOfRangeSeconds(int seconds)
        {
            var clock = new ClockIn24H();
            clock.Invariant.Should().BeTrue();

            clock.AddSeconds(seconds);

            clock.Invariant.Should().BeFalse();
        }

        [Theory]
        [InlineData( 0)]
        [InlineData( 1)]
        [InlineData(12)]
        [InlineData(23)]
        public void AddHourAddsHour(int hour)
        {
            var clock = new ClockIn24H();

            clock.Hour.Should().Be(0);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.Invariant.Should().BeTrue();
            
            clock.AddHours(hour);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(hour);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
        }

        [Theory]
        [InlineData(   0,  0,  0)]
        [InlineData(   1,  0,  1)]
        [InlineData( 100,  1, 40)]
        [InlineData( 120,  2,  0)]
        [InlineData(1234, 20, 34)]
        [InlineData(1439, 23, 59)]
        public void AddMinutesAddsMinute(int minute, int expectedHour, int expectedMinute)
        {
            var clock = new ClockIn24H();

            clock.Hour.Should().Be(0);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.Invariant.Should().BeTrue();

            clock.AddMinutes(minute);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(expectedHour);
            clock.Minute.Should().Be(expectedMinute);
            clock.Second.Should().Be(0);
        }

        [Theory]
        [InlineData(    0,  0,  0,  0)]
        [InlineData(  100,  0,  1, 40)]
        [InlineData(  120,  0,  2,  0)]
        [InlineData(86399, 23, 59, 59)]
        [InlineData(12345,  3, 25, 45)]
        public void AddSecondAddsSecond(int seconds, int expectedHour, int expectedMinute, int expectedSecond)
        {
            var clock = new ClockIn24H();

            clock.Hour.Should().Be(0);
            clock.Minute.Should().Be(0);
            clock.Second.Should().Be(0);
            clock.Invariant.Should().BeTrue();
            
            clock.AddSeconds(seconds);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(expectedHour);
            clock.Minute.Should().Be(expectedMinute);
            clock.Second.Should().Be(expectedSecond);
        }

        [Theory]
        [InlineData(30,2,0)]
        [InlineData(31,2,1)]
        [InlineData(95,3,5)]
        public void AddMinuteRollsHour(int minutes, int expectedHour, int expectedMinute)
        {
            var clock = new ClockIn24H(1,30, 0);
            clock.Hour.Should().Be(1);
            clock.Minute.Should().Be(30);
            clock.Second.Should().Be(0);
            clock.Invariant.Should().BeTrue();

            clock.AddMinutes(minutes);
            
            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(expectedHour);
            clock.Minute.Should().Be(expectedMinute);
            clock.Second.Should().Be(0);
        }

        [Theory]
        [InlineData(1,1,0,0)]
        [InlineData(61,1,1,0)]
        [InlineData(12345,4,25,44)]
        public void AddSecondsRollsMinuteAndHour(int seconds, int expectedHour, int expectedMinute, int expectedSecond)
        {
            var clock = new ClockIn24H(0,59, 59);
            clock.Hour.Should().Be(0);
            clock.Minute.Should().Be(59);
            clock.Second.Should().Be(59);
            clock.Invariant.Should().BeTrue();

            clock.AddSeconds(seconds);

            clock.Invariant.Should().BeTrue();
            clock.Hour.Should().Be(expectedHour);
            clock.Minute.Should().Be(expectedMinute);
            clock.Second.Should().Be(expectedSecond);
        }
    }
}