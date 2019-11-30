using Creational.Concept;

namespace Creational.Prototype
{
    /// <summary>
    /// idea is to provide prototypes in ctor, and call clone + initialize each time you need new instance
    /// clone method implies parameter-less ctor
    /// initialize method implies the same objects per prototype are required (the same interface case)
    ///                        or no compiler checks...
    ///
    /// nevertheless it's not possible to apply the pattern without modifications in domain entities structure
    /// </summary>
    public class MazePrototypeFactory
    {
        private readonly Maze _prototypeMaze;
        private readonly Room _prototypeRoom;
        private readonly Door _prototypeDoor;
        private readonly Wall _prototypeWall;

        public MazePrototypeFactory(Maze maze, Room room, Door door, Wall wall)
        {
            _prototypeMaze = maze;
            _prototypeRoom = room;
            _prototypeDoor = door;
            _prototypeWall = wall;
        }

        //protected virtual Maze MakeMaze() => _prototypeMaze.Clone();
        //protected virtual Wall MakeWall() => _prototypeWall.Clone();
        //protected virtual Room MakeRoom(in int number) => _prototypeRoom.Clone(number);
        //protected virtual Door MakeDoor(Room from, Room to)
        //{
        //    var d = _prototypeDoor.Clone();
        //    d.
        //}
    }
}