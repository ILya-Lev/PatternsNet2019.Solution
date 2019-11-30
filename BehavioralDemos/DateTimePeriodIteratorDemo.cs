using System;
using Behavioral.Iterator;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace BehavioralDemos
{
    public class DateTimePeriodIteratorDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        public DateTimePeriodIteratorDemo(TestOutputHelper output) { _output = output; }

        [Fact]
        public void IterateByStep()
        {
            var period = new DateTimePeriod()
            {
                Start = new DateTime(2019, 11, 26),
                End = new DateTime(2019, 12, 01),
            };

            var days = period.ToDateTimeList(Step.Day);
            days.Should().HaveCount(5);
            foreach (var day in days)
            {
                _output.WriteLine($"{day}");
            }
        }

        [Fact]
        public void IterateByStep_viaIterator()
        {
            var period = new DateTimePeriodEnumerable(dt => dt.Next(Step.Day, Commodity.Gas))
            {
                Start = new DateTime(2019, 11, 26),
                End = new DateTime(2019, 12, 01),
            };

            foreach (var day in period)
            {
                _output.WriteLine($"{day}");
            }
        }
    }
}