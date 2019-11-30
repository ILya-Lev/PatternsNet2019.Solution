using System;

namespace Structural.Bridge
{
    class RelayNoolite : IRelay
    {
        public string On() => "RelayNoolite::On";
        public string Off() => "RelayNoolite::Off";
    }
}
