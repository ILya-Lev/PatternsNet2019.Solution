using Creational.Concept;

namespace Creational.Builder
{
    public class MazeGame
    {
        //does not know about walls at all!
        public Maze CreateMaze(MazeBuilder builder)
        {
            builder.BuildMaze();

            builder.BuildRoom(1);
            builder.BuildRoom(2);
            builder.BuildDoor(1, 2);

            return builder.GetMaze();
        }
    }
}