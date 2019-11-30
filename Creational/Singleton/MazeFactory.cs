using Creational.AbstractFactory;
using Creational.Concept;

namespace Creational.Singleton
{
    public class MazeFactoryParameters { public string Message { get; set; } }

    public class MazeFactory
    {
        //begininit flag and static ctor...
        protected static MazeFactory _instance = null;
        public static MazeFactory CreateInstance(MazeFactoryParameters p) => _instance ??= new MazeFactory(p);

        protected MazeFactory(MazeFactoryParameters p) { Message = p.Message; }

        public string Message { get; }

        public virtual Maze CreateMaze() => new Maze();
        public virtual Wall CreateWall() => new Wall();
        public virtual Room CreateRoom(int number) => new Room(number);
        public virtual Door CreateDoor(Room from, Room to) => new Door(from, to);
    }

    public class EnhancedMazeFactory : MazeFactory
    {
        public new static MazeFactory CreateInstance(MazeFactoryParameters p)
            => _instance ??= new EnhancedMazeFactory(p);
        protected EnhancedMazeFactory(MazeFactoryParameters p) : base(p) { }

        public override Room CreateRoom(int number) => new EnhancedRoom(number);

        public override Door CreateDoor(Room from, Room to) => new EnhancedDoor(@from, to);
    }

    public class BombedMazeFactory : MazeFactory
    {
        public new static MazeFactory CreateInstance(MazeFactoryParameters p)
            => _instance ??= new BombedMazeFactory(p);
        protected BombedMazeFactory(MazeFactoryParameters p) : base(p) { }

        public override Wall CreateWall() => new BombedWall();

        public override Room CreateRoom(int number) => new RoomWithABomb(number);
    }
}