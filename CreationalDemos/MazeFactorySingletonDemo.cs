using Creational.Singleton;
using FluentAssertions;
using Xunit;

namespace CreationalDemos
{
    public class MazeFactorySingletonDemo
    {
        [Fact]
        public void Instance_BaseClassFewTimes_OnlyOneExists()
        {
            var mazeFactory = MazeFactory.CreateInstance(new MazeFactoryParameters() { Message = "base class 1" });

            mazeFactory.Should().BeOfType<MazeFactory>();
            mazeFactory.Should().NotBeOfType<EnhancedMazeFactory>();
            mazeFactory.Should().NotBeOfType<BombedMazeFactory>();
            mazeFactory.Message.Should().Be("base class 1");

            var anotherMazeFactory = MazeFactory.CreateInstance(new MazeFactoryParameters() { Message = "another one" });

            anotherMazeFactory.Should().Be(mazeFactory);    //reference equality
            anotherMazeFactory.Message.Should().Be("base class 1");
        }

        [Fact]
        public void Instance_BaseClassThenSubClass_OnlyBaseClassInstanceExists()
        {
            var mazeFactory = MazeFactory.CreateInstance(new MazeFactoryParameters() { Message = "base class 1" });

            mazeFactory.Should().BeOfType<MazeFactory>();
            mazeFactory.Should().NotBeOfType<EnhancedMazeFactory>();
            mazeFactory.Should().NotBeOfType<BombedMazeFactory>();
            mazeFactory.Message.Should().Be("base class 1");

            var bombedMazeFactory = BombedMazeFactory.CreateInstance(new MazeFactoryParameters() { Message = "bombed" });

            bombedMazeFactory.Should().Be(mazeFactory);    //reference equality !!!
            bombedMazeFactory.Message.Should().Be("base class 1");
        }

        [Fact]
        public void Instance_SubClassThenBaseClass_OnlySubClassInstanceExists()
        {
            var bombedMazeFactory = BombedMazeFactory.CreateInstance(new MazeFactoryParameters() { Message = "bombed" });
            bombedMazeFactory.Message.Should().Be("bombed");

            var mazeFactory = MazeFactory.CreateInstance(new MazeFactoryParameters() { Message = "base class" });

            bombedMazeFactory.Should().Be(mazeFactory);    //reference equality !!!

            mazeFactory.Should().NotBeOfType<MazeFactory>();
            mazeFactory.Should().NotBeOfType<EnhancedMazeFactory>();
            mazeFactory.Should().BeOfType<BombedMazeFactory>();
            mazeFactory.Message.Should().NotBe("base class");
        }
    }
}