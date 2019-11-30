using System;
using System.Collections.Generic;
using System.Threading;
using Behavioral.IteratorSmartHouse;
using Xunit;
using Xunit.Sdk;

namespace BehavioralDemos
{
    public class IteratorSmartHouseDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        public IteratorSmartHouseDemo(TestOutputHelper output) { _output = output; }

        [Fact]
        public void ForeachLoop_2OutOf5AreOnTooLong_IterateOver2Only()
        {
            var trace = new List<string>(); //results of turning on/off each and any of the relay

            var oldAfter = TimeSpan.FromSeconds(2);
            //pay attention container (repository) is separated from iterator ! STL in C++ and the TRUE POWER!!!!
            var repo = new RelayRepository(relayList => new RecentlySwitchedOnRelayIterator(relayList, oldAfter));

            CreateOnAndStore(repo, 2, trace);

            Thread.Sleep(TimeSpan.FromSeconds(3));

            CreateOnAndStore(repo, 3, trace);

            //the magic!
            foreach (IRelay relay in repo)
            {
                TurnOff(relay, trace);
            }
        }

        [Fact]
        public void WhileLoop_2OutOf5AreOnTooLong_IterateOver2Only()
        {
            var trace = new List<string>(); //results of turning on/off each and any of the relay

            var oldAfter = TimeSpan.FromSeconds(1);
            //pay attention container (repository) is separated from iterator ! STL in C++ and the TRUE POWER!!!!
            var repo = new RelayRepository(relayList => new RecentlySwitchedOnRelayIterator(relayList, oldAfter));

            CreateOnAndStore(repo, 2, trace);

            Thread.Sleep(TimeSpan.FromSeconds(3));

            CreateOnAndStore(repo, 3, trace);

            //the magic!
            using IEnumerator<IRelay> iterator = repo.GetEnumerator();

            while (iterator.MoveNext())
            {
                var relay = iterator.Current;
                TurnOff(relay, trace);
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
            iterator.Reset();
            while (iterator.MoveNext())
            {
                var relay = iterator.Current;
                TurnOff(relay, trace);
            }
        }

        private void TurnOff(IRelay relay, List<string> trace)
        {
            var theLastSigh = relay.Off();
            _output.WriteLine(theLastSigh);
            trace.Add(theLastSigh);
        }

        private void CreateOnAndStore(RelayRepository repo, int amount, List<string> trace)
        {
            for (int i = 0; i < amount; i++)
            {
                IRelay r = new Relay();
                var theCry = r.On();
                repo.Add(r);

                trace.Add(theCry);
                _output.WriteLine(theCry); //I am alive!
            }
        }
    }
}