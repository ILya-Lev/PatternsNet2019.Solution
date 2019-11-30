using Creational.AbstractFactory;
using Creational.Concept;

namespace Creational.FactoryMethod
{
    public class EnhancedMazeGame : MazeGame
    {
        protected override Room MakeRoom(int number) => new EnhancedRoom(number);

        protected override Door MakeDoor(Room from, Room to) => new EnhancedDoor(@from, to);
    }
}