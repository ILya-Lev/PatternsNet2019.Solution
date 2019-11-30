using Creational.Builder;
using Creational.Concept;
using FluentAssertions;
using Xunit;
using MazeGame = Creational.Builder.MazeGame;

namespace CreationalDemos
{
    public class BuilderMazeCreationDemo
    {
        [Fact]
        public void BuildMaze_CountingBuilder_RoomsAndDoorsNumber()
        {
            var builder = new CountingMazeBuilder();
            var game = new MazeGame();

            var maze = game.CreateMaze(builder);

            builder.Rooms.Should().Be(2);
            builder.Doors.Should().Be(1);
            maze.Should().BeNull();
        }

        [Fact]
        public void BuildMaze_StandardBuilder_ActuallyCreates()
        {
            var builder = new StandardMazeBuilder();
            var game = new MazeGame();

            var maze = game.CreateMaze(builder);

            maze.Should().NotBeNull();
            maze.GetRoom(1).Should().NotBeNull();
            maze.GetRoom(2).Should().NotBeNull();
            maze.GetRoom(1)[Direction.East].Should().BeOfType<Door>();
        }
    }
}
