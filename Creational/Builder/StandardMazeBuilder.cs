using Creational.Concept;

namespace Creational.Builder
{
    public class StandardMazeBuilder : MazeBuilder
    {
        //it's not written anywhere, but it's 1-1 relation, any interventions will break everything
        //what about fluent API?...
        private Maze _currentMaze;

        public override void BuildMaze() => _currentMaze = new Maze();

        public override void BuildRoom(int number)
        {
            if (_currentMaze.GetRoom(number) != null) return;

            var room = new Room(number)
            {
                [Direction.North] = new Wall(),
                [Direction.East] = new Wall(),
                [Direction.South] = new Wall(),
                [Direction.West] = new Wall()
            };

            _currentMaze.AddRoom(room);
        }

        public override void BuildDoor(int fromNumber, int toNumber)
        {
            var from = _currentMaze.GetRoom(fromNumber);
            var to = _currentMaze.GetRoom(toNumber);

            var door = new Door(from, to);

            from[FindCommonWall(from, to)] = door;
            to[FindCommonWall(to, from)] = door;
        }

        public override Maze GetMaze() => _currentMaze;

        private Direction FindCommonWall(Room lhs, Room rhs)
        {
            //dummy implementation - introduce room coordinates to make it work!
            return lhs.Number < rhs.Number ? Direction.East : Direction.West;
        }
    }
}