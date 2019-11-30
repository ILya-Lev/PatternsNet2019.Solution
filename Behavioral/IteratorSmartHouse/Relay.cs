using System;

namespace Behavioral.IteratorSmartHouse
{
    internal class Relay : IRelay
    {
        private static int _instanceNumber = 0;
        private readonly int _id = 0;
        public DateTime? LastTimeSwitchOnAt { get; private set; } = null;

        public Relay() { _id = _instanceNumber++; }

        public string On()
        {
            LastTimeSwitchOnAt = DateTime.Now;
            return $"Relay #{_id} is On";
        }

        public string Off()
        {
            var suffix = LastTimeSwitchOnAt.HasValue
                ? $"after {DateTime.Now - LastTimeSwitchOnAt}"
                : "and was never On";
            return $"Relay #{_id} is Off {suffix}";
        }
    }
}
