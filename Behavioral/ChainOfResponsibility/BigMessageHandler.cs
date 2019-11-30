﻿using System;

namespace Behavioral.ChainOfResponsibility
{
    internal class BigMessageHandler : IHandler<string,string>
    {
        private readonly int _messageLengthThreshold;
        private readonly IHandler<string, string> _successor;
        
        public BigMessageHandler(int messageLengthThreshold, IHandler<string, string> successor = null)
        {
            _messageLengthThreshold = messageLengthThreshold;
            _successor = successor;
        }

        public bool CanHandle(string message) => message?.Length > _messageLengthThreshold;

        public string Handle(string message)
        {
            return CanHandle(message)
                ? $"Message '{message}' was handled in {nameof(BigMessageHandler)}"
                : _successor?.Handle(message)
                  ?? throw new Exception($"Message '{message}' cannot be handled neither" +
                                         $" with {nameof(BigMessageHandler)} nor" +
                                         $" with its successor {_successor?.GetType().Name ?? "null"}");
        }
    }
}