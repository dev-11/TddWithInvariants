using FluentAssertions;
using Xunit;

namespace Clocks.Tests
{
    public class StopwatchTests
    {
        [Fact]
        public void InvariantIsTrueOnEmptyCtor()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Invariant.Should().BeTrue();
        }

        [Theory]
        [InlineData(-1,  0,  0)]
        //[InlineData(24,  0,  0)]
        [InlineData(12, -1,  0)]
        [InlineData(12, 60,  0)]
        [InlineData(12,  0, -1)]
        [InlineData(12,  0, 60)]
        [InlineData(-1, -1, -1)]
        [InlineData(25, 60, 60)]
        public void InvariantBreaksOnIncorrectCtorParameters(int hour, int minute, int second)
        {
            var stopwatch = new Stopwatch(hour, minute, second);
            stopwatch.Invariant.Should().BeFalse();
        }

        [Theory]
        [InlineData(0,   0,  0)]
        [InlineData(2,   4,  6)]
        [InlineData(23, 59, 59)]
        [InlineData(24,  0,  0)]
        public void CtorCreatesObject(int hour, int minute, int second)
        {
            var stopwatch = new Stopwatch(hour,minute, second);
            stopwatch.Invariant.Should().BeTrue();
            
            stopwatch.Hour.Should().Be(hour);
            stopwatch.Minute.Should().Be(minute);
            stopwatch.Second.Should().Be(second);
        }

        [Theory]
//        [InlineData(100)]
        [InlineData(-1)]
        public void InvariantBreaksOnOutOfRangeHour(int hour)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Invariant.Should().BeTrue();
            
            stopwatch.AddHours(hour);

            stopwatch.Invariant.Should().BeFalse();
        }

        [Theory]
        //[InlineData(1440)]
        [InlineData(-1)]
        public void InvariantBreaksOnOutOfRangeMinute(int minute)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Invariant.Should().BeTrue();
            
            stopwatch.AddMinutes(minute);
            
            stopwatch.Invariant.Should().BeFalse();
        }

        [Theory]
        [InlineData(-1)]
        //[InlineData(86400)]
        public void InvariantBreaksOnOutOfRangeSeconds(int seconds)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Invariant.Should().BeTrue();
            
            stopwatch.AddSeconds(seconds);

            stopwatch.Invariant.Should().BeFalse();
        }

        [Theory]
        [InlineData( 0)]
        [InlineData( 1)]
        [InlineData(12)]
        [InlineData(23)]
        [InlineData(24)]
        public void AddHourAddsHour(int hour)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Hour.Should().Be(0);
            stopwatch.Minute.Should().Be(0);
            stopwatch.Second.Should().Be(0);
            stopwatch.Invariant.Should().BeTrue();
            
            stopwatch.AddHours(hour);

            stopwatch.Invariant.Should().BeTrue();
            stopwatch.Hour.Should().Be(hour);
            stopwatch.Minute.Should().Be(0);
            stopwatch.Second.Should().Be(0);
        }

        [Theory]
        [InlineData(   0,  0,  0)]
        [InlineData(   1,  0,  1)]
        [InlineData( 100,  1, 40)]
        [InlineData( 120,  2,  0)]
        [InlineData(1234, 20, 34)]
        [InlineData(1439, 23, 59)]
        [InlineData(1440, 24, 00)]
        public void AddMinutesAddsMinute(int minute, int expectedHour, int expectedMinute)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Hour.Should().Be(0);
            stopwatch.Minute.Should().Be(0);
            stopwatch.Second.Should().Be(0);
            stopwatch.Invariant.Should().BeTrue();

            stopwatch.AddMinutes(minute);

            stopwatch.Invariant.Should().BeTrue();
            stopwatch.Hour.Should().Be(expectedHour);
            stopwatch.Minute.Should().Be(expectedMinute);
            stopwatch.Second.Should().Be(0);
        }

        [Theory]
        [InlineData(    0,  0,  0,  0)]
        [InlineData(  100,  0,  1, 40)]
        [InlineData(  120,  0,  2,  0)]
        [InlineData(86399, 23, 59, 59)]
        [InlineData(86400, 24, 00, 00)]
        [InlineData(12345,  3, 25, 45)]
        public void AddSecondAddsSecond(int seconds, int expectedHour, int expectedMinute, int expectedSecond)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Hour.Should().Be(0);
            stopwatch.Minute.Should().Be(0);
            stopwatch.Second.Should().Be(0);
            stopwatch.Invariant.Should().BeTrue();
            
            stopwatch.AddSeconds(seconds);

            stopwatch.Invariant.Should().BeTrue();
            stopwatch.Hour.Should().Be(expectedHour);
            stopwatch.Minute.Should().Be(expectedMinute);
            stopwatch.Second.Should().Be(expectedSecond);
        }
    }
}