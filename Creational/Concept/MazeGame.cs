namespace Creational.Concept
{
    public class MazeGame
    {
        public Maze CreateMaze()
        {
            var firstRoom = new Room(1);
            var secondRoom = new Room(2);
            var door = new Door(firstRoom, secondRoom);

            firstRoom[Direction.North] = new Wall();
            firstRoom[Direction.East] = door;
            firstRoom[Direction.South] = new Wall();
            firstRoom[Direction.West] = new Wall();

            secondRoom[Direction.North] = new Wall();
            secondRoom[Direction.East] = new Wall();
            secondRoom[Direction.South] = new Wall();
            secondRoom[Direction.West] = door;

            var maze = new Maze();
            maze.AddRoom(firstRoom);
            maze.AddRoom(secondRoom);
            return maze;
        }
    }
}