using System;

namespace Behavioral.ChainOfResponsibility
{
    internal class NullMessageHandler : IHandler<string,string>
    {
        private readonly IHandler<string, string> _successor;

        public NullMessageHandler(IHandler<string,string> successor = null)
        {
            _successor = successor;
        }

        public bool CanHandle(string message) => string.IsNullOrWhiteSpace(message);

        public string Handle(string message)
        {
            return CanHandle(message)
                ? $"A message was handled in {nameof(NullMessageHandler)}"
                : _successor?.Handle(message)
                  ?? throw new Exception($"Message '{message}' cannot be handled neither" +
                                         $" with {nameof(NullMessageHandler)} nor" +
                                         $" with its successor {_successor?.GetType().Name ?? "null"}");
        }
    }
}
