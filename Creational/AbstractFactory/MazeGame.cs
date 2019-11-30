using Creational.Concept;

namespace Creational.AbstractFactory
{
    /// <summary>
    /// example using factory
    /// </summary>
    public class MazeGame
    {
        public Maze CreateMaze(MazeFactory factory)
        {
            var firstRoom = factory.CreateRoom(1);
            var secondRoom = factory.CreateRoom(2);
            var door = factory.CreateDoor(firstRoom, secondRoom);

            firstRoom[Direction.North] = factory.CreateWall();
            firstRoom[Direction.East] = door;
            firstRoom[Direction.South] = factory.CreateWall();
            firstRoom[Direction.West] = factory.CreateWall();

            secondRoom[Direction.North] = factory.CreateWall();
            secondRoom[Direction.East] = factory.CreateWall();
            secondRoom[Direction.South] = factory.CreateWall();
            secondRoom[Direction.West] = door;

            var maze = factory.CreateMaze();
            maze.AddRoom(firstRoom);
            maze.AddRoom(secondRoom);
            return maze;
        }
    }
}