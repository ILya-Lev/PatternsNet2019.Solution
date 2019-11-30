namespace Creational.BuilderSmartHouse
{
    internal interface IRelay
    {
        string On();
        string Off();
    }

    internal class Relay : IRelay
    {
        public string On() => "Relay is on";

        public string Off() => "Relay is off";
    }
}
