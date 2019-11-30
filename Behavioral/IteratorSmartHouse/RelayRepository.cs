using System;
using System.Collections;
using System.Collections.Generic;

namespace Behavioral.IteratorSmartHouse
{
    internal class RelayRepository : IEnumerable<IRelay>
    {
        private readonly Func<IList<IRelay>, IEnumerator<IRelay>> _iteratorGenerator;
        private readonly IList<IRelay> _relays = new List<IRelay>();

        public RelayRepository(Func<IList<IRelay>, IEnumerator<IRelay>> iteratorGenerator)
        {
            _iteratorGenerator = iteratorGenerator;
        }

        public void Add(IRelay relay) => _relays.Add(relay);

        //either hardcode, or inject factory => reveal some aspects of inner implementation, or use template method
        //return new RecentlySwitchedOnRelayIterator(_relays, TimeSpan.FromSeconds(10));
        
        public IEnumerator<IRelay> GetEnumerator() => _iteratorGenerator(_relays);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
