using System;
using System.Collections.Generic;

namespace Behavioral.ChainOfResponsibilityATM
{
    public interface INotePicker
    {
        /// <summary>
        /// returns an amount of notes of specific value to represent given total value
        /// </summary>
        IReadOnlyList<(int, int)> GetNumberOfNotes(in int totalValue);
    }

    public class NotePicker : INotePicker
    {
        private readonly int _value;
        private readonly INotePicker _successor;

        public NotePicker(int value, INotePicker successor = null)
        {
            if (value <= 0) throw new Exception($"Value should be positive, but provided {value}.");
            _value = value;
            _successor = successor;
        }

        public IReadOnlyList<(int, int)> GetNumberOfNotes(in int totalValue)
        {
            var amount = totalValue / _value;
            var remainder = totalValue % _value;
            
            var result = new List<(int, int)>();
            
            if (amount != 0)
            {
                result.Add((_value, amount));
            }

            if (remainder != 0)
            {
                var subResults = _successor?.GetNumberOfNotes(remainder) ?? new List<(int, int)>{(0, remainder)};
                result.AddRange(subResults);
            }
            
            return result;
        }
    }
}