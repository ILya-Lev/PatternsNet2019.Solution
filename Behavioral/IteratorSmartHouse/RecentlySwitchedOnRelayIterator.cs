using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BehavioralDemos")]

namespace Behavioral.IteratorSmartHouse
{
    internal class RecentlySwitchedOnRelayIterator : IEnumerator<IRelay>
    {
        /// <summary>
        /// relay which was turned on before this time is not "recently switched on" any more
        /// </summary>
        private readonly TimeSpan _timeThreshold;

        private readonly IList<IRelay> _relays;
        private int _counter = -1;

        public RecentlySwitchedOnRelayIterator(IList<IRelay> relays, TimeSpan timeThreshold)
        {
            _relays = relays;
            _timeThreshold = timeThreshold;
        }

        public void Dispose() { }

        public void Reset() => _counter = -1;

        object IEnumerator.Current => Current;

        public IRelay Current
        {
            get
            {
                if (_counter < 0 || _counter > _relays.Count - 1)
                    return default;

                return _relays[_counter];
            }
        }

        public bool MoveNext()
        {
            while (++_counter < _relays.Count)
            {
                var turnOnTime = _relays[_counter].LastTimeSwitchOnAt;
                if (DateTime.Now - turnOnTime > _timeThreshold)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
