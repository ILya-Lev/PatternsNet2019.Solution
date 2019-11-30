using System;
using Creational.Concept;

namespace Creational.AbstractFactory
{
    public class BombedMazeFactory : MazeFactory
    {
        public override Room CreateRoom(int number) => new RoomWithABomb(number);
        public override Wall CreateWall() => new BombedWall();

        private Spell CastSpell() => throw new NotImplementedException();
    }

    public class BombedWall : Wall
    {
    }

    public class RoomWithABomb : Room
    {
        public RoomWithABomb(in int number) : base(number) { }
    }
}