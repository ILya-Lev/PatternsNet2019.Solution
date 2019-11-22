using System;

namespace Structural.Decorator
{
    internal abstract class RelayDecorator : IControlDevice
    {
        private readonly IControlDevice _decoratee;

        protected RelayDecorator(IControlDevice nd)
        {
            if (nd == this)
                throw new ArgumentException("Cannot decorate itself");

            _decoratee = nd ?? throw new ArgumentNullException(nameof(nd), "Cannot decorate null object");
        }

        public virtual string On() => _decoratee.On();

        public virtual string Off() => _decoratee.Off();
    }

    internal class ExtendLight : RelayDecorator
    {
        public ExtendLight(IControlDevice nd) : base(nd) { }

        public override string On() => $"Extend light is on\n\t{base.On()}";

        public override string Off() => $"Extend light is off\n\t{base.Off()}";
    }

    internal class Radio : RelayDecorator
    {
        public Radio(IControlDevice nd) : base(nd) { }
        
        public override string On() => $"Radio is on\n\t{base.On()}";
        
        public override string Off() => $"Radio is off\n\t{base.Off()}";
    }
}