using Creational.Concept;

namespace Creational.FactoryMethod
{
    public class MazeGame
    {
        //is also a template method
        public Maze CreateMaze()
        {
            var maze = MakeMaze();
            var firstRoom = MakeRoom(1);
            var secondRoom = MakeRoom(2);

            maze.AddRoom(firstRoom);
            maze.AddRoom(secondRoom);
            
            var door = MakeDoor(firstRoom, secondRoom);

            firstRoom[Direction.North] = MakeWall();
            firstRoom[Direction.East] = door;
            firstRoom[Direction.South] = MakeWall();
            firstRoom[Direction.West] = MakeWall();

            secondRoom[Direction.North] = MakeWall();
            secondRoom[Direction.East] = MakeWall();
            secondRoom[Direction.South] = MakeWall();
            secondRoom[Direction.West] = door;

            return maze;
        }

        protected virtual Maze MakeMaze() => new Maze();
        protected virtual Room MakeRoom(int number) => new Room(number);
        protected virtual Door MakeDoor(Room from, Room to) => new Door(@from, to);
        protected virtual Wall MakeWall() => new Wall();
    }

    internal class DarkMaze : MazeGame
    {
        protected override Room MakeRoom(int number) => new DarkRoom(number);
    }

    internal class DarkRoom : Room
    {
        public DarkRoom(int number) : base(number) {}
    }

    internal class MazeConsumer
    {
        public void Consume(MazeGame game)
        {
            game.CreateMaze();
        }
    }
}