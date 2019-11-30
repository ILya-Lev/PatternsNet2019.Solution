using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CreationalDemos")]
namespace Creational.BuilderSmartHouse
{
    internal interface IComponentBuilder
    {
        IRelay CreateRelay();
        IPost CreatePost();
        IScenario CreateScenario();
        IHandler CreateHandler();
    }

    internal class StubComponentBuilder : IComponentBuilder
    {
        public IRelay CreateRelay() => new Relay();

        public IPost CreatePost() => new Post();

        public IScenario CreateScenario() => new Scenario();

        public IHandler CreateHandler() => new Handler();
    }
}
