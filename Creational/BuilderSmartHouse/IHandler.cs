namespace Creational.BuilderSmartHouse
{
    internal interface IHandler
    {
        string Handle();
    }

    internal class Handler : IHandler
    {
        public string Handle() => "I'm a handler";
    }
}
