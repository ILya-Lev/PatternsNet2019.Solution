using Structural.Decorator;
using Xunit;
using Xunit.Sdk;

namespace StructuralDemos
{
    public class DecoratorDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        private int _actionCounter = 0;
        public DecoratorDemo(TestOutputHelper output) { _output = output; }

        [Fact]
        public void Decorator_DifferentCombinations_CollectAllMessages()
        {
            IControlDevice simpleRelay = new Relay();
            Print(simpleRelay.On());
            

            IControlDevice relayWithRadio = new Radio(simpleRelay);
            Print(relayWithRadio.On());

            IControlDevice extendRelay = new ExtendLight(simpleRelay);
            Print(extendRelay.On());

            IControlDevice bigRelay = new ExtendLight(new Radio(simpleRelay));
            Print(bigRelay.On());
            Print(bigRelay.Off());
        }

        [Fact]
        public void Decorator_Monster_CollectAllMessages()
        {
            IControlDevice monster = new Radio(new ExtendLight(new Radio(new ExtendLight(new Relay()))));
            Print(monster.On());
            Print(monster.Off());
        }

        private void Print(string message) => _output.WriteLine($"{_actionCounter++}: {message}");
    }
}