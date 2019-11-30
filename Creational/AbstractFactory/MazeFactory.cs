using Creational.Concept;

namespace Creational.AbstractFactory
{
    public class MazeFactory
    {
        public virtual Maze CreateMaze() => new Maze();
        public virtual Wall CreateWall() => new Wall();
        public virtual Room CreateRoom(int number) => new Room(number);
        public virtual Door CreateDoor(Room from, Room to) => new Door(from, to);
    }
}