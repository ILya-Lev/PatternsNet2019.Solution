namespace Creational.BuilderSmartHouse
{
    internal interface IScenario
    {
        string Execute();
    }

    internal class Scenario : IScenario
    {
        private readonly int _i;

        public Scenario(int i = 0)
        {
            _i = i;
        }

        public string Execute() => $"A scenario #{_i} has been executed";
    }
}
