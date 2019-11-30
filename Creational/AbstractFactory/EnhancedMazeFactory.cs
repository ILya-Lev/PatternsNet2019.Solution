using System;
using Creational.Concept;

namespace Creational.AbstractFactory
{
    public class EnhancedMazeFactory : MazeFactory
    {
        public override Room CreateRoom(int number) => new EnhancedRoom(number);
        public override Door CreateDoor(Room from, Room to) => new EnhancedDoor(@from, to);

        private Spell CastSpell() => throw new NotImplementedException();
    }

    public class EnhancedDoor : Door
    {
        public EnhancedDoor(Room from, Room to) : base(from, to) { }
    }

    public class EnhancedRoom : Room
    {
        public EnhancedRoom(in int number) : base(number) { }
    }

    public class Spell
    {

    }
}