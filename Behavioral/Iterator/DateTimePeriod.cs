using System;
using System.Collections;
using System.Collections.Generic;

namespace Behavioral.Iterator
{
    public enum Step {Hour, Day, Week, Month};
    public enum Commodity {Gas, Power, Oil, Emission};

    public class DateTimePeriod //[s;e)
    {
        public DateTime Start { get; set; }
        /// <summary>
        /// excluding this value
        /// </summary>
        public DateTime End { get; set; }

        public IReadOnlyList<DateTime> ToDateTimeList(Step step)
        {
            var timeSequence = new List<DateTime>();
            for (var current = Start; current < End; current = current.Next(step))
            {
                timeSequence.Add(current);
            }
            return timeSequence;
        }

        //after a while, another method was required - depends on commodity
        public IReadOnlyList<DateTime> ToDateTimeList(Step step, Commodity commodity)
        {
            var timeSequence = new List<DateTime>();
            for (var current = Start; current < End; current = current.Next(step, commodity))
            {
                timeSequence.Add(current);
            }
            return timeSequence;
        }

        //and another...

        //possible solution is to have an iterator which will go through the period with defined step
    }

    /// <summary>
    /// adapter for <see cref="DateTimePeriod"/> which implements IEnumerable T
    /// </summary>
    public class DateTimePeriodEnumerable : DateTimePeriod, IEnumerable<DateTime>
    {
        private readonly Func<DateTime, DateTime> _stepDefinition;

        public DateTimePeriodEnumerable(Func<DateTime, DateTime> stepDefinition)
        {
            _stepDefinition = stepDefinition;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<DateTime> GetEnumerator()
        {
            for (var current = Start; current < End; current = _stepDefinition(current))
            {
                yield return current;
            }
        }
    }

    public static class DateTimeExtensions
    {
        private static readonly Dictionary<Step, Func<DateTime,DateTime>> _stepRuleStorage = new Dictionary<Step, Func<DateTime, DateTime>>()
        {
            [Step.Hour] = dt => dt.AddHours(1),
            [Step.Day] = dt => dt.AddDays(1),
            [Step.Week] = dt => dt.AddDays(7),
            [Step.Month] = dt => dt.AddMonths(1),
        };

        private static readonly Dictionary<Commodity, Func<DateTime, DateTime>> _commodityRuleStorage = new Dictionary<Commodity, Func<DateTime, DateTime>>()
        {
            [Commodity.Emission] = dt => dt.Hour < 18 ? dt.Date.AddDays(-1).AddHours(18) : dt.Date.AddHours(18),
            [Commodity.Gas] = dt => dt.Hour < 6 ? dt.Date.AddDays(-1).AddHours(6) : dt.Date.AddHours(6),
            [Commodity.Oil] = dt => dt.Hour < 12 ? dt.Date.AddDays(-1).AddHours(12) : dt.Date.AddHours(12),
            [Commodity.Power] = dt => dt.Hour < 14 ? dt.Date.AddDays(-1).AddHours(14) : dt.Date.AddHours(14),
        };

        public static DateTime Next(this DateTime dt, Step step)
        {
            return _stepRuleStorage.TryGetValue(step, out var rule)
                ? rule(dt)
                : throw new Exception($"{nameof(Next)} action rule is not defined for {nameof(Step)} {step}");
        }

        public static DateTime Next(this DateTime dt, Step step, Commodity commodity)
        {
            var nextCandidate = dt.Next(step);
            return _commodityRuleStorage.TryGetValue(commodity, out var rule)
                ? rule(nextCandidate)
                : throw new Exception($"{nameof(Next)} action rule is not defined for {nameof(Commodity)} {commodity}");
        }
    }
}