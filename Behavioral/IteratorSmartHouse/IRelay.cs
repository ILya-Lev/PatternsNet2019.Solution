using System;

namespace Behavioral.IteratorSmartHouse
{
    interface IRelay
    {
        /// <summary>
        /// tells outer world when last time the relay was turned on
        /// </summary>
        DateTime? LastTimeSwitchOnAt { get; }
        string On();
        string Off();
    }
}
