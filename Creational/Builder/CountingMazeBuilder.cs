using Creational.Concept;

namespace Creational.Builder
{
    public class CountingMazeBuilder : MazeBuilder
    {
        public int Doors { get; private set; } = 0;
        public int Rooms { get; private set; } = 0;

        public override void BuildRoom(int number) => Rooms++;

        public override void BuildDoor(int fromNumber, int toNumber) => Doors++;

        public override Maze GetMaze() => null;
    }
}