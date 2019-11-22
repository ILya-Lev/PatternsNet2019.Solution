using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StructuralDemos")]

namespace Structural.Decorator
{
    internal interface IControlDevice
    {
        string On();
        string Off();
    }

    internal class Relay : IControlDevice
    {
        public string On() => "Relay::On";

        public string Off() => "Relay::Off";
    }

}