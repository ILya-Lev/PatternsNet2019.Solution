using Creational.AbstractFactory;
using Creational.Concept;

namespace Creational.FactoryMethod
{
    public class BombedMazeGame : MazeGame
    {
        protected override Room MakeRoom(int number) => new RoomWithABomb(number);

        protected override Wall MakeWall() => new BombedWall();
    }
}