using Creational.Concept;

namespace Creational.Builder
{
    public abstract class MazeBuilder
    {
        public virtual void BuildMaze() { }
        public virtual void BuildRoom(int number) { }
        public virtual void BuildDoor(int fromNumber, int toNumber) { }

        public abstract Maze GetMaze();
    }
}