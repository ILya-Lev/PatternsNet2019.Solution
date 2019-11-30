using System.Collections.Generic;

namespace Creational.Concept
{
    public interface MapSite { void Enter(); }

    public enum Direction { North, East, South, West }

    public class Wall : MapSite
    {
        public void Enter() => throw new System.NotImplementedException();
    }

    public class Room : MapSite
    {
        private readonly MapSite[] _sides = new MapSite[4];
        public int Number { get; }

        public Room(int number) => Number = number;

        public MapSite this[Direction direction]
        {
            get => _sides[(int)direction];
            set => _sides[(int)direction] = value;
        }

        public void Enter() => throw new System.NotImplementedException();
    }

    public class Door : MapSite
    {
        private readonly Room _from;
        private readonly Room _to;
        private bool _isOpen;

        public Door(Room from, Room to)
        {
            _from = from;
            _to = to;
        }

        public Room GetOtherSideFrom(Room from)
        {
            if (from == _from) return _to;
            if (from == _to) return _from;
            throw new KeyNotFoundException($"This door is between rooms {_from.Number} and {_to.Number}." +
                                           $" Other side is asked for room {from.Number} - and cannot be found!");
        }

        public void Enter() => throw new System.NotImplementedException();
    }
}