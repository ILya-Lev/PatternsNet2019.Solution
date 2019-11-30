using System;

namespace Structural.Bridge
{
    class RelayZWave : IRelay
    {
        public string On() => "RelayZWave::On";
        public string Off() => "RelayZWave::Off";
    }
}
